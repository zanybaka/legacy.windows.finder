using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Samples.Finder.Components.Common.Logging;

namespace Samples.Finder.Components.Common.ExceptionHandlerExtensions
{
    [ConfigurationElementType(typeof (CustomHandlerData))]
    public class WinFormsApplicationMessageExceptionHandler : IExceptionHandler
    {
        //DO NOT DELETE!
        public WinFormsApplicationMessageExceptionHandler(NameValueCollection collection)
        {
        }

        #region IExceptionHandler Members

        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            LogException(exception);
            ShowThreadExceptionDialog(exception);
            return exception;
        }

        #endregion

        private static void LogException(Exception exception)
        {
            ErrorLog.Write(exception);
        }

        private static DialogResult ShowThreadExceptionDialog(Exception e)
        {
#if DEBUG
            string message = e.ToString();
#else
            string message = string.Format("{0}\r\n\r\nDetails:\r\n{1}", e.Message, e.InnerException == null ? "-" : e.InnerException.Message);
#endif
            //TODO: move HARDCODE into the resources
            return MessageBox.Show(message, "Application Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}