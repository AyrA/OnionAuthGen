using System;
using System.Collections.Generic;
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
            TbPrivateDirectory.Text = ClientAuthBaseDir;
            Tools.ScaleForm(this);
            ReloadPrivateKeys();
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

        private static bool AskKeyOverwrite()
        {
            return Warn("This action will replace the currently loaded private key which has not been saved yet.\r\n" +
                "\r\n" +
                "Continue and lose the unsaved key?", "Overwrite key", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        #endregion

        #region Generic Form Events

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

        #endregion

        #region Key Generator

        private bool unsavedChanges = false;
        private OnionDetails CurrentKey = null;

        private void SetKeyValues()
        {
            TbClientLine.Text = CurrentKey.Client;
            TbServerLine.Text = CurrentKey.Server;
        }

        private void GenerateKey()
        {
            if (!unsavedChanges || CurrentKey == null || AskKeyOverwrite())
            {
                using (var OnionForm = new FrmInput("Enter .onion domain", "Enter the .onion domain this key is for (with or without .onion)", null, true, OnionGenerator.GetValidationExpression()))
                {
                    if (OnionForm.ShowDialog() == DialogResult.OK)
                    {
                        CurrentKey = OnionGenerator.GenerateAuthentication(OnionForm.Value);
                        unsavedChanges = true;
                        SetKeyValues();
                    }
                }
            }
        }

        private bool SavePrivateKey()
        {
            if (CurrentKey == null)
            {
                Err("Please generate or import a key first", "No key");
                return false;
            }

            try
            {
                Directory.CreateDirectory(ClientAuthBaseDir);
                SFD.InitialDirectory = TbPrivateDirectory.Text;
            }
            catch
            {
                //Don't care
            }

            string SelectedName = CurrentKey.Onion;
            SFD.FileName = SelectedName + OnionGenerator.CLIENT_FILE_EXT;
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
                    return false;
                }
                TbClientConfigLine.Text = GetClientConfigLine(Path.GetFullPath(SFD.FileName));
                unsavedChanges = false;
                return true;
            }
            return false;
        }

        private string AskFileName(string ExistingValue = null)
        {
            string SelectedName = null;

            //Invalid characters in a file name
            var InvalidRegexChars = Path.GetInvalidFileNameChars()
                .Concat(Path.GetInvalidPathChars())
                .Concat(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar })
                .Distinct()
                .ToArray();
            //For display purposes, exclude control characters.
            var InvalidDisplayChars = string.Concat(InvalidRegexChars.Where(m => m > 0x1F).Distinct());
            var Disallowed = new System.Text.RegularExpressions.Regex("^[^" + System.Text.RegularExpressions.Regex.Escape(string.Concat(InvalidRegexChars)) + "]+$");
            do
            {
                using (var NameForm = new FrmInput("Enter a name", $"Enter a name for the key (must be valid file name. Disallowed symbols: {InvalidDisplayChars})", SelectedName == null ? ExistingValue : SelectedName, true, Disallowed))
                {
                    if (NameForm.ShowDialog() == DialogResult.Cancel)
                    {
                        return null;
                    }
                    SelectedName = NameForm.Value;
                }
            } while (!CheckFileName(SelectedName));
            return SelectedName;
        }

        private bool ImportPrivateKey()
        {
            if (unsavedChanges && !AskKeyOverwrite())
            {
                return false;
            }
            OFD.DefaultExt = SFD.DefaultExt;
            OFD.Filter = SFD.Filter;
            try
            {
                Directory.CreateDirectory(ClientAuthBaseDir);
                OFD.InitialDirectory = TbPrivateDirectory.Text;
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
                    CurrentKey = OnionGenerator.GenerateFromClientLine(Line);
                    SetKeyValues();
                    TbClientConfigLine.Text = GetClientConfigLine(Path.GetFullPath(OFD.FileName));
                    unsavedChanges = false;
                    return true;
                }
                catch (Exception ex)
                {
                    Err("Error loading key file\r\n" +
                        $"Error: {ex.Message}", "Error loading key file");
                }
            }
            return false;
        }

        private bool SaveServerKey()
        {
            if (CurrentKey == null)
            {
                Err("Please generate or import a key first", "No key");
                return false;
            }
            FBD.Description = $"Select '{OnionGenerator.SERVER_DIR}' directory";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                var P = FBD.SelectedPath;
                if (
                    P.EndsWith(Path.DirectorySeparatorChar + OnionGenerator.SERVER_DIR) ||
                    Warn($"The directory with key files is normally called '{OnionGenerator.SERVER_DIR}'. Really pick a different directory?", "Possibly invalid path", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string SelectedName = AskFileName();
                    if (SelectedName == null)
                    {
                        Warn("Operation cancelled by user. Key not saved", "Operation cancelled");
                        return false;
                    }
                    var FileName = Path.Combine(P, SelectedName + OnionGenerator.SERVER_FILE_EXT);
                    if (
                        !File.Exists(FileName) ||
                        Warn($"'{FileName}' already exists.\r\n" +
                        "Really overwrite it and lose whatever key is already stored there?", "Overwrite key", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            File.WriteAllText(FileName, TbServerLine.Text);
                            Info("Authentication data saved sucessfully. Restart Tor if it's already running to enable the new authentication file.", "Server line saved");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Err("Could not write server auth data\r\n" +
                                $"Error: {ex.Message}", "Error saving file");
                        }

                    }
                }
            }
            return false;
        }

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

        #endregion

        #region Private Key Manager

        private class PrivateKeyListEntry
        {
            public string FileName;
            public OnionDetails Details;
        }
        private static readonly string[] privateKeyExt = new string[]
        {
            OnionGenerator.CLIENT_FILE_EXT,
            ".auth_disabled"
        };

        private bool PrivateDuplicateConflictMessageShown = false;

        private void ReloadPrivateKeys()
        {
            LvPrivateKeys.SuspendLayout();
            LvPrivateKeys.Items.Clear();
            var Dir = TbPrivateDirectory.Text;
            var Names = new List<string>();
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(TbPrivateDirectory.Text = ClientAuthBaseDir);
                Dir = TbPrivateDirectory.Text;
            }
            foreach (var F in GetPrivateKeyFiles(Dir))
            {
                var Enabled = Path.GetExtension(F).ToLower() == OnionGenerator.CLIENT_FILE_EXT;
                try
                {
                    var Line = File.ReadAllLines(F)[0].Split(':');
                    if (Line.Length == 4 && OnionGenerator.IsOnionName(Line[0]))
                    {
                        var Item = LvPrivateKeys.Items.Add(Path.GetFileNameWithoutExtension(F));
                        Names.Add(Item.Text.ToLower());
                        Item.Tag = F;
                        for (var i = 0; i < 3; i++)
                        {
                            Item.SubItems.Add(Line[i]);
                        }
                        Item.SubItems.Add(Enabled ? "Yes" : "No");
                    }
                }
                catch
                {

                }
            }
            //Using header size actually takes visible rows into account too despite the name
            LvPrivateKeys.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            LvPrivateKeys.ResumeLayout();
            if (!PrivateDuplicateConflictMessageShown && Names.Count != Names.Distinct().Count())
            {
                PrivateDuplicateConflictMessageShown = true;
                Warn("You have private keys with duplicate names that only differ in their enabled state. " +
                    "You will not be able to enable/disable any of the duplicates until the name of at least one conflicting key is changed.", "Duplicate names");
            }
        }

        private string[] GetPrivateKeyFiles(string Dir, bool NameOnly = false)
        {
            var Ret = new List<string>();
            foreach (var F in Directory.GetFiles(Dir))
            {
                if (privateKeyExt.Contains(Path.GetExtension(F).ToLower()))
                {
                    Ret.Add(NameOnly ? Path.GetFileName(F) : F);
                }
            }
            return Ret.ToArray();
        }

        private PrivateKeyListEntry GetSelectedPrivateRow()
        {
            if (LvPrivateKeys.SelectedItems.Count > 0)
            {
                var Ret = new PrivateKeyListEntry();
                Ret.FileName = (string)LvPrivateKeys.SelectedItems[0].Tag;
                try
                {
                    Ret.Details = OnionGenerator.GenerateFromClientLine(File.ReadAllText(Ret.FileName).Trim());
                }
                catch
                {

                }
                return Ret;
            }
            return null;
        }

        private bool ShowPrivateRowSelectInfoDialog(PrivateKeyListEntry Row)
        {
            if (Row == null)
            {
                Err("Please select an entry first", Text);
                return false;
            }
            else if (Row.Details == null)
            {
                Err("The key cannot be read at this time. File may be gone or in exclusive use.", Text);
                ReloadPrivateKeys();
                return false;
            }
            return true;
        }

        private void TbPrivateDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (Directory.Exists(TbPrivateDirectory.Text))
                {
                    ReloadPrivateKeys();
                }
                else
                {
                    if (Err("Directory invalid. Use the default instead?", "Invalid directory", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Directory.CreateDirectory(TbPrivateDirectory.Text = ClientAuthBaseDir);
                        ReloadPrivateKeys();
                    }
                }
            }
        }

        private void CmsPrivateRename_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            var OldName = Path.GetFileNameWithoutExtension(Row.FileName);
            string NewName = AskFileName(OldName);
            //Exit silently if not renaming
            if (NewName == OldName || string.IsNullOrEmpty(NewName))
            {
                return;
            }
            NewName = Path.Combine(Path.GetDirectoryName(Row.FileName), NewName + Path.GetExtension(Row.FileName));
            if (File.Exists(NewName))
            {
                Err("A key with this name already exists", "Duplicate name");
            }
            try
            {
                File.Move(Row.FileName, NewName);
                ReloadPrivateKeys();
            }
            catch (Exception ex)
            {
                Err($"Cannot rename key. {ex.Message}", "Key rename failed");
            }
        }

        private void CmsPrivateChangeOnion_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            var Onion = Row.Details.Onion;
            using (var Dlg = new FrmInput("Change .onion name", "Enter a new onion domain. With or without \".onion\"", Onion, true, OnionGenerator.GetValidationExpression()))
            {
                if (Dlg.ShowDialog() == DialogResult.OK && Onion != OnionGenerator.NormalizeOnion(Dlg.Value))
                {
                    Onion = OnionGenerator.NormalizeOnion(Dlg.Value);
                }
                else
                {
                    return;
                }
            }
            Row.Details.Onion = Onion;
            try
            {
                File.WriteAllText(Row.FileName, Row.Details.Client);
            }
            catch (Exception ex)
            {
                Err($"Cannot write to {Path.GetFileName(Row.FileName)}. {ex.Message}", "Cannot write key data");
                return;
            }
            ReloadPrivateKeys();
        }

        private void CmsPrivateDuplicate_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            var OldName = Path.GetFileNameWithoutExtension(Row.FileName);
            string NewName = AskFileName(OldName);
            //Exit silently if not renaming
            if (NewName == OldName || string.IsNullOrEmpty(NewName))
            {
                return;
            }
            NewName = Path.Combine(Path.GetDirectoryName(Row.FileName), NewName + Path.GetExtension(Row.FileName));
            if (File.Exists(NewName))
            {
                Err("A key with this name already exists", "Duplicate name");
            }
            try
            {
                File.Copy(Row.FileName, NewName);
                ReloadPrivateKeys();
            }
            catch (Exception ex)
            {
                Err($"Cannot copy key. {ex.Message}", "Key copy failed");
            }
        }

        private void CmsPrivateEnable_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            string NewName;
            if (Row.FileName.ToLower().EndsWith(OnionGenerator.CLIENT_FILE_EXT))
            {
                NewName = Path.ChangeExtension(Row.FileName, ".auth_disabled");
            }
            else
            {
                NewName = Path.ChangeExtension(Row.FileName, OnionGenerator.CLIENT_FILE_EXT);
            }
            try
            {
                File.Move(Row.FileName, NewName);
                ReloadPrivateKeys();
            }
            catch (Exception ex)
            {
                Err($"Cannot change key state. {ex.Message}", "Key state change failed");
            }
        }

        private void CmsPrivateDelete_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            if (Warn("Really delete the given private key? This cannot be undone.", "Delete private key", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                File.Delete(Row.FileName);
                ReloadPrivateKeys();
            }
            catch (Exception ex)
            {
                Err($"Cannot delete the selected key. {ex.Message}", "Key delete failed");
            }
        }

        private void CmsPrivateCopyPrivateKey_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(Row.Details.Client.Split(':').Last());
            }
            catch (Exception ex)
            {
                Err($"Cannot copy the selected key. {ex.Message}", "Clipboard access failed");
            }
        }

        private void CmsPrivateCopyPrivateLine_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(Row.Details.Client);
            }
            catch (Exception ex)
            {
                Err($"Cannot copy the selected key line. {ex.Message}", "Clipboard access failed");
            }
        }

        private void CmsPrivateCopyPublicKey_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(Row.Details.Server.Split(':').Last());
            }
            catch (Exception ex)
            {
                Err($"Cannot copy the selected key. {ex.Message}", "Clipboard access failed");
            }
        }

        private void CmsPrivateCopyPublicLine_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPrivateRow();
            if (!ShowPrivateRowSelectInfoDialog(Row))
            {
                return;
            }
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(Row.Details.Server);
            }
            catch (Exception ex)
            {
                Err($"Cannot copy the selected key. {ex.Message}", "Clipboard access failed");
            }
        }

        private void BtnSelectPrivateDirectory_Click(object sender, EventArgs e)
        {
            var Desc = FBD.Description;
            FBD.Description = "Select local key directory";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                TbPrivateDirectory.Text = FBD.SelectedPath;
                ReloadPrivateKeys();
            }
            FBD.Description = Desc;
        }

        #endregion

        #region Public Key Manager

        private static readonly string[] publicKeyExt = new string[]
        {
            OnionGenerator.SERVER_FILE_EXT,
            ".auth_disabled"
        };

        private bool PublicDuplicateConflictMessageShown = false;

        private IEnumerable<string> GetPublicKeyFiles(string Dir)
        {
            foreach (var F in Directory.GetFiles(Dir))
            {
                if (publicKeyExt.Contains(Path.GetExtension(F).ToLower()))
                {
                    yield return F;
                }
            }
        }

        private void ReloadPublicKeys()
        {
            LvPublicKeys.SuspendLayout();
            LvPublicKeys.Items.Clear();
            if (!string.IsNullOrEmpty(TbPublicDirectory.Text))
            {
                var Dir = TbPublicDirectory.Text;
                var Names = new List<string>();
                foreach (var F in GetPublicKeyFiles(Dir))
                {
                    var Enabled = Path.GetExtension(F).ToLower() == OnionGenerator.SERVER_FILE_EXT;
                    try
                    {
                        var Line = File.ReadAllLines(F)[0].Split(':');
                        if (Line.Length == 3)
                        {
                            var Item = LvPublicKeys.Items.Add(Path.GetFileNameWithoutExtension(F));
                            Names.Add(Item.Text.ToLower());
                            Item.Tag = F;
                            Item.SubItems.Add(Line[0]);
                            Item.SubItems.Add(Line[1]);
                            Item.SubItems.Add(Enabled ? "Yes" : "No");
                        }
                    }
                    catch
                    {

                    }
                }
                if (!PublicDuplicateConflictMessageShown && Names.Count != Names.Distinct().Count())
                {
                    PublicDuplicateConflictMessageShown = true;
                    Warn("You have public keys with duplicate names that only differ in their enabled state. " +
                        "You will not be able to enable/disable any of the duplicates until the name of at least one conflicting key is changed.", "Duplicate names");
                }
            }
            //Using header size actually takes visible rows into account too despite the name
            LvPublicKeys.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            LvPublicKeys.ResumeLayout();
        }

        private string GetSelectedPublicRow()
        {
            if (LvPublicKeys.SelectedItems.Count == 1)
            {
                return (string)LvPublicKeys.SelectedItems[0].Tag;
            }
            return null;
        }

        private bool ShowPublicRowSelectInfoDialog(string FileName)
        {
            if (FileName == null)
            {
                Err("Please select an entry first", Text);
                return false;
            }
            try
            {
                File.ReadAllText(FileName);
            }
            catch
            {
                Err("The key cannot be read at this time. File may be gone or in exclusive use.", Text);
                ReloadPublicKeys();
                return false;
            }
            return true;
        }

        private void BtnSelectPublicDirectory_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                TbPublicDirectory.Text = FBD.SelectedPath;
                ReloadPublicKeys();
            }
        }

        private void TbPublicDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (Directory.Exists(TbPublicDirectory.Text))
                {
                    ReloadPublicKeys();
                }
                else
                {
                    Err("Directory cannot be found or accessed", "Invalid directory");
                }
            }
        }

        private void CmsPublicCopyPublicKey_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPublicRow();
            if (!ShowPublicRowSelectInfoDialog(Row))
            {
                return;
            }
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(File.ReadAllText(Row).Split(':').Last().Trim());
            }
            catch (Exception ex)
            {
                Err($"Cannot copy the selected key. {ex.Message}", "Clipboard access failed");
            }
        }

        private void CmsPublicCopyPublicLine_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPublicRow();
            if (!ShowPublicRowSelectInfoDialog(Row))
            {
                return;
            }
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(File.ReadAllText(Row).Trim());
            }
            catch (Exception ex)
            {
                Err($"Cannot copy the selected key. {ex.Message}", "Clipboard access failed");
            }
        }

        private void CmsPublicRename_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedPublicRow();
            if (!ShowPublicRowSelectInfoDialog(Row))
            {
                return;
            }
            var OldName = Path.GetFileNameWithoutExtension(Row);
            string NewName = AskFileName(OldName);
            //Exit silently if not renaming
            if (NewName == OldName || string.IsNullOrEmpty(NewName))
            {
                return;
            }
            NewName = Path.Combine(Path.GetDirectoryName(Row), NewName + Path.GetExtension(Row));
            if (File.Exists(NewName))
            {
                Err("A key with this name already exists", "Duplicate name");
            }
            try
            {
                File.Move(Row, NewName);
                ReloadPublicKeys();
            }
            catch (Exception ex)
            {
                Err($"Cannot rename key. {ex.Message}", "Key rename failed");
            }
        }

        private void CmsPublicEnable_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CmsPublicDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
