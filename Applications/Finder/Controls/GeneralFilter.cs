using System;
using System.IO;
using System.Windows.Forms;
using Samples.Finder.Application.Controls.Base;
using Samples.Finder.Application.Resources;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters;
using Samples.Finder.Application.Extensions;
using ControlExtensions = Samples.Finder.Components.Common.CommonLibrary.Extensions.ControlExtensions;

namespace Samples.Finder.Application.Controls
{
    public partial class GeneralFilter : UserControlBase, IGeneralFilterView
    {
        #region Private members

        private IGeneralFilterPresenter Presenter
        {
            get
            {
                return (IGeneralFilterPresenter) BasePresenter;
            }
        }

        #endregion

        #region .ctor

        public GeneralFilter()
        {
            InitializeComponent();
        }

        #endregion

        #region IGeneralFilterView members

        public string SearchPattern
        {
            get { return txtSearchPattern.Text; }
            set { txtSearchPattern.Text = value; }
        }

        public string SearchPath
        {
            get { return txtSearchPath.Text; }
            set { txtSearchPath.Text = value; }
        }

        #endregion

        #region Events

        private void OnBrowseFolderClick(object sender, EventArgs e)
        {
            if (fbdSearchPath.ShowDialog() == DialogResult.OK)
            {
                txtSearchPath.Text = fbdSearchPath.SelectedPath;
            }
        }

        private void OnSearchPathChanged(object sender, EventArgs e)
        {
            if (txtSearchPath.ValidateControl(errorProvider, string.Format(Strings.InvalidValueFormat, txtSearchPath.Text)))
            {
                if (!Directory.Exists(txtSearchPath.Text))
                {
                    errorProvider.SetError(txtSearchPath, string.Format(Strings.SpecifiedPathDoesNotExistFormat, txtSearchPath.Text));
                }
            }
            if (!IsSilent)
            {
                Presenter.SearchPathChanged();
                OnPropertyChanged("SearchPath");
            }
        }

        private void OnSearchPatternChanged(object sender, EventArgs e)
        {
            txtSearchPattern.ValidateControl(errorProvider, string.Format(Strings.InvalidValueFormat, txtSearchPattern.Text));
            if (!IsSilent)
            {
                Presenter.SearchPatternChanged();
                OnPropertyChanged("SearchPattern");
            }
        }

        #endregion

        #region Overrides

        public override bool HasErrors()
        {
            return ControlExtensions.HasErrors<IRegExValidatable>(this, errorProvider);
        }

        protected override void InitializePresenter(ITask task)
        {
            BasePresenter = new GeneralFilterPresenter();
            BasePresenter.Initialize(this, task);
        }

        #endregion
    }
}