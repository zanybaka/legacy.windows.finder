using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Samples.Finder.Components.Common.Logging
{
    /// <summary>
    /// This class used write error messages to log implemented in Microsoft Logging Application Block.
    /// </summary>
    public static class ErrorLog
    {
        #region Constants

        //TODO: move into the resources
        private const string ErrorTitle = "Error in application";

        private const string ExceptionTitle = "Exception in application";

        private static readonly string[] ErrorCategories = new[] {"Error"};

        #endregion

        #region Public methods

        /// <summary>
        /// Writes the specified error message to error log.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Write(string message)
        {
            Write(message, Priority.High, EventType.Error, TraceEventType.Error, ErrorTitle);
        }

        /// <summary>
        /// Writes the specified exception to log.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void Write(Exception exception)
        {
            Write(exception.ToString(), Priority.Critical, EventType.Exception, TraceEventType.Critical, ExceptionTitle,
                  CreateProperties());
        }

        /// <summary>
        /// Writes the specified message to error log.
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
        /// Writes the specified error message to error log.
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
            Log.Write(message, ErrorCategories, priority, (int) eventType, severity, title, properties);
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