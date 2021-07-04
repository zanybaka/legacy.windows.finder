using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ID3Sharp;
using Samples.Finder.Components.Common.PluginSDK;
using Samples.Finder.Components.Common.PluginSDK.Exceptions;

namespace Samples.Finder.Components.Common.Plugins.Mp3Plugin
{
    public class Mp3Plugin : IPlugin, IDisposable
    {
        #region Private members

        private readonly UserControl mainInterface;

        #endregion

        #region .ctor

        public Mp3Plugin()
        {
            mainInterface = new Mp3Filter();
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region IPlugin Members

        public string Name
        {
            get { return "Mp3Plugin"; }
        }

        public UserControl MainInterface
        {
            get { return mainInterface; }
        }

        public string FilePattern
        {
            get { return "*.mp3"; }
        }

        public FileInfo[] Filter(FileInfo[] info)
        {
            try
            {
                var view = (IMp3FilterView) MainInterface;
                var list = new List<FileInfo>();
                foreach (FileInfo file in info)
                {
                    try
                    {
                        if (ID3v1Tag.HasTag(file.FullName))
                        {
                            ID3v1Tag tag = ID3v1Tag.ReadTag(file.FullName, Encoding.Default);
                            if (tag.HasTitle && tag.Title.Contains(view.TitlePart))
                            {
                                list.Add(file);
                                continue;
                            }
                        }
                        /* Test it!
                                        if (ID3v2Tag.HasTag(file.FullName))
                                        {
                                            ID3v2Tag tag = ID3v2Tag.ReadTag(file.FullName, Encoding.Default);
                                            GC.Collect();
                                            if (tag.HasTitle && tag.Title.Contains(view.TitlePart))
                                            {
                                                list.Add(file);
                                                continue;
                                            }
                                        }
                        */
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
            }
            catch (Exception e)
            {
                throw new PluginException("Can't filter files.", e);
            }
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public void Dispose()
        {
            if (mainInterface != null)
            {
                mainInterface.Dispose();
            }
        }

        #endregion
    }
}