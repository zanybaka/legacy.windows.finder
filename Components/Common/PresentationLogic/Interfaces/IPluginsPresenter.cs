using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;

namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IPluginsPresenter : IPresenter
    {
        void RefreshPlugins();

        void SearchInPluginsChanged();

        void PluginSelected();
    }
}