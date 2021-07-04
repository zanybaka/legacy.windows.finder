using System.Collections.Generic;

namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IResultListView : IView
    {
        void Clear();
        void Add(IEnumerable<string> resultToAdd);
        string SelectedItem { get; }
    }
}