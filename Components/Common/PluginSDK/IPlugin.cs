using System;
using System.IO;
using System.Windows.Forms;

namespace Samples.Finder.Components.Common.PluginSDK
{
    public interface IPlugin : IDisposable
    {
        string Name { get; }

        UserControl MainInterface { get; }

        string FilePattern { get; }

        Guid Id { get; }

        FileInfo[] Filter(FileInfo[] info);
    }
}