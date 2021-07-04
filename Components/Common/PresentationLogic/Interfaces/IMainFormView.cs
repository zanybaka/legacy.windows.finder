using Samples.Finder.Components.Common.CommonLibrary.Enums;

namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IMainFormView : IView
    {
        long ResultCount { get; set; }

        bool IsReadyToSearch { get; set; }
        
        bool IsInProgress { get; set; }

        SearchStatus SearchStatus { get; set; }
        
        string SearchCurrentPath { get; set; }
    }
}