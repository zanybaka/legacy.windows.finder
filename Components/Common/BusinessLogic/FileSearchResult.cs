using System.IO;

namespace Samples.Finder.Components.Common.BusinessLogic
{
    public class FileSearchResult : SearchResult
    {
        #region Private fields

        #endregion

        #region Constructor

        public FileSearchResult(DirectoryInfo directory, FileInfo[] files, DirectoryInfo[] directories)
        {
            Directory = directory;
            Files = files;
            Directories = directories;
        }

        #endregion

        #region Public properties

        public DirectoryInfo Directory { get; private set; }

        public FileInfo[] Files { get; private set; }

        public DirectoryInfo[] Directories { get; private set; }

        #endregion
    }
}