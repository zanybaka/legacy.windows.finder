using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Samples.Finder.Application.Controls
{
    public class RegExTextBox : TextBox, IRegExValidatable
    {
        public string RegularExpression { get; set; }

        public bool Validate()
        {
            Regex expression;
            try
            {
                expression = new Regex(RegularExpression);
            }
            catch
            {
                return false;
            }

            if (expression.IsMatch(Text))
            {
                return true;
            }
            return false;
        }
    }
}