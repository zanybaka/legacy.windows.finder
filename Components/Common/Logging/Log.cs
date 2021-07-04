using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Samples.Finder.Components.Common.Logging
{
    /// <summary>
    /// This class used as wrapper between Microsoft Application Block and our application.
    /// </summary>
    public static class Log
    {
        #region Fields

        private const string logPrefixFormat = "yyyy.MM.dd_";

        private const string traceLogFileName = "trace.log";

        private static bool _isConfigured;

        #endregion

        #region Public methods

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="categories">The categories.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The title.</param>
        /// <param name="properties">The properties.</param>
        public static void Write(object message, string[] categories, Priority priority, int eventId,
                                 TraceEventType severity,
                                 string title, IDictionary<string, object> properties)
        {
            Configure();

            var item = new LogItem();
            item.Message = message.ToString();
            item.Categories = categories;
            item.Priority = (int) priority;
            item.EventId = eventId;
            item.Severity = severity;
            item.Title = title;
            item.ExtendedProperties = properties;
            Logger.Write(item);
        }

        /// <summary>
        /// Configures logging subsystem.
        /// </summary>
        public static void Configure()
        {
            if (_isConfigured)
            {
                return;
            }

            if (File.Exists(traceLogFileName) && IsObsolete())
            {
                string formatted = File.GetLastWriteTimeUtc(traceLogFileName).ToString(logPrefixFormat) +
                                   traceLogFileName;

                if (!File.Exists(formatted))
                {
                    File.Move(traceLogFileName, formatted);
                }
            }

            _isConfigured = true;
        }

        private static bool IsObsolete()
        {
            return
                !File.GetLastWriteTimeUtc(traceLogFileName).ToShortDateString().Equals(
                    DateTime.UtcNow.ToShortDateString());
        }

        #endregion
    }
}