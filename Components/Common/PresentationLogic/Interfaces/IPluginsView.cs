using System.Collections.Generic;
using Samples.Finder.Components.Common.PluginSDK;

namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IPluginsView : IView
    {
        bool IsEditablePlugin { get; set; }
        
        bool SearchInPlugins { get; set; }

        string PluginPath { get; }
        
        string PluginExtension { get; }

        IPlugin GetSelectedPlugin();

        void RefreshPluginList(IEnumerable<IPlugin> collection);
    }
}