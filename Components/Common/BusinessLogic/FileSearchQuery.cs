using System;
using System.IO;
using Samples.Finder.Components.Common.CommonLibrary.Enums;
using Samples.Finder.Components.Common.PluginSDK;

namespace Samples.Finder.Components.Common.BusinessLogic
{
    public class FileSearchQuery
    {
        #region Private fields

        private string searchFor;

        #endregion

        #region Constructors

        public FileSearchQuery(string searchIn)
        {
            SearchIn = searchIn;
        }

        #endregion

        #region Public properties

        public FileAttributes Attributes { get; set; }

        public DateTime EndDate { get; set; }

        public ComparisonOperation Operation { get; set; }

        public long SizeInBytes { get; set; }

        public DateTime StartDate { get; set; }

        public IPlugin Plugin { get; set; }

        public string SearchIn { get; set; }

        /// <summary>
        /// Pattern (mask) such as *.*
        /// </summary>
        public string SearchFor
        {
            get
            {
                if (string.IsNullOrEmpty(searchFor))
                {
                    return "*";
                }
                return searchFor;
            }
            set { searchFor = value; }
        }

        public bool SearchInSubdirectories { get; set; }

        public bool SearchByAttributes { get; set; }

        public bool SearchBySize { get; set; }

        public bool SearchByDate { get; set; }

        #endregion
    }
}