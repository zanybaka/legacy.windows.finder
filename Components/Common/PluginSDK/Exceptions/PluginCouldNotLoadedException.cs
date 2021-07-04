using System;
using System.Runtime.Serialization;

namespace Samples.Finder.Components.Common.PluginSDK.Exceptions
{
    [Serializable]
    public class PluginCouldNotLoadedException : Exception
    {
        public PluginCouldNotLoadedException()
        {
        }

        public PluginCouldNotLoadedException(string message) : base(message)
        {
        }

        public PluginCouldNotLoadedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PluginCouldNotLoadedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}