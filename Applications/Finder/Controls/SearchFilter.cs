using Samples.Finder.Application.Controls.Base;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters;

namespace Samples.Finder.Application.Controls
{
    //TODO: process OnResize event
    public partial class SearchFilter : UserControlBase, ISearchFilterView
    {
        #region .ctor

        public SearchFilter()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override bool HasErrors()
        {
            return ucAdvancedFilter.HasErrors() || ucGeneralFilter.HasErrors() || ucPlugins.HasErrors();
        }

        protected override void InitializePresenter(ITask task)
        {
            BasePresenter = new SearchFilterPresenter();
            BasePresenter.Initialize(this, task);
            ucAdvancedFilter.Initialize(task);
            ucGeneralFilter.Initialize(task);
            ucPlugins.Initialize(task);
        }

        #endregion
    }
}