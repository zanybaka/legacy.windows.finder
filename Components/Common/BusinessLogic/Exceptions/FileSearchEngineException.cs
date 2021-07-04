using System;

namespace Samples.Finder.Components.Common.BusinessLogic.Exceptions
{
    [Serializable]
    public class FileSearchEngineException : BusinessLogicException
    {
        public FileSearchEngineException(Exception innerException)
            //todo: move HARDCODE into the resources
            : this(string.Format("Internal file search engine error."), innerException)
        {
        }

        public FileSearchEngineException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}