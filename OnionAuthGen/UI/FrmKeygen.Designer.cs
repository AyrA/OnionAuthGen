
namespace OnionAuthGen
{
    partial class FrmKeygen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RbRandom = new System.Windows.Forms.RadioButton();
            this.RbPassword = new System.Windows.Forms.RadioButton();
            this.RbDesign = new System.Windows.Forms.RadioButton();
            this.TbOnion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblRandomOpt = new System.Windows.Forms.Label();
            this.TbKey = new System.Windows.Forms.TextBox();
            this.LblEnterPassword = new System.Windows.Forms.Label();
            this.LlRandomKey = new System.Windows.Forms.LinkLabel();
            this.LblKeyNumber = new System.Windows.Forms.Label();
            this.NudKeyNumber = new System.Windows.Forms.NumericUpDown();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CbHarderKey = new System.Windows.Forms.CheckBox();
            this.BtnNumberHelp = new System.Windows.Forms.Button();
            this.LblFieldNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NudKeyNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // RbRandom
            // 
            this.RbRandom.AutoSize = true;
            this.RbRandom.Checked = true;
            this.RbRandom.Location = new System.Drawing.Point(12, 79);
            this.RbRandom.Name = "RbRandom";
            this.RbRandom.Size = new System.Drawing.Size(85, 17);
            this.RbRandom.TabIndex = 2;
            this.RbRandom.TabStop = true;
            this.RbRandom.Text = "&Random key";
            this.RbRandom.UseVisualStyleBackColor = true;
            this.RbRandom.CheckedChanged += new System.EventHandler(this.RbRandom_CheckedChanged);
            // 
            // RbPassword
            // 
            this.RbPassword.AutoSize = true;
            this.RbPassword.Location = new System.Drawing.Point(12, 127);
            this.RbPassword.Name = "RbPassword";
            this.RbPassword.Size = new System.Drawing.Size(105, 17);
            this.RbPassword.TabIndex = 4;
            this.RbPassword.Text = "&Deterministic key";
            this.RbPassword.UseVisualStyleBackColor = true;
            this.RbPassword.CheckedChanged += new System.EventHandler(this.RbPassword_CheckedChanged);
            // 
            // RbDesign
            // 
            this.RbDesign.AutoSize = true;
            this.RbDesign.Location = new System.Drawing.Point(12, 288);
            this.RbDesign.Name = "RbDesign";
            this.RbDesign.Size = new System.Drawing.Size(113, 17);
            this.RbDesign.TabIndex = 13;
            this.RbDesign.Text = "&User designed key";
            this.RbDesign.UseVisualStyleBackColor = true;
            this.RbDesign.CheckedChanged += new System.EventHandler(this.RbDesign_CheckedChanged);
            // 
            // TbOnion
            // 
            this.TbOnion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbOnion.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TbOnion.Location = new System.Drawing.Point(12, 37);
            this.TbOnion.Name = "TbOnion";
            this.TbOnion.Size = new System.Drawing.Size(468, 20);
            this.TbOnion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = ".onion Domain";
            // 
            // LblRandomOpt
            // 
            this.LblRandomOpt.AutoSize = true;
            this.LblRandomOpt.Location = new System.Drawing.Point(9, 105);
            this.LblRandomOpt.Name = "LblRandomOpt";
            this.LblRandomOpt.Size = new System.Drawing.Size(237, 13);
            this.LblRandomOpt.TabIndex = 3;
            this.LblRandomOpt.Text = "There are no configurable options for this setting.";
            // 
            // TbKey
            // 
            this.TbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbKey.Location = new System.Drawing.Point(12, 175);
            this.TbKey.Name = "TbKey";
            this.TbKey.Size = new System.Drawing.Size(468, 20);
            this.TbKey.TabIndex = 6;
            // 
            // LblEnterPassword
            // 
            this.LblEnterPassword.AutoSize = true;
            this.LblEnterPassword.Location = new System.Drawing.Point(12, 153);
            this.LblEnterPassword.Name = "LblEnterPassword";
            this.LblEnterPassword.Size = new System.Drawing.Size(167, 13);
            this.LblEnterPassword.TabIndex = 5;
            this.LblEnterPassword.Text = "Enter the password or passphrase";
            // 
            // LlRandomKey
            // 
            this.LlRandomKey.AutoSize = true;
            this.LlRandomKey.Location = new System.Drawing.Point(12, 204);
            this.LlRandomKey.Name = "LlRandomKey";
            this.LlRandomKey.Size = new System.Drawing.Size(141, 13);
            this.LlRandomKey.TabIndex = 7;
            this.LlRandomKey.TabStop = true;
            this.LlRandomKey.Text = "Use 6 random words instead";
            this.LlRandomKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlRandomKey_LinkClicked);
            this.LlRandomKey.DoubleClick += new System.EventHandler(this.LlRandomKey_DoubleClick);
            // 
            // LblKeyNumber
            // 
            this.LblKeyNumber.AutoSize = true;
            this.LblKeyNumber.Location = new System.Drawing.Point(12, 229);
            this.LblKeyNumber.Name = "LblKeyNumber";
            this.LblKeyNumber.Size = new System.Drawing.Size(65, 13);
            this.LblKeyNumber.TabIndex = 8;
            this.LblKeyNumber.Text = "Key Number";
            // 
            // NudKeyNumber
            // 
            this.NudKeyNumber.Location = new System.Drawing.Point(83, 227);
            this.NudKeyNumber.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudKeyNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudKeyNumber.Name = "NudKeyNumber";
            this.NudKeyNumber.Size = new System.Drawing.Size(96, 20);
            this.NudKeyNumber.TabIndex = 9;
            this.NudKeyNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.Location = new System.Drawing.Point(324, 288);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 14;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(405, 288);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 15;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // CbHarderKey
            // 
            this.CbHarderKey.AutoSize = true;
            this.CbHarderKey.Checked = true;
            this.CbHarderKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbHarderKey.Location = new System.Drawing.Point(238, 229);
            this.CbHarderKey.Name = "CbHarderKey";
            this.CbHarderKey.Size = new System.Drawing.Size(242, 17);
            this.CbHarderKey.TabIndex = 11;
            this.CbHarderKey.Text = "Spend extra time to make key harder to guess";
            this.CbHarderKey.UseVisualStyleBackColor = true;
            // 
            // BtnNumberHelp
            // 
            this.BtnNumberHelp.Location = new System.Drawing.Point(185, 225);
            this.BtnNumberHelp.Name = "BtnNumberHelp";
            this.BtnNumberHelp.Size = new System.Drawing.Size(47, 23);
            this.BtnNumberHelp.TabIndex = 10;
            this.BtnNumberHelp.Text = "?";
            this.BtnNumberHelp.UseVisualStyleBackColor = true;
            this.BtnNumberHelp.Click += new System.EventHandler(this.BtnNumberHelp_Click);
            // 
            // LblFieldNote
            // 
            this.LblFieldNote.AutoSize = true;
            this.LblFieldNote.ForeColor = System.Drawing.Color.DarkRed;
            this.LblFieldNote.Location = new System.Drawing.Point(12, 256);
            this.LblFieldNote.Name = "LblFieldNote";
            this.LblFieldNote.Size = new System.Drawing.Size(332, 13);
            this.LblFieldNote.TabIndex = 12;
            this.LblFieldNote.Text = "Note: All fields need to be identical for the same key to be generated.";
            // 
            // FrmKeygen
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(492, 323);
            this.Controls.Add(this.LblFieldNote);
            this.Controls.Add(this.BtnNumberHelp);
            this.Controls.Add(this.CbHarderKey);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.NudKeyNumber);
            this.Controls.Add(this.LblKeyNumber);
            this.Controls.Add(this.LlRandomKey);
            this.Controls.Add(this.LblEnterPassword);
            this.Controls.Add(this.TbKey);
            this.Controls.Add(this.LblRandomOpt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbOnion);
            this.Controls.Add(this.RbDesign);
            this.Controls.Add(this.RbPassword);
            this.Controls.Add(this.RbRandom);
            this.Name = "FrmKeygen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Key Generator";
            ((System.ComponentModel.ISupportInitialize)(this.NudKeyNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbRandom;
        private System.Windows.Forms.RadioButton RbPassword;
        private System.Windows.Forms.RadioButton RbDesign;
        private System.Windows.Forms.TextBox TbOnion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblRandomOpt;
        private System.Windows.Forms.TextBox TbKey;
        private System.Windows.Forms.Label LblEnterPassword;
        private System.Windows.Forms.LinkLabel LlRandomKey;
        private System.Windows.Forms.Label LblKeyNumber;
        private System.Windows.Forms.NumericUpDown NudKeyNumber;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.CheckBox CbHarderKey;
        private System.Windows.Forms.Button BtnNumberHelp;
        private System.Windows.Forms.Label LblFieldNote;
    }
}