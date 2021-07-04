using Samples.Finder.Components.Common.PresentationLogic.Interfaces;

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters.Base
{
    public interface IPresenter
    {
        void Initialize(IView view, ITask task);
        void PropertyChanged(string propertyName);
    }
}