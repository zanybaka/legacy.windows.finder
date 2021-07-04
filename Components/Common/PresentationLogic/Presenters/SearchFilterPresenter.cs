using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters
{
    public class SearchFilterPresenter : PresenterBase<ISearchFilterView, SearchTask>, ISearchFilterPresenter
    {
        protected override void InitView()
        {
            View.InvalidateControls();
        }

        protected override void InitTask()
        {
        }
    }
}