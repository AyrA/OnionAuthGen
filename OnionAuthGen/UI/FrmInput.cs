using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public partial class FrmInput : Form
    {
        private readonly bool requireValue;
        private readonly Regex pattern;

        /// <summary>
        /// Gets the user supplied value
        /// </summary>
        /// <remarks>
        /// This will be null if the user cancelled the dialog
        /// regardless of the preset value supplied in the constructor
        /// </remarks>
        public string Value { get; private set; }

        public FrmInput(string Title, string Description, string PresetValue = null, bool RequireValue = true, Regex Pattern = null)
        {
            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title));
            }

            if (Description == null)
            {
                throw new ArgumentNullException(nameof(Description));
            }

            InitializeComponent();
            Tools.ScaleForm(this);
            Text = Title;
            LblDescription.Text = Description;
            requireValue = RequireValue;
            pattern = Pattern;
            TbValue.Text = PresetValue;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var Empty = string.IsNullOrEmpty(TbValue.Text);
            if (!requireValue || !Empty)
            {
                if (Empty || pattern.IsMatch(TbValue.Text))
                {
                    Value = TbValue.Text;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("The supplied value is invalid", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please enter a value", "Empty value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
