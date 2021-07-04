using System.Collections.Generic;
using System.IO;

namespace Samples.Finder.Components.Common.PresentationLogic
{
    public class SearchResult
    {
        public DirectoryInfo CurrentPath { get; set; }
        public IList<FileSystemInfo> Items { get; private set; }

        public SearchResult()
        {
            Items = new List<FileSystemInfo>();
        }
    }
}