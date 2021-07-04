#region usings

using System;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Samples.Finder.Application.Controls;
using Samples.Finder.Application.Controls.Base;
using Samples.Finder.Application.Extensions;
using Samples.Finder.Application.Properties;
using Samples.Finder.Application.Resources;
using Samples.Finder.Components.Common.CommonLibrary.Enums;
using Samples.Finder.Components.Common.CommonLibrary.Extensions;
using Samples.Finder.Components.Common.PresentationLogic.Exceptions;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters;

#endregion

namespace Samples.Finder.Application
{
    public partial class MainForm : FormBase, IMainFormView
    {
        #region .ctor

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(ITask task) : base(task)
        {
            InitializeComponent();
        }

        #endregion

        #region Private members

        private IMainFormPresenter Presenter
        {
            get { return (IMainFormPresenter) BasePresenter; }
        }

        private void SetStatusText(string value)
        {
            tsslStatus.Text = value;
        }

        #endregion

        #region IMainFormView Members

        private bool isReadyToSearch;

        public long ResultCount { get; set; }

        public bool IsReadyToSearch
        {
            get { return isReadyToSearch; }
            set
            {
                isReadyToSearch = value;
                OnPropertyChanged("IsReadyToSearch");
            }
        }
        
        private bool isInProgress;

        public bool IsNotInProgress
        {
            get { return !isInProgress; }
        }

        public bool IsInProgress
        {
            get { return isInProgress; }
            set
            {
                isInProgress = value;
                OnPropertyChanged("IsInProgress");
                OnPropertyChanged("IsNotInProgress");
            }
        }

        public SearchStatus SearchStatus { get; set; }

        public string SearchCurrentPath { get; set; }

        #endregion

        #region Overrides

        protected override void InitializePresenter(ITask task)
        {
            BasePresenter = new MainFormPresenter();
            BasePresenter.Initialize(this, task);
            ucSearchFilter.Initialize(task);
            ucResultList.Initialize(task);
        }

        public override bool HasErrors()
        {
            return ucResultList.HasErrors() || ucSearchFilter.HasErrors();
        }

        protected override void SetBindings()
        {
            btnStart.AddBinding(control=>control.Enabled, this, source=>source.IsReadyToSearch);
            btnStop.AddBinding(control => control.Enabled, this, source => source.IsInProgress);
            ucSearchFilter.AddBinding(control => control.Enabled, this, source => source.IsNotInProgress);
        }

        public override void InvalidateControls()
        {
            AcceptButton = btnStop.Enabled ? btnStop : btnStart;
            switch (SearchStatus)
            {
                case SearchStatus.Unknown:
                    SetStatusText(string.Empty);
                    break;
                case SearchStatus.Stopped:
                    if (ResultCount == 0)
                    {
                        SetStatusText(Strings.ProgressNoResults);
                    } else
                    {
                        SetStatusText(string.Format(Strings.ProgressDoneFormat, ResultCount));
                    }
                    break;
                case SearchStatus.Starting:
                    SetStatusText(Strings.ProgressSearching);
                    break;
                case SearchStatus.InProgress:
                    SetStatusText(SearchCurrentPath);
                    break;
                default:
                    SetStatusText(SearchStatus.ToString());
                    var exception = new UnknownSearchStatusException(SearchStatus);
                    if (ExceptionPolicy.HandleException(exception,
                                                    Settings.Default.ApplicationPolicyName))
                    {
                        throw exception;
                    }
                    break;
            }
        }

        #endregion

        #region Events

        private void OnStartClick(object sender, EventArgs e)
        {
            Presenter.StartSearch();
        }

        private void OnStopClick(object sender, EventArgs e)
        {
            Presenter.StopSearch();
        }

        #endregion
    }
}