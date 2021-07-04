namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IView : ISilentView
    {
        bool HasErrors();

        void InvalidateControls();

        void Show();
    }
}