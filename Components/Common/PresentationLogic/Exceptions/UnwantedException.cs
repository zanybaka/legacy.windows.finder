using System;
using System.Runtime.Serialization;

namespace Samples.Finder.Components.Common.PresentationLogic.Exceptions
{
    [Serializable]
    public class UnwantedException : Exception
    {
        protected UnwantedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnwantedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnwantedException(string message) : base(message)
        {
        }

        public UnwantedException()
        {
        }
    }
}