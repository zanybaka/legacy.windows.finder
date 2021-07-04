using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Samples.Finder.Components.Common.PluginSDK
{
    [Serializable]
    public class PluginDictionary : Dictionary<Guid, IPlugin>
    {
        public PluginDictionary()
        {
        }

        protected PluginDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}