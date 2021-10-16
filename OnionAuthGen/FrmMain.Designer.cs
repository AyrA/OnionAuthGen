
namespace OnionAuthGen
{
    partial class FrmMain
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
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbOnionName = new System.Windows.Forms.TextBox();
            this.TbFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbServerLine = new System.Windows.Forms.TextBox();
            this.TbClientLine = new System.Windows.Forms.TextBox();
            this.BtnSaveServer = new System.Windows.Forms.Button();
            this.BtnSaveClient = new System.Windows.Forms.Button();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.TbClientConfigLine = new System.Windows.Forms.TextBox();
            this.BtnCopyClientLine = new System.Windows.Forms.Button();
            this.BtnImportKey = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.LblKeyInfo = new System.Windows.Forms.Label();
            this.CbHideClientValues = new System.Windows.Forms.CheckBox();
            this.BtnCopyClientKey = new System.Windows.Forms.Button();
            this.BtnCopyServerLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGenerate.Location = new System.Drawing.Point(419, 74);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(158, 23);
            this.BtnGenerate.TabIndex = 5;
            this.BtnGenerate.Text = "&Generate new keypair";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = ".onion domain (required)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File name (optional)";
            // 
            // TbOnionName
            // 
            this.TbOnionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbOnionName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TbOnionName.Location = new System.Drawing.Point(138, 19);
            this.TbOnionName.Name = "TbOnionName";
            this.TbOnionName.Size = new System.Drawing.Size(439, 20);
            this.TbOnionName.TabIndex = 1;
            this.TbOnionName.Leave += new System.EventHandler(this.TbOnionName_Leave);
            // 
            // TbFileName
            // 
            this.TbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbFileName.Location = new System.Drawing.Point(138, 48);
            this.TbFileName.Name = "TbFileName";
            this.TbFileName.Size = new System.Drawing.Size(439, 20);
            this.TbFileName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server side configuration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Client side configuration";
            // 
            // TbServerLine
            // 
            this.TbServerLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbServerLine.Location = new System.Drawing.Point(12, 132);
            this.TbServerLine.Name = "TbServerLine";
            this.TbServerLine.ReadOnly = true;
            this.TbServerLine.Size = new System.Drawing.Size(425, 20);
            this.TbServerLine.TabIndex = 7;
            // 
            // TbClientLine
            // 
            this.TbClientLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbClientLine.Location = new System.Drawing.Point(12, 186);
            this.TbClientLine.Name = "TbClientLine";
            this.TbClientLine.ReadOnly = true;
            this.TbClientLine.Size = new System.Drawing.Size(425, 20);
            this.TbClientLine.TabIndex = 12;
            this.TbClientLine.UseSystemPasswordChar = true;
            // 
            // BtnSaveServer
            // 
            this.BtnSaveServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveServer.Location = new System.Drawing.Point(528, 130);
            this.BtnSaveServer.Name = "BtnSaveServer";
            this.BtnSaveServer.Size = new System.Drawing.Size(52, 23);
            this.BtnSaveServer.TabIndex = 9;
            this.BtnSaveServer.Text = "&Save";
            this.BtnSaveServer.UseVisualStyleBackColor = true;
            this.BtnSaveServer.Click += new System.EventHandler(this.BtnSaveServer_Click);
            // 
            // BtnSaveClient
            // 
            this.BtnSaveClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveClient.Location = new System.Drawing.Point(528, 184);
            this.BtnSaveClient.Name = "BtnSaveClient";
            this.BtnSaveClient.Size = new System.Drawing.Size(52, 23);
            this.BtnSaveClient.TabIndex = 14;
            this.BtnSaveClient.Text = "S&ave";
            this.BtnSaveClient.UseVisualStyleBackColor = true;
            this.BtnSaveClient.Click += new System.EventHandler(this.BtnSaveClient_Click);
            // 
            // SFD
            // 
            this.SFD.DefaultExt = "auth_private";
            this.SFD.Filter = "Authentication files|*.auth_private";
            // 
            // TbClientConfigLine
            // 
            this.TbClientConfigLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbClientConfigLine.Location = new System.Drawing.Point(12, 215);
            this.TbClientConfigLine.Name = "TbClientConfigLine";
            this.TbClientConfigLine.ReadOnly = true;
            this.TbClientConfigLine.Size = new System.Drawing.Size(510, 20);
            this.TbClientConfigLine.TabIndex = 15;
            // 
            // BtnCopyClientLine
            // 
            this.BtnCopyClientLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyClientLine.Location = new System.Drawing.Point(528, 213);
            this.BtnCopyClientLine.Name = "BtnCopyClientLine";
            this.BtnCopyClientLine.Size = new System.Drawing.Size(52, 23);
            this.BtnCopyClientLine.TabIndex = 16;
            this.BtnCopyClientLine.Text = "&Copy";
            this.BtnCopyClientLine.UseVisualStyleBackColor = true;
            this.BtnCopyClientLine.Click += new System.EventHandler(this.BtnCopyClientLine_Click);
            // 
            // BtnImportKey
            // 
            this.BtnImportKey.Location = new System.Drawing.Point(138, 74);
            this.BtnImportKey.Name = "BtnImportKey";
            this.BtnImportKey.Size = new System.Drawing.Size(158, 23);
            this.BtnImportKey.TabIndex = 4;
            this.BtnImportKey.Text = "&Import private key";
            this.BtnImportKey.UseVisualStyleBackColor = true;
            this.BtnImportKey.Click += new System.EventHandler(this.BtnImportKey_Click);
            // 
            // OFD
            // 
            this.OFD.DefaultExt = "auth_private";
            // 
            // LblKeyInfo
            // 
            this.LblKeyInfo.AutoSize = true;
            this.LblKeyInfo.Cursor = System.Windows.Forms.Cursors.Help;
            this.LblKeyInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.LblKeyInfo.Location = new System.Drawing.Point(12, 246);
            this.LblKeyInfo.Name = "LblKeyInfo";
            this.LblKeyInfo.Size = new System.Drawing.Size(335, 13);
            this.LblKeyInfo.TabIndex = 17;
            this.LblKeyInfo.Text = "Never share the client file with a .onion operator. Click for more details";
            this.LblKeyInfo.Click += new System.EventHandler(this.LblKeyInfo_Click);
            // 
            // CbHideClientValues
            // 
            this.CbHideClientValues.AutoSize = true;
            this.CbHideClientValues.Checked = true;
            this.CbHideClientValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbHideClientValues.Location = new System.Drawing.Point(138, 162);
            this.CbHideClientValues.Name = "CbHideClientValues";
            this.CbHideClientValues.Size = new System.Drawing.Size(48, 17);
            this.CbHideClientValues.TabIndex = 11;
            this.CbHideClientValues.Text = "&Hide";
            this.CbHideClientValues.UseVisualStyleBackColor = true;
            this.CbHideClientValues.CheckedChanged += new System.EventHandler(this.CbHideClientValues_CheckedChanged);
            // 
            // BtnCopyClientKey
            // 
            this.BtnCopyClientKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyClientKey.Location = new System.Drawing.Point(443, 184);
            this.BtnCopyClientKey.Name = "BtnCopyClientKey";
            this.BtnCopyClientKey.Size = new System.Drawing.Size(79, 23);
            this.BtnCopyClientKey.TabIndex = 13;
            this.BtnCopyClientKey.Text = "Copy &Key";
            this.BtnCopyClientKey.UseVisualStyleBackColor = true;
            this.BtnCopyClientKey.Click += new System.EventHandler(this.BtnCopyClientKey_Click);
            // 
            // BtnCopyServerLine
            // 
            this.BtnCopyServerLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyServerLine.Location = new System.Drawing.Point(443, 130);
            this.BtnCopyServerLine.Name = "BtnCopyServerLine";
            this.BtnCopyServerLine.Size = new System.Drawing.Size(79, 23);
            this.BtnCopyServerLine.TabIndex = 8;
            this.BtnCopyServerLine.Text = "Copy &Line";
            this.BtnCopyServerLine.UseVisualStyleBackColor = true;
            this.BtnCopyServerLine.Click += new System.EventHandler(this.BtnCopyServerLine_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 273);
            this.Controls.Add(this.CbHideClientValues);
            this.Controls.Add(this.LblKeyInfo);
            this.Controls.Add(this.BtnCopyServerLine);
            this.Controls.Add(this.BtnCopyClientKey);
            this.Controls.Add(this.BtnCopyClientLine);
            this.Controls.Add(this.BtnSaveClient);
            this.Controls.Add(this.BtnSaveServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TbClientConfigLine);
            this.Controls.Add(this.TbClientLine);
            this.Controls.Add(this.TbFileName);
            this.Controls.Add(this.TbServerLine);
            this.Controls.Add(this.TbOnionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnImportKey);
            this.Controls.Add(this.BtnGenerate);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FrmMain";
            this.Text = ".onion Authentication Generator";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FrmMain_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbOnionName;
        private System.Windows.Forms.TextBox TbFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbServerLine;
        private System.Windows.Forms.TextBox TbClientLine;
        private System.Windows.Forms.Button BtnSaveServer;
        private System.Windows.Forms.Button BtnSaveClient;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.TextBox TbClientConfigLine;
        private System.Windows.Forms.Button BtnCopyClientLine;
        private System.Windows.Forms.Button BtnImportKey;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Label LblKeyInfo;
        private System.Windows.Forms.CheckBox CbHideClientValues;
        private System.Windows.Forms.Button BtnCopyClientKey;
        private System.Windows.Forms.Button BtnCopyServerLine;
    }
}

