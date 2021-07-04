using System;
using System.Windows.Forms;
using Samples.Finder.Application.Controls;

namespace Samples.Finder.Application.Extensions
{
    internal static class ControlExtensions
    {
        public static bool ValidateControl<TControl>(this TControl control, ErrorProvider provider, string message)
            where TControl : Control, IRegExValidatable
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            if (!control.Validate())
            {
                provider.SetError(control, message);
                return false;
            }
            provider.SetError(control, null);
            return true;
        }
    }
}