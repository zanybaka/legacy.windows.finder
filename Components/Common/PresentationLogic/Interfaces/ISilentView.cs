namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface ISilentView
    {
        bool IsSilent { get; set; }
        string UniqueName { get; }
    }
}