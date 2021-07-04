using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Samples.Finder.Components.Common.BusinessLogic;
using Samples.Finder.Components.Common.CommonLibrary.Enums;
using Samples.Finder.Components.Common.PresentationLogic.Adapters;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Queries;

namespace Samples.Finder.Components.Common.PresentationLogic.Tasks
{
    public class SearchTask : ITask
    {
        #region .ctor

        public SearchTask()
        {
            lastResults = new List<FileSystemInfo>();
            Query = new SearchQuery();
            Query.Attributes = FileAttributes.Archive;
            Query.SearchInSubdirectories = true;
            Query.SearchPattern = "*.*";
            Query.StartDate = DateTime.Now;
            Query.EndDate = DateTime.Now;
        }

        #endregion

        #region Query

        private SearchQuery query;
        public SearchQuery Query
        {
            get { return query; }
            set
            {
                if (query != null)
                {
                    query.UnsubscribeAll();
                }
                query = value;
            }
        }

        #endregion

        #region ProgressStatus

        private SearchStatus progressStatus;
        public SearchStatus ProgressStatus
        {
            get { return progressStatus; }
            set
            {
                progressStatus = value;
                var handler = StatusChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler StatusChanged;

        #endregion

        #region ProgressCurrentPath

        private string progressCurrentPath;
        public string ProgressCurrentPath
        {
            get { return progressCurrentPath; }
            set
            {
                progressCurrentPath = value;
                var handler = CurrentPathChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler CurrentPathChanged;

        #endregion

        #region Results

        private readonly List<FileSystemInfo> lastResults;

        public long ResultCount { get; private set; }

        public ReadOnlyCollection<FileSystemInfo> LastResults
        {
            get { return new ReadOnlyCollection<FileSystemInfo>(lastResults); }
        }

        public void ClearResults()
        {
            ResultCount = 0;
            lastResults.Clear();
            var handler = ClearResultsRequest;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void AddResults(ICollection<FileSystemInfo> newResults)
        {
            lastResults.Clear();
            lastResults.AddRange(newResults);
            ResultCount += newResults.Count;
            var handler = AddResultsRequest;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler ClearResultsRequest;
        public event EventHandler AddResultsRequest;

        #endregion

        #region Engine

        private FileSearchEngine engine;

        private void OnEngineProcessing(object sender, SearchResultEventArgs e)
        {
            var result = ((FileSearchResult)e.Result);
            var translated = result.Translate();
            AddResults(translated.Items);
            if (ProgressStatus != SearchStatus.InProgress)
            {
                ProgressStatus = SearchStatus.InProgress;
            }
            ProgressCurrentPath = translated.CurrentPath.FullName;
        }

        private void OnEngineStarted(object sender, EventArgs args)
        {
            ProgressStatus = SearchStatus.Starting;
        }

        private void OnEngineStopped(object sender, EventArgs args)
        {
            ProgressStatus = SearchStatus.Stopped;
        }

        public bool IsEngineInProgress
        {
            get
            {
                return engine != null && engine.IsInProgress;
            }
        }

        public void StartSearchEngine()
        {
            if (engine != null && engine.IsInProgress)
            {
                return;
            }
            ClearResults();
            StopSearchEngine();
            engine = new FileSearchEngine(Query.Translate());
            engine.Started += OnEngineStarted;
            engine.Finished += OnEngineStopped;
            engine.Processing += OnEngineProcessing;
            engine.Start();
        }

        public void StopSearchEngine()
        {
            if (engine == null || !engine.IsInProgress)
            {
                return;
            }
            engine.Finish();
        }

        public void Close()
        {
            StopSearchEngine();
        }

        #endregion
    }
}