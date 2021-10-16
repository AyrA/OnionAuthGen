using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public partial class FrmMain : Form
    {
        private static readonly string ClientAuthBaseDir = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "tor_auth");
        public FrmMain()
        {
            InitializeComponent();
#if DEBUG
            FBD.SelectedPath = @"D:\Programs\Networking\TOR\Data\hidden\test\" + OnionGenerator.SERVER_DIR;
#endif
            Tools.ScaleForm(this);
        }

        #region Static Methods

        private static DialogResult Err(string Msg, string Title, MessageBoxButtons Buttons = MessageBoxButtons.OK)
        {
            return Dlg(Msg, Title, Buttons, MessageBoxIcon.Error);
        }

        private static DialogResult Warn(string Msg, string Title, MessageBoxButtons Buttons = MessageBoxButtons.OK)
        {
            return Dlg(Msg, Title, Buttons, MessageBoxIcon.Warning);
        }

        private static DialogResult Info(string Msg, string Title, MessageBoxButtons Buttons = MessageBoxButtons.OK)
        {
            return Dlg(Msg, Title, Buttons, MessageBoxIcon.Information);
        }

        private static DialogResult Dlg(string Msg, string Title, MessageBoxButtons Buttons, MessageBoxIcon Icon)
        {
            return MessageBox.Show(Msg, Title, Buttons, Icon);
        }

        private static string GetClientConfigLine(string FullFileName)
        {
            return "ClientOnionAuthDir " + Path.GetDirectoryName(FullFileName);
        }

        private static bool CheckFileName(string FileName)
        {
            if (string.IsNullOrWhiteSpace(FileName))
            {
                return false;
            }
            foreach (var C in Path.GetInvalidFileNameChars())
            {
                if (FileName.Contains(C.ToString()))
                {
                    Err($"Invalid character in file name: {C}", "Invalid file name");
                    return false;
                }
            }
            return true;
        }

        #endregion

        private void UpdateOnionBoxValue()
        {
            if (OnionGenerator.IsOnionName(TbOnionName.Text))
            {
                if (!TbOnionName.Text.EndsWith(".onion"))
                {
                    TbOnionName.Text += ".onion";
                }
                //Update existing client line if it's present
                if (!string.IsNullOrEmpty(TbClientLine.Text))
                {
                    var Existing = TbClientLine.Text.Split(':')[0];
                    if (
                        Existing + ".onion" != TbOnionName.Text &&
                        Info("You've already generated a client key. Do you want to update the onion name in the key to reflect the changes?", "Name update", MessageBoxButtons.YesNo) == DialogResult.Yes
                        )
                    {
                        TbClientLine.Text =
                            TbOnionName.Text.Substring(0, TbOnionName.Text.Length - 6) +
                            TbClientLine.Text.Substring(TbClientLine.Text.IndexOf(':'));
                    }
                }
            }
        }

        #region Event Handlers

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!OnionGenerator.IsOnionName(TbOnionName.Text))
            {
                Err("The onion name is invalid. Name must be 56 characters, with optional \".onion\" at the end.", "Invalid onion name");
                return;
            }
            if (
                (string.IsNullOrEmpty(TbClientLine.Text) && string.IsNullOrEmpty(TbServerLine.Text)) ||
                Warn("Keys have already been generated. Really create new keys?\r\n" +
                "\r\n" +
                "You will lose the currently shown keys forever unless you saved them already.", "Overwrite key", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var Keys = OnionGenerator.GenerateAuthentication(TbOnionName.Text);
                TbClientLine.Text = Keys.Client;
                TbServerLine.Text = Keys.Server;
            }
        }

        private void BtnSaveServer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbServerLine.Text))
            {
                Err("Please generate or import a key first", "No key");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbFileName.Text))
            {
                Err($"Please enter a file name (no path). Do not enter the '{OnionGenerator.SERVER_FILE_EXT}' extension or it will be duplicated", "Missing file name");
                return;
            }
            if (!CheckFileName(TbFileName.Text))
            {
                return;
            }

            FBD.Description = $"Select '{OnionGenerator.SERVER_DIR}' directory";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                var P = FBD.SelectedPath;
                if (
                    P.EndsWith(Path.DirectorySeparatorChar + OnionGenerator.SERVER_DIR) ||
                    Warn($"The directory with key files is normally called '{OnionGenerator.SERVER_DIR}'. Really pick a different directory?", "Possibly invalid path", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var HostnameFile = Path.Combine(Path.GetDirectoryName(P), "hostname");
                    if (File.Exists(HostnameFile))
                    {
                        var Hostname = File.ReadAllText(HostnameFile).Trim();
                        if (Hostname != TbOnionName.Text && Warn("The supplied onion name does not match the one in the 'hostname' file\r\n" +
                            $"Supplied: {TbOnionName.Text}\r\n" +
                            $"Detected: {Hostname}\r\n" +
                            "\r\n" +
                            "Continue?\r\n" +
                            "\r\n" +
                            "Note: This has no effect on the server, but the client will not be able to authenticate unless you fix the name", "onion name mismatch", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                var FileName = Path.Combine(P, TbFileName.Text + OnionGenerator.SERVER_FILE_EXT);
                if (
                    !File.Exists(FileName) ||
                    Warn($"'{FileName}' already exists.\r\n" +
                    "Really overwrite it and lose whatever key is already stored there?", "Overwrite key", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        File.WriteAllText(FileName, TbServerLine.Text);
                        Info("Authentication data saved sucessfully. Restart Tor if it's already running to enable the new authentication file.", "Server line saved");
                    }
                    catch (Exception ex)
                    {
                        Err("Could not write server auth data\r\n" +
                            $"Error: {ex.Message}", "Error saving file");
                    }
                }
            }
        }

        private void BtnSaveClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbClientLine.Text))
            {
                Err("Please generate or import a key first", "No key");
                return;
            }

            try
            {
                Directory.CreateDirectory(ClientAuthBaseDir);
                SFD.InitialDirectory = ClientAuthBaseDir;
            }
            catch
            {
                //Don't care
            }

            if (CheckFileName(TbFileName.Text))
            {
                SFD.FileName = TbFileName.Text + OnionGenerator.CLIENT_FILE_EXT;
            }
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(SFD.FileName, TbClientLine.Text);
                }
                catch (Exception ex)
                {
                    Err("Could not write client auth data\r\n" +
                        $"Error: {ex.Message}", "Error saving file");
                }
                TbClientConfigLine.Text = GetClientConfigLine(Path.GetFullPath(SFD.FileName));
            }
        }

        private void BtnCopyClientLine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbClientConfigLine.Text))
            {
                Err("Please save the client authentication file first.", "No configuration");
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
                    "Try to select and copy manually instead\r\n" +
                    $"Error: {ex.Message}", "Clipboard");
                TbClientConfigLine.Focus();
                TbClientConfigLine.SelectAll();
            }
        }

        private void TbOnionName_Leave(object sender, EventArgs e)
        {
            UpdateOnionBoxValue();
        }

        private void BtnImportKey_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TbServerLine.Text) || !string.IsNullOrEmpty(TbServerLine.Text))
            {
                if (Warn("Replace the key values currently loaded into the application?", "Existing key found", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            OFD.DefaultExt = SFD.DefaultExt;
            OFD.Filter = SFD.Filter;
            try
            {
                Directory.CreateDirectory(ClientAuthBaseDir);
                OFD.InitialDirectory = ClientAuthBaseDir;
            }
            catch
            {
                //Don't care
            }
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                string Line;
                try
                {
                    Line = File.ReadAllText(OFD.FileName).Trim();
                    var Segments = Line.Split(':');
                    if (Segments.Length != 4)
                    {
                        throw new InvalidDataException("Client configuration string invalid. Not consisting of 4 parts");
                    }
                    if (!OnionGenerator.IsOnionName(Segments[0]))
                    {
                        throw new InvalidDataException("Client configuration string invalid. Invalid onion name");
                    }
                    var Params = OnionGenerator.GenerateFromClientLine(Line);
                    TbOnionName.Text = Segments[0];
                    TbFileName.Text = Path.GetFileNameWithoutExtension(OFD.FileName);
                    TbServerLine.Text = Params.Server;
                    TbClientLine.Text = Params.Client;
                    TbClientConfigLine.Text = GetClientConfigLine(Path.GetFullPath(OFD.FileName));
                    UpdateOnionBoxValue();
                }
                catch (Exception ex)
                {
                    Err("Error loading key file\r\n" +
                        $"Error: {ex.Message}", "Error loading key file");
                    return;
                }
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

        #endregion

        private void FrmMain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            var f = Application.OpenForms.OfType<FrmHelp>().FirstOrDefault();
            if (f == null)
            {
                f = new FrmHelp();
            }
            f.Show();
            f.BringToFront();
            f.SetHelpArticle("Main Form");
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
                catch(Exception ex)
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
    }
}
