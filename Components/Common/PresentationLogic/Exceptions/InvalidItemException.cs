using System;

namespace Samples.Finder.Components.Common.PresentationLogic.Exceptions
{
    [Serializable]
    public class InvalidItemException : RuntimeException
    {
        public InvalidItemException(string message) : base(message)
        {
        }

        public InvalidItemException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}