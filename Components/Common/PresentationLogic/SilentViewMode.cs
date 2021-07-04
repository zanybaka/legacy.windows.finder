using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;

namespace Samples.Finder.Components.Common.PresentationLogic
{
    public sealed class SilentViewMode : IDisposable
    {
        private string guid;
        private readonly object syncObj = new object();
        private readonly string viewUniqueName;

        private ISilentView view;

        public SilentViewMode(ISilentView view)
        {
            viewUniqueName = view.UniqueName;
            lock (syncObj)
            {
                if ((string)CallContext.GetData(viewUniqueName) == null)
                {
                    this.view = view;
                    view.IsSilent = true;
                    guid = new Guid().ToString();
                    CallContext.SetData(viewUniqueName, guid);
                }
            }
        }

        public void Dispose()
        {
            Debug.Assert(CallContext.GetData(viewUniqueName) != null);
            lock (syncObj)
            {
                if ((string)CallContext.GetData(viewUniqueName) == guid)
                {
                    CallContext.FreeNamedDataSlot(viewUniqueName);
                    guid = null;
                    view.IsSilent = false;
                    view = null;
                }
            }
        }
    }
}
