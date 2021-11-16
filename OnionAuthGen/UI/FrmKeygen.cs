using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public partial class FrmKeygen : Form
    {
        /// <summary>
        /// Holds the generated/derived/constructed key
        /// </summary>
        /// <remarks>
        /// This is null if <see cref="Form.DialogResult"/>
        /// is not <see cref="DialogResult.OK"/>
        /// </remarks>
        public OnionDetails Key { get; private set; }

        public bool AutoSave { get; private set; }

        private readonly Dictionary<RadioButton, Control[]> SwitchedControls;

        public FrmKeygen()
        {
            InitializeComponent();
            SwitchedControls = new Dictionary<RadioButton, Control[]>
            {
                { RbRandom, new Control[] { LblRandomOpt } },
                { RbPassword, new Control[] { LblEnterPassword, TbKey, LlRandomKey, LblKeyNumber, NudKeyNumber, BtnNumberHelp, CbHarderKey, LblFieldNote } },
                { RbDesign, new Control[0] }
            };
            Tools.ScaleForm(this);
            Tools.RegisterFormHelp(this);
            HandleRadioChange();
#if DEBUG
            TbOnion.Text = "DEBUG" + string.Empty.PadRight(51, 'A') + ".onion";
#endif
        }

        private void HandleRadioChange()
        {
            foreach (var KV in SwitchedControls)
            {
                foreach (var C in KV.Value)
                {
                    C.Enabled = KV.Key.Checked;
                }
            }
        }

        private void SetRandomWords(int Count)
        {
            if (Count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Count), "Value must be at least 1");
            }
            var Words = new List<string>();
            byte[] RandomData = new byte[4];
            var WordList = Tools.WordList;
            using (var RNG = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                while (Words.Count < Count)
                {
                    RNG.GetBytes(RandomData);
                    var Num = (int)(BitConverter.ToUInt32(RandomData, 0) / (double)uint.MaxValue * WordList.Length);
                    if (Num < WordList.Length)
                    {
                        Words.Add(WordList[Num]);
                    }
                }
            }
            TbKey.Text = string.Join(" ", Words);
        }

        private bool GenerateRandomKey()
        {
            Key = OnionGenerator.GenerateAuthentication(TbOnion.Text);
            return true;
        }

        private bool GenerateDeterministicKey()
        {
            if (string.IsNullOrEmpty(TbKey.Text))
            {
                MessageBox.Show("Please enter a key", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TbKey.Select();
                TbKey.Focus();
                TbKey.SelectAll();
                return false;
            }
            Key = OnionGenerator.DeriveAuthentication(TbKey.Text, (int)NudKeyNumber.Value, TbOnion.Text, CbHarderKey.Checked);
            return true;
        }

        private bool GenerateDesignerKey()
        {
            using (var Designer = new FrmKeydesign())
            {
                if (Designer.ShowDialog() == DialogResult.OK)
                {
                    Key = OnionGenerator.ImportKey(TbOnion.Text, Designer.Key);
                    return true;
                }
            }
            return false;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (OnionGenerator.IsOnionName(TbOnion.Text))
            {
                bool Result;
                if (RbRandom.Checked)
                {
                    Result = GenerateRandomKey();
                }
                else if (RbPassword.Checked)
                {
                    Result = GenerateDeterministicKey();
                }
                else if (RbDesign.Checked)
                {
                    Result = GenerateDesignerKey();
                }
                else
                {
                    throw new NotImplementedException();
                }
                if (Result)
                {
                    AutoSave = cbAutoSave.Checked;
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("The onion domain has an invalid format. " +
                    "It should be 56 characters long, and optionally be followed by '.onion'",
                    "Invalid domain", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TbOnion.Select();
                TbOnion.Focus();
            }
        }

        private void RbRandom_CheckedChanged(object sender, EventArgs e)
        {
            HandleRadioChange();
        }

        private void RbPassword_CheckedChanged(object sender, EventArgs e)
        {
            HandleRadioChange();
        }

        private void RbDesign_CheckedChanged(object sender, EventArgs e)
        {
            HandleRadioChange();
        }

        private void LlRandomKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetRandomWords(6);
        }

        private void LlRandomKey_DoubleClick(object sender, EventArgs e)
        {
            //We register the double click event too because people like to spam click
            SetRandomWords(6);
        }

        private void BtnNumberHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Tools.GetResourceText("KeyNumberInfo.txt"), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
