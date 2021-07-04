using System;

namespace Samples.Finder.Components.Common.BusinessLogic.Exceptions
{
    [Serializable]
    public class SearchEngineException : BusinessLogicException
    {
        public SearchEngineException(Exception innerException)
            //todo: move HARDCODE into the resources
            : this(string.Format("Internal search engine error."), innerException)
        {
        }

        public SearchEngineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}