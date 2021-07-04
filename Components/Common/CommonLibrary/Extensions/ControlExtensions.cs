using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Samples.Finder.Components.Common.CommonLibrary.Extensions
{
    public static class ControlExtensions
    {
        public static bool HasErrors<TInterface>(this Control control, ErrorProvider provider)
            where TInterface : class
        {
            var childs = control.Descendants<TInterface>();
            foreach (var child in childs)
            {
                if (!string.IsNullOrEmpty(provider.GetError(child)))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Control> Descendants<TInterface>(this Control control)
            where TInterface : class
        {
            if (control == null)
            {
                return new List<Control>();
            }
            return Enumerable.ToList<Control>(control.Controls.Cast<Control>().SelectRecursively(x => x.Controls.Cast<Control>()).Where(x => (x as TInterface) != null));
        }

        public static void Fill<T>(this ListControl list, IList<KeyValuePair<T, string>> items)
        {
            list.DataSource = items;
            list.DisplayMember = "Value";
            list.ValueMember = "Key";
        }

        public static void Fill<T>(this ListControl list, IEnumerable<KeyValuePair<T, string>> items)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            list.DataSource = new List<KeyValuePair<T, string>>(items);
            list.DisplayMember = "Value";
            list.ValueMember   = "Key";
        }

        public static void SafeSetValue<T>(this ListControl list, T value)
        {
            //todo: check whether the list contains the specified value
            list.SelectedValue = value;
        }
    }
}