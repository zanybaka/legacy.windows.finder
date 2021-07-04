using System;
using System.Runtime.Serialization;
using Samples.Finder.Components.Common.CommonLibrary.Enums;

namespace Samples.Finder.Components.Common.BusinessLogic.Exceptions
{
    [Serializable]
    public class UnknownComparisonOperationException : BusinessLogicException
    {
        protected UnknownComparisonOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public UnknownComparisonOperationException(ComparisonOperation operation)
            : base(string.Format("Unknown comparison operation '{0}'", operation))
        {
        }
    }
}