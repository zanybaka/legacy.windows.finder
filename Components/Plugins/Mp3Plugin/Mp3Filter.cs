using System.Windows.Forms;

namespace Samples.Finder.Components.Common.Plugins.Mp3Plugin
{
    public partial class Mp3Filter : UserControl, IMp3FilterView
    {
        public Mp3Filter()
        {
            InitializeComponent();
        }

        #region IMp3FilterView Members

        public string TitlePart
        {
            get { return txtTitlePart.Text; }
            set { txtTitlePart.Text = value; }
        }

        #endregion
    }
}