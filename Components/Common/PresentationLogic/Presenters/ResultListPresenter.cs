#region usings

using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Samples.Finder.Components.Common.PresentationLogic.Exceptions;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;
using Samples.Finder.Components.Common.PresentationLogic.Properties;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;

#endregion

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters
{
    public class ResultListPresenter : PresenterBase<IResultListView, SearchTask>, IResultListPresenter
    {
        protected override void InitView()
        {
            View.InvalidateControls();
        }

        protected override void InitTask()
        {
            Task.ClearResultsRequest += OnTaskClearResultsRequest;
            Task.AddResultsRequest += OnTaskAddResultsRequest;
        }

        private void OnTaskAddResultsRequest(object sender, EventArgs e)
        {
            var items = Task.LastResults.Select(x => x.FullName);
            View.Add(items);
        }

        private void OnTaskClearResultsRequest(object sender, EventArgs e)
        {
            View.Clear();
        }

        public void OpenSelectedItem()
        {
            var item = View.SelectedItem;
            if (item == null)
            {
                return;
            }
            using (new ProgressWindow())
            {
                try
                {
                    var info = new ProcessStartInfo(item);
                    var process = new Process();
                    process.StartInfo = info;
                    process.Start();
                } catch (Exception e)
                {
                    var wrapper = new InvalidItemException("Can't open selected item.", e);
                    if (ExceptionPolicy.HandleException(wrapper, Settings.Default.PresentationLogicPolicyName))
                    {
                        throw wrapper;
                    }
                }
            }
        }
    }
}