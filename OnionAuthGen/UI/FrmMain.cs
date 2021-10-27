using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public partial class FrmMain : Form
    {
        private static readonly string ClientAuthBaseDir = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "tor_auth");

        private bool unsavedChanges = false;
        private OnionDetails CurrentKey = null;

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
    }
}
