using System;
using System.Collections.Generic;
using System.IO;
using Samples.Finder.Components.Common.BusinessLogic;
using Samples.Finder.Components.Common.CommonLibrary.Enums;
using System.Linq;
using Samples.Finder.Components.Common.PresentationLogic.Queries;

namespace Samples.Finder.Components.Common.PresentationLogic.Adapters
{
    public static class DataAdapter
    {
        public static Dictionary<FileUnit, string> GetFileUnitList()
        {
            //TODO: Move HARDCODE into the Resources
            //TODO: Cache data (create user dictionaries)
            var list = new Dictionary<FileUnit, string>();
            list.Add(FileUnit.Byte, "Byte(s)");
            list.Add(FileUnit.Kilobyte, "Kilobyte(s)");
            list.Add(FileUnit.Megabyte, "Megabyte(s)");
            list.Add(FileUnit.Gigabyte, "Gigabyte(s)");
            return list;
        }

        public static Dictionary<ComparisonOperation, string> GetComparisonOperationList()
        {
            //TODO: Move HARDCODE into the Resources
            //TODO: Cache data (create user dictionaries)
            var list = new Dictionary<ComparisonOperation, string>();
            list.Add(ComparisonOperation.Equal, "=");
            list.Add(ComparisonOperation.Less, "<");
            list.Add(ComparisonOperation.More, ">");
            return list;
        }

        public static Dictionary<FileAttributes, string> GetFileAttributeList()
        {
            //TODO: Cache data (create user dictionaries)
            var list = new Dictionary<FileAttributes, string>();
            foreach (FileAttributes attribute in Enum.GetValues(typeof (FileAttributes)))
            {
                //TODO: Get Presentation Name from the Resources
                list.Add(attribute, attribute.ToString());
            }
            return list;
        }

        public static SearchResult Translate(this FileSearchResult result)
        {
            var translated = new SearchResult
                           {
                               CurrentPath = result.Directory,
                           };
            result.Directories.Cast<FileSystemInfo>().ToList().ForEach(translated.Items.Add);
            result.Files.Cast<FileSystemInfo>().ToList().ForEach(translated.Items.Add);
            return translated;
        }

        public static FileSearchQuery Translate(this SearchQuery query)
        {
            var item = new FileSearchQuery(query.SearchPath);
            item.Attributes = query.Attributes;
            item.EndDate = query.EndDate;
            item.Operation = query.ComparisonOperation;
            item.Plugin = query.Plugin;
            item.SearchByAttributes = query.SearchByAttributes;
            item.SearchByDate = query.SearchByDate;
            item.SearchBySize = query.SearchBySize;
            item.SearchFor = query.SearchPattern;
            item.SearchInSubdirectories = query.SearchInSubdirectories;
            item.SearchIn = query.SearchPath;
            item.SizeInBytes = query.SizeInBytes;
            item.StartDate = query.StartDate;
            return item;
        }
    }
}