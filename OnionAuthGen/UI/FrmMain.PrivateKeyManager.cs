using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OnionAuthGen
{
    partial class FrmMain
    {
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
            foreach (var F in GetKeyFiles(Dir))
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
            //Use header size if list is empty
            LvPrivateKeys.AutoResizeColumns(LvPrivateKeys.Items.Count == 0 ? ColumnHeaderAutoResizeStyle.HeaderSize : ColumnHeaderAutoResizeStyle.ColumnContent);
            LvPrivateKeys.ResumeLayout();
            if (!PrivateDuplicateConflictMessageShown && Names.Count != Names.Distinct().Count())
            {
                PrivateDuplicateConflictMessageShown = true;
                Warn("You have private keys with duplicate names that only differ in their enabled state. " +
                    "You will not be able to enable/disable any of the duplicates until the name of at least one conflicting key is changed.", "Duplicate names");
            }
        }

        private string[] GetKeyFiles(string Dir, bool NameOnly = false)
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

        private PrivateKeyListEntry GetSelectedRow()
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

        private bool ShowRowSelectInfoDialog(PrivateKeyListEntry Row)
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
            var Row = GetSelectedRow();
            if (!ShowRowSelectInfoDialog(Row))
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
            var Row = GetSelectedRow();
            if (!ShowRowSelectInfoDialog(Row))
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
            var Row = GetSelectedRow();
            if (!ShowRowSelectInfoDialog(Row))
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
            var Row = GetSelectedRow();
            if (!ShowRowSelectInfoDialog(Row))
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
            var Row = GetSelectedRow();
            if (!ShowRowSelectInfoDialog(Row))
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

        private void CmsPrivateCopyPrivate_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedRow();
            if (!ShowRowSelectInfoDialog(Row))
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

        private void CmsPrivateCopyLine_Click(object sender, EventArgs e)
        {
            var Row = GetSelectedRow();
            if (!ShowRowSelectInfoDialog(Row))
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
    }
}
