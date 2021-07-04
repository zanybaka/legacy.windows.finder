namespace Samples.Finder.Components.Common.Logging
{
    /// <summary>
    /// Represent full list of all event types
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Represents undefined, default value
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Event about error 
        /// </summary>
        Error = 1,

        /// <summary>
        /// Event about exception.
        /// </summary>
        Exception = 2,

        /// <summary>
        /// Develpment message event type
        /// </summary>
        DevelopmentMessage = 3,

        /// <summary>
        /// Algorithm message
        /// </summary>
        AlgorithmMessage = 4,

        /// <summary>
        /// System message
        /// </summary>
        SystemMessage = 5,

        /// <summary>
        /// Audit event
        /// </summary>
        AuditEvent = 6,

        /// <summary>
        /// Event type for unit testing purposes
        /// </summary>
        TestMessage = 7,

        /// <summary>
        /// This event can occurs when system detect situation like dead lock
        /// </summary>
        LockDetection = 8,
    }
}