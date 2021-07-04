using System.Collections.Generic;

namespace Samples.Finder.Components.Common.PluginSDK
{
    public interface IPluginLoader
    {
        List<IPlugin> LoadPlugins(string uri, string extension);
    }
}