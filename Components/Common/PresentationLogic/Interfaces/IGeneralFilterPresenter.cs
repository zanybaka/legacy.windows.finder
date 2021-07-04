using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;

namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IGeneralFilterPresenter : IPresenter
    {
        void SearchPathChanged();

        void SearchPatternChanged();
    }
}