using System;

namespace Samples.Finder.Components.Common.BusinessLogic
{
    public class SearchResultEventArgs : EventArgs
    {
        public SearchResultEventArgs(SearchResult result)
        {
            Result = result;
        }

        public SearchResult Result { get; private set; }
    }
}