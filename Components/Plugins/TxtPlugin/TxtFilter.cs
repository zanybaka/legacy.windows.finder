using System.Windows.Forms;

namespace Samples.Finder.Components.Common.Plugins.TxtPlugin
{
    public partial class TxtFilter : UserControl, ITxtFilterView
    {
        public TxtFilter()
        {
            InitializeComponent();
        }

        #region ITxtFilterView Members

        public string TextPart
        {
            get { return txtPart.Text; }
            set { txtPart.Text = value; }
        }

        #endregion
    }
}