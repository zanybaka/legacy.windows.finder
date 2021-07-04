using System.Collections.Generic;
using System.Diagnostics;

namespace Samples.Finder.Components.Common.Logging
{
    /// <summary>
    /// This class used for logging system events e.g. Start service, batch execution start, etc.
    /// </summary>
    public static class SystemLog
    {
        #region Constatns

        private static readonly string[] Categories = new[] {"System"};

        #endregion

        #region Public methods

        /// <summary>
        /// Writes the specified message to algorithm log.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Write(string message)
        {
            Write(message, Priority.High, EventType.SystemMessage, TraceEventType.Information, message);
        }

        /// <summary>
        /// Writes the specified message to algorithm log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The title.</param>
        public static void Write(string message, Priority priority, EventType eventType, TraceEventType severity,
                                 string title)
        {
            Write(message, priority, eventType, severity, title, CreateProperties());
        }

        /// <summary>
        /// Writes the specified error message to algorithm log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The title.</param>
        /// <param name="properties">The properties.</param>
        public static void Write(string message, Priority priority, EventType eventType, TraceEventType severity,
                                 string title,
                                 IDictionary<string, object> properties)
        {
            Log.Write(message, Categories, priority, (int) eventType, severity, title, properties);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Creates the properties.
        /// </summary>
        /// <returns></returns>
        private static IDictionary<string, object> CreateProperties()
        {
            return new Dictionary<string, object>();
        }

        #endregion
    }
}