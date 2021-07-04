using System;
using System.Runtime.Serialization;
using Samples.Finder.Components.Common.CommonLibrary.Enums;

namespace Samples.Finder.Components.Common.PresentationLogic.Exceptions
{
    [Serializable]
    public class UnknownSearchStatusException : RuntimeException
    {
        public UnknownSearchStatusException()
        {
        }

        public UnknownSearchStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownSearchStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnknownSearchStatusException(string message) : base(message)
        {
        }

        public UnknownSearchStatusException(SearchStatus status, Exception innerException)
            : base(string.Format("Unknown search status {0}", status), innerException)
        {
        }

        public UnknownSearchStatusException(SearchStatus status)
            : base(string.Format("Unknown search status '{0}'", status))
        {
        }
    }
}