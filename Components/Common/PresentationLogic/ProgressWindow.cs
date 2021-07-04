using System;
using System.Windows.Forms;

namespace Samples.Finder.Components.Common.PresentationLogic
{
    public class ProgressWindow : IDisposable
    {
        private readonly ProgressForm form;

        public ProgressWindow()
        {
            form = new ProgressForm
                       {
                           ShowInTaskbar = false,
                           TopMost = true,
                           StartPosition = FormStartPosition.CenterScreen
                       };
            form.Show();
            Application.DoEvents();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (form != null)
            {
                form.Dispose();
            }
        }

        #endregion
    }
}