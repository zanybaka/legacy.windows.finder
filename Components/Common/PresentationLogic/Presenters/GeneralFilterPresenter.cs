using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters
{
    public class GeneralFilterPresenter : PresenterBase<IGeneralFilterView, SearchTask>, IGeneralFilterPresenter
    {
        protected override void InitView()
        {
            using (new SilentViewMode(View))
            {
                View.SearchPath = Task.Query.SearchPath;
                View.SearchPattern = Task.Query.SearchPattern;
                View.InvalidateControls();
            }
        }

        protected override void InitTask()
        {
        }

        public void SearchPathChanged()
        {
            if (!View.IsSilent)
            {
                Task.Query.SearchPath = View.SearchPath;
            }
        }

        public void SearchPatternChanged()
        {
            if (!View.IsSilent)
            {
                var searchPattern = View.SearchPattern;
                if (!string.IsNullOrEmpty(searchPattern)
                    && !searchPattern.Contains("*"))
                {
                    searchPattern = string.Concat("*", searchPattern, "*");
                }
                Task.Query.SearchPattern = searchPattern;
            }
        }
    }
}