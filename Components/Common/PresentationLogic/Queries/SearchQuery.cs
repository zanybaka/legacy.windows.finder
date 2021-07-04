using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Samples.Finder.Components.Common.CommonLibrary.Enums;
using Samples.Finder.Components.Common.PluginSDK;

namespace Samples.Finder.Components.Common.PresentationLogic.Queries
{
    public class SearchQuery : INotifyPropertyChanged, IEditableObject, ICloneable
    {
        private SearchQuery queryClone;

        public SearchQuery(SearchQuery query)
        {
            Update(query);
        }

        private void Update(SearchQuery query)
        {
            attributes = query.Attributes;
            comparisonOperation = query.ComparisonOperation;
            endDate = query.EndDate;
            plugin = query.Plugin;
            searchByAttributes = query.SearchByAttributes;
            searchByDate = query.SearchByDate;
            searchBySize = query.SearchBySize;
            searchInSubdirectories = query.SearchInSubdirectories;
            searchPath = query.SearchPath;
            searchPattern = query.SearchPattern;
            sizeInBytes = query.SizeInBytes;
            startDate = query.StartDate;
        }

        public SearchQuery()
        {
             subscribers = new List<PropertyChangedEventHandler>();
        }

        public void UnsubscribeAll()
        {
            subscribers.Clear();
        }

        private FileAttributes attributes;

        private DateTime endDate;

        private ComparisonOperation comparisonOperation;
        private IPlugin plugin;
        private bool searchByAttributes;
        private bool searchByDate;
        private bool searchBySize;
        private bool searchInSubdirectories;
        private string searchPath;
        private string searchPattern;

        private long sizeInBytes;

        private DateTime startDate;

        public FileAttributes Attributes
        {
            get { return attributes; }
            set
            {
                attributes = value;
                OnPropertyChanged("Attributes");
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public ComparisonOperation ComparisonOperation
        {
            get { return comparisonOperation; }
            set
            {
                comparisonOperation = value;
                OnPropertyChanged("ComparisonOperation");
            }
        }

        public long SizeInBytes
        {
            get { return sizeInBytes; }
            set
            {
                sizeInBytes = value;
                OnPropertyChanged("SizeInBytes");
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public IPlugin Plugin
        {
            get { return plugin; }
            set
            {
                plugin = value;
                OnPropertyChanged("Plugin"); //you can use this.GetPropertyName(x=>x.Plugin) here
            }
        }

        public string SearchPath
        {
            get { return searchPath; }
            set
            {
                searchPath = value;
                OnPropertyChanged("SearchPath");
            }
        }

        public string SearchPattern
        {
            get { return searchPattern; }
            set
            {
                searchPattern = value;
                OnPropertyChanged("SearchPattern");
            }
        }

        public bool SearchInSubdirectories
        {
            get { return searchInSubdirectories; }
            set
            {
                searchInSubdirectories = value;
                OnPropertyChanged("SearchInSubdirectories");
            }
        }

        public bool SearchByAttributes
        {
            get { return searchByAttributes; }
            set
            {
                searchByAttributes = value;
                OnPropertyChanged("SearchByAttributes");
            }
        }

        public bool SearchBySize
        {
            get { return searchBySize; }
            set
            {
                searchBySize = value;
                OnPropertyChanged("SearchBySize");
            }
        }

        public bool SearchByDate
        {
            get { return searchByDate; }
            set
            {
                searchByDate = value;
                OnPropertyChanged("SearchByDate");
            }
        }

        #region INotifyPropertyChanged Members

        private readonly IList<PropertyChangedEventHandler> subscribers;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                subscribers.Add(value);
            }
            remove
            {
                subscribers.Remove(value);
            }
        }

        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            if (subscribers.Count == 0 || IsInEditMode)
            {
                return;
            }
            foreach (var handler in subscribers)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void BeginEdit()
        {
            IsInEditMode = true;
            queryClone = (SearchQuery)Clone();
        }

        private bool IsInEditMode { get; set; }

        public void EndEdit()
        {
            queryClone = null;
            IsInEditMode = false;
            OnPropertyChanged(string.Empty);
        }

        public void CancelEdit()
        {
            Update(queryClone);
            queryClone = null;
            IsInEditMode = false;
            OnPropertyChanged(string.Empty);
        }

        public object Clone()
        {
            return new SearchQuery(this);
        }
    }
}