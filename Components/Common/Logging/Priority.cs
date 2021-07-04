namespace Samples.Finder.Components.Common.Logging
{
    /// <summary>
    /// Represent possible values of Priorities
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Default value.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// The minimum priority of log event
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Low priority of log event
        /// </summary>
        Low = 2,

        /// <summary>
        /// Normal priority of log event
        /// </summary>
        Normal = 3,

        /// <summary>
        /// High priority of log event
        /// </summary>
        High = 4,

        /// <summary>
        /// Critical priority of log event
        /// </summary>
        Critical = 5
    }
}