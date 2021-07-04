using System.Collections.Generic;
using System.Diagnostics;

namespace Samples.Finder.Components.Common.Logging
{
    /// <summary>
    /// Class used for logging development events
    /// </summary>
    public static class DevLog
    {
        #region Constatns

        private static readonly string[] DevelopmentCategories = new[] {"Development"};

        #endregion

        #region Public methods

        /// <summary>
        /// Writes the specified message to devlopment log.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Write(string message)
        {
            Write(message, Priority.High, EventType.DevelopmentMessage, TraceEventType.Information, message);
        }

        /// <summary>
        /// Writes the specified message to devlopment log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The title.</param>
        public static void Write(object message, Priority priority, EventType eventType, TraceEventType severity,
                                 string title)
        {
            Write(message, priority, eventType, severity, title, CreateProperties());
        }

        /// <summary>
        /// Writes the specified error message to development log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The title.</param>
        /// <param name="properties">The properties.</param>
        public static void Write(object message, Priority priority, EventType eventType, TraceEventType severity,
                                 string title,
                                 IDictionary<string, object> properties)
        {
            Log.Write(message, DevelopmentCategories, priority, (int) eventType, severity, title, properties);
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