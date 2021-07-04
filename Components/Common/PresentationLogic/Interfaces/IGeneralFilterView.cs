namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IGeneralFilterView : IView
    {
        string SearchPattern { get; set; }

        string SearchPath { get; set; }
    }
}