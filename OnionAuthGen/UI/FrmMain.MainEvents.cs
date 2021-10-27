using System;
using System.Linq;
using System.Windows.Forms;

namespace OnionAuthGen
{
    partial class FrmMain
    {
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            GenerateKey();
        }

        private void BtnSaveServer_Click(object sender, EventArgs e)
        {
            SaveServerKey();
        }

        private void BtnSaveClient_Click(object sender, EventArgs e)
        {
            SavePrivateKey();
        }

        private void BtnCopyClientLine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbClientConfigLine.Text))
            {
                Err("You need to either save a new key or import an existing key first.", "No configuration");
                return;
            }
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(TbClientConfigLine.Text);
                Info("Text copied to clipboard. Paste the line into your tor client configuration and restart tor.", "Clipboard");
            }
            catch (Exception ex)
            {
                Err("Cannot copy text to clipboard. This usually happens when the clipboard is locked.\r\n" +
                    "Try again, or select and copy manually instead\r\n" +
                    $"Error: {ex.Message}", "Clipboard");
                TbClientConfigLine.Focus();
                TbClientConfigLine.SelectAll();
            }
        }

        private void LblKeyInfo_Click(object sender, EventArgs e)
        {
            Info(Tools.GetResourceText("KeyInfo.txt"), "Key information");
        }

        private void CbHideClientValues_CheckedChanged(object sender, EventArgs e)
        {
            var Value = CbHideClientValues.Checked;
            if (Value || Info("Really show sensitive information?\r\n" +
                "Make sure nobody can see your screen and that no screen recorder is running", "Show sensitive information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TbClientLine.UseSystemPasswordChar = Value;
            }
            else
            {
                CbHideClientValues.Checked = !Value;
            }
        }

        private void FrmMain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            var HelpPages = "MF_Keygen,MF_PrivateKeys,MF_PublicKeys".Split(',');
            var f = Application.OpenForms.OfType<FrmHelp>().FirstOrDefault();
            if (f == null)
            {
                f = new FrmHelp();
            }
            f.Show();
            f.BringToFront();
            var Current = Tabs.TabPages.IndexOf(Tabs.SelectedTab);
            f.SetHelpArticle(HelpPages[Math.Max(0, Current)]);
        }

        private void BtnCopyClientKey_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbClientLine.Text))
            {
                Err("Please generate or import a key first", "No key");
                return;
            }
            else
            {
                var Key = TbClientLine.Text.Substring(TbClientLine.Text.LastIndexOf(':') + 1);
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetText(Key);
                }
                catch (Exception ex)
                {
                    Err("Cannot copy text to clipboard. This usually happens when the clipboard is locked.\r\n" +
                    "Try to copy manually instead\r\n" +
                    $"Error: {ex.Message}", "Clipboard");
                    TbClientLine.Focus();
                    if (!CbHideClientValues.Checked)
                    {
                        TbClientLine.Select(TbClientConfigLine.Text.Length - Key.Length, Key.Length);
                    }
                    return;
                }
                Info("Client key copied to clipboard.\r\n" +
                    "Paste it into another application, then click [OK] to erase it from the clipboard", "Client key");
                try
                {
                    Clipboard.Clear();
                }
                catch (Exception ex)
                {
                    Err("Cannot clear clipboard.\r\n" +
                    $"Error: {ex.Message}", "Clipboard");
                }
            }
        }

        private void BtnCopyServerLine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbServerLine.Text))
            {
                Err("Please generate or import a key first", "No key");
                return;
            }
            else
            {
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetText(TbServerLine.Text);
                }
                catch (Exception ex)
                {
                    Err("Cannot copy text to clipboard. This usually happens when the clipboard is locked.\r\n" +
                    "Try to copy manually instead\r\n" +
                    $"Error: {ex.Message}", "Clipboard");
                    TbClientLine.Focus();
                    TbServerLine.SelectAll();
                    return;
                }
                Info("Server line copied to clipboard. Send it to the .onion owner now.", "Server key");
            }
        }

        private void MnuNewKey_Click(object sender, EventArgs e)
        {
            GenerateKey();
        }

        private void MnuOpenKey_Click(object sender, EventArgs e)
        {
            ImportPrivateKey();
        }

        private void MnuSaveKey_Click(object sender, EventArgs e)
        {
            SavePrivateKey();
        }

        private void MnuExportPublic_Click(object sender, EventArgs e)
        {
            SaveServerKey();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Cancellable = new CloseReason[]
            {
                CloseReason.None,
                CloseReason.UserClosing,
                CloseReason.ApplicationExitCall
            };
            if (unsavedChanges)
            {
                switch (Warn("Current key has not been saved yet. Save key before exiting?", "Unsaved changes", Cancellable.Contains(e.CloseReason) ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        e.Cancel = !SavePrivateKey();
                        break;
                    case DialogResult.No:
                        //Do nothing
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
