using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Samples.Finder.Components.Common.BusinessLogic.Exceptions;
using Samples.Finder.Components.Common.BusinessLogic.Properties;
using Samples.Finder.Components.Common.CommonLibrary.Enums;
using Samples.Finder.Components.Common.PluginSDK;
using Samples.Finder.Components.Common.PluginSDK.Exceptions;

namespace Samples.Finder.Components.Common.BusinessLogic
{
    //TODO: Is needed FileRecursiveSearchEngine : FileSearchEngine (inheritance)?
    public class FileSearchEngine : SearchEngine
    {
        #region Private fields

        private readonly FileSearchQuery query;

        #endregion

        #region Constructor

        public FileSearchEngine(FileSearchQuery query)
        {
            this.query = query;
        }

        #endregion

        #region Overrides

        protected override T[] FilterByQuery<T>(T[] array)
        {
            var info = array as FileSystemInfo[];
            var result = new List<T>();
            if (info != null)
            {
                for (int i = 0; i < info.Length; i++)
                {
                    FileSystemInfo systemInfo = info[i];
                    if (query.SearchByAttributes
                        && (systemInfo.Attributes & query.Attributes) != query.Attributes
                        )
                    {
                        continue;
                    }
                    if (query.SearchByDate
                        && (systemInfo.LastWriteTime < query.StartDate.Date
                            || systemInfo.LastWriteTime >= query.EndDate.AddDays(1).Date)
                        )
                    {
                        continue;
                    }
                    if (query.SearchBySize)
                    {
/*
                        if ((systemInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory
                            )
                        {
                            continue;
                        }
*/
                        var file = systemInfo as FileInfo;
                        if (file != null)
                        {
                            if (!IsSuitableSize(file.Length, query.SizeInBytes, query.Operation))
                            {
                                continue;
                            }
                        }
                        var dir = systemInfo as DirectoryInfo;
                        if (dir != null)
                        {
                            if (!IsSuitableSize(0, query.SizeInBytes, query.Operation))
                            {
                                continue;
                            }
                        }
                    }
                    result.Add(systemInfo as T);
                }
            }
            return result.ToArray();
        }

        private static bool IsSuitableSize(long fileSize, long querySize, ComparisonOperation operation)
        {
            switch (operation)
            {
                case ComparisonOperation.Equal:
                    if (fileSize != querySize)
                    {
                        return false;
                    }
                    break;
                case ComparisonOperation.Less:
                    if (fileSize >= querySize)
                    {
                        return false;
                    }
                    break;
                case ComparisonOperation.More:
                    if (fileSize <= querySize)
                    {
                        return false;
                    }
                    break;
                default:
                    var exception = new UnknownComparisonOperationException(operation);
                    if (ExceptionPolicy.HandleException(exception, Settings.Default.BusinessLogicPolicyName))
                    {
                        throw exception;
                    }
                    return false;
            }
            return true;
        }

        protected override void Process()
        {
            var info = new DirectoryInfo(query.SearchIn);
            if (query.SearchInSubdirectories)
            {
                SearchRecursive(info);
            }
            else
            {
                Search(info);
            }
        }

        #endregion

        #region Private methods

        private void SearchRecursive(DirectoryInfo directoryToSearch)
        {
            if (!IsInProgress)
            {
                return;
            }
            bool result = Search(directoryToSearch);
            if (!result)
            {
                return;
            }
            var subdirectories = directoryToSearch.GetDirectories();
            for (int i = 0; i < subdirectories.Length; i++)
            {
                SearchRecursive(subdirectories[i]);
            }
        }

        private bool Search(DirectoryInfo directoryToSearch)
        {
            if (!IsInProgress)
            {
                return false;
            }
            FileInfo[] filteredFiles;
            DirectoryInfo[] filteredDirectories;
            try
            {
                if (query.Plugin != null)
                {
                    IPlugin plugin = query.Plugin;
                    //todo: validate pattern format
                    filteredFiles = directoryToSearch.GetFiles(plugin.FilePattern);
                    filteredFiles = plugin.Filter(filteredFiles);
                    filteredDirectories = new DirectoryInfo[] {};
                }
                else
                {
                    //todo: validate search path format
                    filteredFiles = directoryToSearch.GetFiles(query.SearchFor);
                    filteredDirectories = directoryToSearch.GetDirectories(query.SearchFor);
                }
            }
            catch (PluginException e)
            {
                if (ExceptionPolicy.HandleException(e, Settings.Default.BusinessLogicPolicyName))
                {
                    throw;
                }
                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                var wrapper = new FileSearchEngineException(e);
                if (ExceptionPolicy.HandleException(wrapper, Settings.Default.BusinessLogicPolicyName))
                {
                    throw wrapper;
                }
                return false;
            }
            filteredFiles = FilterByQuery(filteredFiles);
            filteredDirectories = FilterByQuery(filteredDirectories);
            var result = new FileSearchResult(directoryToSearch, filteredFiles, filteredDirectories);
            OnProcessing(result);
            return true;
        }

        #endregion
    }
}