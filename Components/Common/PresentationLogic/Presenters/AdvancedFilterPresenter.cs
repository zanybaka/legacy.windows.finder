using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters
{
    public class AdvancedFilterPresenter : PresenterBase<IAdvancedFilterView, SearchTask>, IAdvancedFilterPresenter
    {
        #region IAdvancedFilterPresenter Members

        public override void PropertyChanged(string propertyName)
        {
            if (!View.IsSilent)
            {
                //TODO: extend IAdvancedFilterPresenter for each property
                Task.Query.BeginEdit();
                Task.Query.Attributes = View.GetFileAttributes();
                Task.Query.ComparisonOperation = View.GetComparisonOperation();
                Task.Query.EndDate = View.EndDate;
                Task.Query.SearchByAttributes = View.SearchWithAttributes;
                Task.Query.SearchByDate = View.SearchByDate;
                Task.Query.SearchBySize = View.SearchBySize;
                Task.Query.SearchInSubdirectories = View.SearchInSubdirectories;
                Task.Query.SizeInBytes = View.GetFileSizeInBytes();
                Task.Query.StartDate = View.StartDate;
                Task.Query.EndEdit();
            }
            base.PropertyChanged(propertyName);
        }

        #endregion

        protected override void InitView()
        {
            using (new SilentViewMode(View))
            {
                View.EndDate = Task.Query.EndDate;
                View.SearchByDate = Task.Query.SearchByDate;
                View.SearchBySize = Task.Query.SearchBySize;
                View.SearchInSubdirectories = Task.Query.SearchInSubdirectories;
                View.SearchWithAttributes = Task.Query.SearchByAttributes;
                View.StartDate = Task.Query.StartDate;
                View.SetComparisonOperation(Task.Query.ComparisonOperation);
                View.SetFileAttributes(Task.Query.Attributes);
                View.SetFileSizeInBytes(Task.Query.SizeInBytes);
                View.InvalidateControls();
            }
        }

        protected override void InitTask()
        {
        }
    }
}