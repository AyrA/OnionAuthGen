using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public partial class FrmKeydesign : Form
    {
        public string Key { get; private set; }

        public FrmKeydesign()
        {
            InitializeComponent();
            Tools.ScaleForm(this);
            Tools.RegisterFormHelp(this);
            SetStatusLabels();
        }

        private bool SetStatusLabels()
        {
            var LimitedChars = "ABCD|BFJNRVZ5|AQ".Split('|');
            var Text = tbKey.Text.ToUpper();
            var ColorOK = Color.FromArgb(0, 0xDD, 0);
            var ColorErr = Color.FromArgb(0xDD, 0, 0);
            var TextOK = "Yes";
            var TextErr = "No";
            bool Valid = true;

            var LastValidation = Text.Length == 52;
            lblLength.ForeColor = LastValidation ? ColorOK : ColorErr;
            lblLength.Text = LastValidation ? TextOK : TextErr;
            Valid &= LastValidation;
            LastValidation = System.Text.RegularExpressions.Regex.IsMatch(Text,@"^[A-Z2-7]+$");
            lblCharset.ForeColor = LastValidation ? ColorOK : ColorErr;
            lblCharset.Text = LastValidation ? TextOK : TextErr;
            Valid &= LastValidation;

            LastValidation = Text.Length>1 && LimitedChars[0].Contains(Text[1]);
            lblFirstLimit.ForeColor = LastValidation ? ColorOK : ColorErr;
            lblFirstLimit.Text = LastValidation ? TextOK : TextErr;
            Valid &= LastValidation;

            LastValidation = Text.Length > 49 && LimitedChars[1].Contains(Text[49]);
            lblSecondLimit.ForeColor = LastValidation ? ColorOK : ColorErr;
            lblSecondLimit.Text = LastValidation ? TextOK : TextErr;
            Valid &= LastValidation;

            LastValidation = Text.Length > 51 && LimitedChars[2].Contains(Text[51]);
            lblThirdLimit.ForeColor = LastValidation ? ColorOK : ColorErr;
            lblThirdLimit.Text = LastValidation ? TextOK : TextErr;
            Valid &= LastValidation;

            return Valid;
        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {
            SetStatusLabels();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (SetStatusLabels())
            {
                Key = tbKey.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The key is invalid. Check the table of conditions above the key field and try again.", "Invalid key format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
