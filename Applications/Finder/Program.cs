using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Samples.Finder.Application.Properties;
using Samples.Finder.Application.Resources;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;

namespace Samples.Finder.Application
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            try
            {
                var task = new SearchTask();
                var form = new MainForm(task);
                form.Closed += delegate
                                   {
                                       task.Close();
                                       System.Windows.Forms.Application.Exit();
                                   };
                form.Show();
                System.Windows.Forms.Application.Run();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, Settings.Default.ApplicationPolicyName);
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                ExceptionPolicy.HandleException(exception, Settings.Default.ApplicationPolicyName);
            }
            else
            {
                Trace.TraceError(Strings.UnknownExceptionWasThrown);
            }
        }
    }
}