using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Samples.Finder.Components.Common.PluginSDK;
using Samples.Finder.Components.Common.PluginSDK.Exceptions;

namespace Samples.Finder.Components.Common.Plugins.TxtPlugin
{
    public class TxtPlugin : IPlugin, IDisposable
    {
        #region Private members

        private readonly UserControl mainInterface;

        #endregion

        #region .ctor

        public TxtPlugin()
        {
            mainInterface = new TxtFilter();
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return Name;
        }

        public void Dispose()
        {
            if (mainInterface != null)
            {
                mainInterface.Dispose();
            }
        }

        #endregion

        #region IPlugin Members

        public string Name
        {
            get { return "TxtPlugin"; }
        }

        public UserControl MainInterface
        {
            get { return mainInterface; }
        }

        public string FilePattern
        {
            get { return "*.txt"; }
        }

        public FileInfo[] Filter(FileInfo[] info)
        {
            try
            {
                var list = new List<FileInfo>();
                foreach (FileInfo file in info)
                {
                    try
                    {
                        using (var fs = new StreamReader(file.FullName, Encoding.Default))
                        {
                            while (!fs.EndOfStream)
                            {
                                string line = fs.ReadLine();
                                if (line.Contains(((ITxtFilterView) MainInterface).TextPart))
                                {
                                    list.Add(file);
                                    break;
                                }
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        //skip by default
                        //TODO: implement code here
                    }
                    catch (IOException)
                    {
                        //skip by default
                        //TODO: implement code here
                    }
                }
                return list.ToArray();
            } catch (Exception e)
            {
                throw new PluginException("Can't filter files.", e);
            }
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        #endregion
    }
}