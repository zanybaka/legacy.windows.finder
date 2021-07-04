using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;

namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IMainFormPresenter : IPresenter
    {
        void StartSearch();

        void StopSearch();
    }
}