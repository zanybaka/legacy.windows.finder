using System;
using System.Runtime.Serialization;

namespace Samples.Finder.Components.Common.PresentationLogic.Exceptions
{
    [Serializable]
    public class RuntimeException : Exception
    {
        protected RuntimeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public RuntimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RuntimeException(string message) : base(message)
        {
        }

        public RuntimeException()
        {
        }
    }
}