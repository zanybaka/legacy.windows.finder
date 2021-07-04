using System;
using System.Collections.Generic;
using System.IO;
using Samples.Finder.Components.Common.PluginSDK.Exceptions;
using Samples.Finder.Components.Common.PluginSDK.Helpers;

namespace Samples.Finder.Components.Common.PluginSDK
{
    public class FileSystemPluginLoader : IPluginLoader
    {
        public List<IPlugin> LoadPlugins(string uri, string extension)
        {
            var inheritances = new List<IPlugin>();
            try
            {
                inheritances =
                    AssemblyHelper.LoadInterfaceInheritances<IPlugin>(uri,
                        string.Format("*.{0}", extension));
            }
            catch (BadImageFormatException ex)
            {
                //TODO: make RuntimeExceptionWrapper in the config file
                //TODO: move HARDCODE into the resources
                throw new PluginCouldNotLoadedException("Invalid plugin.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                //TODO: make RuntimeExceptionWrapper in the config file
                //TODO: move HARDCODE into the resources
                new PluginCouldNotLoadedException("Invalid plugin directory.", ex);
            }
            return inheritances;
        }
    }
}