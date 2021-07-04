using System;
using System.ComponentModel;
using System.IO;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;
using FileSearchQuery=Samples.Finder.Components.Common.PresentationLogic.Queries.SearchQuery;
using Samples.Finder.Components.Common.CommonLibrary.Extensions;

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters
{
    public class MainFormPresenter : PresenterBase<IMainFormView, SearchTask>, IMainFormPresenter
    {
        protected override void InitView()
        {
            using (new SilentViewMode(View))
            {
                View.SearchStatus = Task.ProgressStatus;
                View.IsInProgress = Task.IsEngineInProgress;
                View.IsReadyToSearch = !Task.IsEngineInProgress && !View.HasErrors() && Directory.Exists(Task.Query.SearchPath);
                View.InvalidateControls();
            }
        }

        protected override void InitTask()
        {
            Task.CurrentPathChanged += OnTaskSearchCurrentPathChanged;
            Task.ClearResultsRequest += OnTaskClearResultsRequest;
            Task.StatusChanged += OnTaskSearchStatusChanged;
            Task.Query.PropertyChanged += OnQueryChanged;
            Task.AddResultsRequest += OnTaskAddResultsRequest;
        }

        private void OnTaskClearResultsRequest(object sender, EventArgs e)
        {
            View.ResultCount = 0;
        }

        private void OnTaskAddResultsRequest(object sender, EventArgs e)
        {
            View.ResultCount = Task.ResultCount;
        }

        private void OnQueryChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Task.Query.GetPropertyName(x => x.SearchPath) ||
                e.PropertyName == Task.Query.GetPropertyName(x => x.SearchPattern))
            {
                InitView();
            }
        }

        private void OnTaskSearchStatusChanged(object sender, EventArgs e)
        {
            InitView();
        }

        private void OnTaskSearchCurrentPathChanged(object sender, EventArgs e)
        {
            using (new SilentViewMode(View))
            {
                View.SearchCurrentPath = Task.ProgressCurrentPath;
            }
            View.InvalidateControls();
        }

        public void StartSearch()
        {
            Task.StartSearchEngine();
        }

        public void StopSearch()
        {
            Task.StopSearchEngine();
        }
    }
}