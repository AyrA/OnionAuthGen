
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
            this.components = new System.ComponentModel.Container();
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
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.LblKeyInfo = new System.Windows.Forms.Label();
            this.CbHideClientValues = new System.Windows.Forms.CheckBox();
            this.BtnCopyClientKey = new System.Windows.Forms.Button();
            this.BtnCopyServerLine = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNewKey = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOpenKey = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSaveKey = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExportPublic = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.TabKeyDetails = new System.Windows.Forms.TabPage();
            this.TabPrivateKeys = new System.Windows.Forms.TabPage();
            this.BtnSelectPrivateDirectory = new System.Windows.Forms.Button();
            this.TbPrivateDirectory = new System.Windows.Forms.TextBox();
            this.LvPrivateKeys = new System.Windows.Forms.ListView();
            this.ChPrivateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrivateOnion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrivateType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrivateAlg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrivateEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CmsPrivate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmsPrivateCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateCopyPrivate = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateCopyPrivateKey = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateCopyPrivateLine = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateCopyPublic = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateCopyPublicKey = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateCopyPublicLine = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateRename = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateChangeOnion = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPrivateDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPublicKeys = new System.Windows.Forms.TabPage();
            this.BtnSelectPublicDirectory = new System.Windows.Forms.Button();
            this.TbPublicDirectory = new System.Windows.Forms.TextBox();
            this.LvPublicKeys = new System.Windows.Forms.ListView();
            this.ChPublicName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChPublicType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChPublicAlgorithm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChPublicEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CmsPublic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPublicCopyPublicKey = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPublicCopyPublicLine = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPublicRename = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPublicEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsPublicDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.TabKeyDetails.SuspendLayout();
            this.TabPrivateKeys.SuspendLayout();
            this.CmsPrivate.SuspendLayout();
            this.TabPublicKeys.SuspendLayout();
            this.CmsPublic.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server side configuration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Client side configuration";
            // 
            // TbServerLine
            // 
            this.TbServerLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbServerLine.Location = new System.Drawing.Point(6, 34);
            this.TbServerLine.Name = "TbServerLine";
            this.TbServerLine.ReadOnly = true;
            this.TbServerLine.Size = new System.Drawing.Size(405, 20);
            this.TbServerLine.TabIndex = 1;
            // 
            // TbClientLine
            // 
            this.TbClientLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbClientLine.Location = new System.Drawing.Point(6, 88);
            this.TbClientLine.Name = "TbClientLine";
            this.TbClientLine.ReadOnly = true;
            this.TbClientLine.Size = new System.Drawing.Size(405, 20);
            this.TbClientLine.TabIndex = 6;
            this.TbClientLine.UseSystemPasswordChar = true;
            // 
            // BtnSaveServer
            // 
            this.BtnSaveServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveServer.Location = new System.Drawing.Point(502, 32);
            this.BtnSaveServer.Name = "BtnSaveServer";
            this.BtnSaveServer.Size = new System.Drawing.Size(52, 23);
            this.BtnSaveServer.TabIndex = 3;
            this.BtnSaveServer.Text = "&Save";
            this.BtnSaveServer.UseVisualStyleBackColor = true;
            this.BtnSaveServer.Click += new System.EventHandler(this.BtnSaveServer_Click);
            // 
            // BtnSaveClient
            // 
            this.BtnSaveClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveClient.Location = new System.Drawing.Point(502, 86);
            this.BtnSaveClient.Name = "BtnSaveClient";
            this.BtnSaveClient.Size = new System.Drawing.Size(52, 23);
            this.BtnSaveClient.TabIndex = 8;
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
            this.TbClientConfigLine.Location = new System.Drawing.Point(6, 122);
            this.TbClientConfigLine.Name = "TbClientConfigLine";
            this.TbClientConfigLine.ReadOnly = true;
            this.TbClientConfigLine.Size = new System.Drawing.Size(490, 20);
            this.TbClientConfigLine.TabIndex = 9;
            // 
            // BtnCopyClientLine
            // 
            this.BtnCopyClientLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyClientLine.Location = new System.Drawing.Point(502, 120);
            this.BtnCopyClientLine.Name = "BtnCopyClientLine";
            this.BtnCopyClientLine.Size = new System.Drawing.Size(52, 23);
            this.BtnCopyClientLine.TabIndex = 10;
            this.BtnCopyClientLine.Text = "&Copy";
            this.BtnCopyClientLine.UseVisualStyleBackColor = true;
            this.BtnCopyClientLine.Click += new System.EventHandler(this.BtnCopyClientLine_Click);
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
            this.LblKeyInfo.Location = new System.Drawing.Point(6, 158);
            this.LblKeyInfo.Name = "LblKeyInfo";
            this.LblKeyInfo.Size = new System.Drawing.Size(335, 13);
            this.LblKeyInfo.TabIndex = 11;
            this.LblKeyInfo.Text = "Never share the client file with a .onion operator. Click for more details";
            this.LblKeyInfo.Click += new System.EventHandler(this.LblKeyInfo_Click);
            // 
            // CbHideClientValues
            // 
            this.CbHideClientValues.AutoSize = true;
            this.CbHideClientValues.Checked = true;
            this.CbHideClientValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbHideClientValues.Location = new System.Drawing.Point(132, 64);
            this.CbHideClientValues.Name = "CbHideClientValues";
            this.CbHideClientValues.Size = new System.Drawing.Size(48, 17);
            this.CbHideClientValues.TabIndex = 5;
            this.CbHideClientValues.Text = "&Hide";
            this.CbHideClientValues.UseVisualStyleBackColor = true;
            this.CbHideClientValues.CheckedChanged += new System.EventHandler(this.CbHideClientValues_CheckedChanged);
            // 
            // BtnCopyClientKey
            // 
            this.BtnCopyClientKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyClientKey.Location = new System.Drawing.Point(417, 86);
            this.BtnCopyClientKey.Name = "BtnCopyClientKey";
            this.BtnCopyClientKey.Size = new System.Drawing.Size(79, 23);
            this.BtnCopyClientKey.TabIndex = 7;
            this.BtnCopyClientKey.Text = "Copy &Key";
            this.BtnCopyClientKey.UseVisualStyleBackColor = true;
            this.BtnCopyClientKey.Click += new System.EventHandler(this.BtnCopyClientKey_Click);
            // 
            // BtnCopyServerLine
            // 
            this.BtnCopyServerLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyServerLine.Location = new System.Drawing.Point(417, 32);
            this.BtnCopyServerLine.Name = "BtnCopyServerLine";
            this.BtnCopyServerLine.Size = new System.Drawing.Size(79, 23);
            this.BtnCopyServerLine.TabIndex = 2;
            this.BtnCopyServerLine.Text = "Copy &Line";
            this.BtnCopyServerLine.UseVisualStyleBackColor = true;
            this.BtnCopyServerLine.Click += new System.EventHandler(this.BtnCopyServerLine_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(592, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuNewKey,
            this.MnuOpenKey,
            this.MnuSaveKey,
            this.MnuExportPublic,
            this.MnuSeparator,
            this.MnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // MnuNewKey
            // 
            this.MnuNewKey.Name = "MnuNewKey";
            this.MnuNewKey.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MnuNewKey.Size = new System.Drawing.Size(191, 22);
            this.MnuNewKey.Text = "&New key";
            this.MnuNewKey.Click += new System.EventHandler(this.MnuNewKey_Click);
            // 
            // MnuOpenKey
            // 
            this.MnuOpenKey.Name = "MnuOpenKey";
            this.MnuOpenKey.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MnuOpenKey.Size = new System.Drawing.Size(191, 22);
            this.MnuOpenKey.Text = "&Open private key";
            this.MnuOpenKey.Click += new System.EventHandler(this.MnuOpenKey_Click);
            // 
            // MnuSaveKey
            // 
            this.MnuSaveKey.Name = "MnuSaveKey";
            this.MnuSaveKey.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MnuSaveKey.Size = new System.Drawing.Size(191, 22);
            this.MnuSaveKey.Text = "&Save private key";
            this.MnuSaveKey.Click += new System.EventHandler(this.MnuSaveKey_Click);
            // 
            // MnuExportPublic
            // 
            this.MnuExportPublic.Name = "MnuExportPublic";
            this.MnuExportPublic.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MnuExportPublic.Size = new System.Drawing.Size(191, 22);
            this.MnuExportPublic.Text = "&Export public key";
            this.MnuExportPublic.Click += new System.EventHandler(this.MnuExportPublic_Click);
            // 
            // MnuSeparator
            // 
            this.MnuSeparator.Name = "MnuSeparator";
            this.MnuSeparator.Size = new System.Drawing.Size(188, 6);
            // 
            // MnuExit
            // 
            this.MnuExit.Name = "MnuExit";
            this.MnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.MnuExit.Size = new System.Drawing.Size(191, 22);
            this.MnuExit.Text = "E&xit";
            this.MnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.TabKeyDetails);
            this.Tabs.Controls.Add(this.TabPrivateKeys);
            this.Tabs.Controls.Add(this.TabPublicKeys);
            this.Tabs.Location = new System.Drawing.Point(12, 39);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(568, 228);
            this.Tabs.TabIndex = 1;
            // 
            // TabKeyDetails
            // 
            this.TabKeyDetails.Controls.Add(this.label3);
            this.TabKeyDetails.Controls.Add(this.CbHideClientValues);
            this.TabKeyDetails.Controls.Add(this.TbServerLine);
            this.TabKeyDetails.Controls.Add(this.LblKeyInfo);
            this.TabKeyDetails.Controls.Add(this.TbClientLine);
            this.TabKeyDetails.Controls.Add(this.BtnCopyServerLine);
            this.TabKeyDetails.Controls.Add(this.TbClientConfigLine);
            this.TabKeyDetails.Controls.Add(this.BtnCopyClientKey);
            this.TabKeyDetails.Controls.Add(this.label4);
            this.TabKeyDetails.Controls.Add(this.BtnCopyClientLine);
            this.TabKeyDetails.Controls.Add(this.BtnSaveServer);
            this.TabKeyDetails.Controls.Add(this.BtnSaveClient);
            this.TabKeyDetails.Location = new System.Drawing.Point(4, 22);
            this.TabKeyDetails.Name = "TabKeyDetails";
            this.TabKeyDetails.Padding = new System.Windows.Forms.Padding(3);
            this.TabKeyDetails.Size = new System.Drawing.Size(560, 202);
            this.TabKeyDetails.TabIndex = 0;
            this.TabKeyDetails.Text = "Key Details";
            // 
            // TabPrivateKeys
            // 
            this.TabPrivateKeys.Controls.Add(this.BtnSelectPrivateDirectory);
            this.TabPrivateKeys.Controls.Add(this.TbPrivateDirectory);
            this.TabPrivateKeys.Controls.Add(this.LvPrivateKeys);
            this.TabPrivateKeys.Location = new System.Drawing.Point(4, 22);
            this.TabPrivateKeys.Name = "TabPrivateKeys";
            this.TabPrivateKeys.Padding = new System.Windows.Forms.Padding(3);
            this.TabPrivateKeys.Size = new System.Drawing.Size(560, 202);
            this.TabPrivateKeys.TabIndex = 1;
            this.TabPrivateKeys.Text = "Private Keys";
            // 
            // BtnSelectPrivateDirectory
            // 
            this.BtnSelectPrivateDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectPrivateDirectory.Location = new System.Drawing.Point(479, 12);
            this.BtnSelectPrivateDirectory.Name = "BtnSelectPrivateDirectory";
            this.BtnSelectPrivateDirectory.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectPrivateDirectory.TabIndex = 1;
            this.BtnSelectPrivateDirectory.Text = "Select...";
            this.BtnSelectPrivateDirectory.UseVisualStyleBackColor = true;
            this.BtnSelectPrivateDirectory.Click += new System.EventHandler(this.BtnSelectPrivateDirectory_Click);
            // 
            // TbPrivateDirectory
            // 
            this.TbPrivateDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPrivateDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TbPrivateDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.TbPrivateDirectory.Location = new System.Drawing.Point(6, 14);
            this.TbPrivateDirectory.Name = "TbPrivateDirectory";
            this.TbPrivateDirectory.Size = new System.Drawing.Size(467, 20);
            this.TbPrivateDirectory.TabIndex = 0;
            this.TbPrivateDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbPrivateDirectory_KeyDown);
            // 
            // LvPrivateKeys
            // 
            this.LvPrivateKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvPrivateKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChPrivateName,
            this.chPrivateOnion,
            this.chPrivateType,
            this.chPrivateAlg,
            this.chPrivateEnabled});
            this.LvPrivateKeys.ContextMenuStrip = this.CmsPrivate;
            this.LvPrivateKeys.FullRowSelect = true;
            this.LvPrivateKeys.HideSelection = false;
            this.LvPrivateKeys.Location = new System.Drawing.Point(6, 53);
            this.LvPrivateKeys.MultiSelect = false;
            this.LvPrivateKeys.Name = "LvPrivateKeys";
            this.LvPrivateKeys.Size = new System.Drawing.Size(548, 143);
            this.LvPrivateKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LvPrivateKeys.TabIndex = 2;
            this.LvPrivateKeys.UseCompatibleStateImageBehavior = false;
            this.LvPrivateKeys.View = System.Windows.Forms.View.Details;
            // 
            // ChPrivateName
            // 
            this.ChPrivateName.Text = "Name";
            // 
            // chPrivateOnion
            // 
            this.chPrivateOnion.Text = ".onion";
            // 
            // chPrivateType
            // 
            this.chPrivateType.Text = "Type";
            // 
            // chPrivateAlg
            // 
            this.chPrivateAlg.Text = "Algorithm";
            // 
            // chPrivateEnabled
            // 
            this.chPrivateEnabled.Text = "Enabled";
            // 
            // CmsPrivate
            // 
            this.CmsPrivate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsPrivateCopy,
            this.CmsPrivateRename,
            this.CmsPrivateChangeOnion,
            this.CmsPrivateDuplicate,
            this.CmsPrivateEnable,
            this.CmsPrivateDelete});
            this.CmsPrivate.Name = "CmsPrivate";
            this.CmsPrivate.Size = new System.Drawing.Size(178, 136);
            // 
            // CmsPrivateCopy
            // 
            this.CmsPrivateCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsPrivateCopyPrivate,
            this.CmsPrivateCopyPublic});
            this.CmsPrivateCopy.Name = "CmsPrivateCopy";
            this.CmsPrivateCopy.Size = new System.Drawing.Size(177, 22);
            this.CmsPrivateCopy.Text = "C&opy";
            // 
            // CmsPrivateCopyPrivate
            // 
            this.CmsPrivateCopyPrivate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsPrivateCopyPrivateKey,
            this.CmsPrivateCopyPrivateLine});
            this.CmsPrivateCopyPrivate.Name = "CmsPrivateCopyPrivate";
            this.CmsPrivateCopyPrivate.Size = new System.Drawing.Size(107, 22);
            this.CmsPrivateCopyPrivate.Text = "&Private";
            // 
            // CmsPrivateCopyPrivateKey
            // 
            this.CmsPrivateCopyPrivateKey.Name = "CmsPrivateCopyPrivateKey";
            this.CmsPrivateCopyPrivateKey.Size = new System.Drawing.Size(120, 22);
            this.CmsPrivateCopyPrivateKey.Text = "&Key only";
            // 
            // CmsPrivateCopyPrivateLine
            // 
            this.CmsPrivateCopyPrivateLine.Name = "CmsPrivateCopyPrivateLine";
            this.CmsPrivateCopyPrivateLine.Size = new System.Drawing.Size(120, 22);
            this.CmsPrivateCopyPrivateLine.Text = "&Entire line";
            // 
            // CmsPrivateCopyPublic
            // 
            this.CmsPrivateCopyPublic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsPrivateCopyPublicKey,
            this.CmsPrivateCopyPublicLine});
            this.CmsPrivateCopyPublic.Name = "CmsPrivateCopyPublic";
            this.CmsPrivateCopyPublic.Size = new System.Drawing.Size(107, 22);
            this.CmsPrivateCopyPublic.Text = "&Public";
            // 
            // CmsPrivateCopyPublicKey
            // 
            this.CmsPrivateCopyPublicKey.Name = "CmsPrivateCopyPublicKey";
            this.CmsPrivateCopyPublicKey.Size = new System.Drawing.Size(120, 22);
            this.CmsPrivateCopyPublicKey.Text = "&Key only";
            this.CmsPrivateCopyPublicKey.Click += new System.EventHandler(this.CmsPrivateCopyPublicKey_Click);
            // 
            // CmsPrivateCopyPublicLine
            // 
            this.CmsPrivateCopyPublicLine.Name = "CmsPrivateCopyPublicLine";
            this.CmsPrivateCopyPublicLine.Size = new System.Drawing.Size(120, 22);
            this.CmsPrivateCopyPublicLine.Text = "&Entire line";
            this.CmsPrivateCopyPublicLine.Click += new System.EventHandler(this.CmsPrivateCopyPublicLine_Click);
            // 
            // CmsPrivateRename
            // 
            this.CmsPrivateRename.Name = "CmsPrivateRename";
            this.CmsPrivateRename.Size = new System.Drawing.Size(177, 22);
            this.CmsPrivateRename.Text = "&Rename";
            this.CmsPrivateRename.Click += new System.EventHandler(this.CmsPrivateRename_Click);
            // 
            // CmsPrivateChangeOnion
            // 
            this.CmsPrivateChangeOnion.Name = "CmsPrivateChangeOnion";
            this.CmsPrivateChangeOnion.Size = new System.Drawing.Size(177, 22);
            this.CmsPrivateChangeOnion.Text = "&Change onion domain";
            this.CmsPrivateChangeOnion.Click += new System.EventHandler(this.CmsPrivateChangeOnion_Click);
            // 
            // CmsPrivateDuplicate
            // 
            this.CmsPrivateDuplicate.Name = "CmsPrivateDuplicate";
            this.CmsPrivateDuplicate.Size = new System.Drawing.Size(177, 22);
            this.CmsPrivateDuplicate.Text = "&Duplicate";
            this.CmsPrivateDuplicate.Click += new System.EventHandler(this.CmsPrivateDuplicate_Click);
            // 
            // CmsPrivateEnable
            // 
            this.CmsPrivateEnable.Name = "CmsPrivateEnable";
            this.CmsPrivateEnable.Size = new System.Drawing.Size(177, 22);
            this.CmsPrivateEnable.Text = "&Enable/Disable";
            this.CmsPrivateEnable.Click += new System.EventHandler(this.CmsPrivateEnable_Click);
            // 
            // CmsPrivateDelete
            // 
            this.CmsPrivateDelete.Name = "CmsPrivateDelete";
            this.CmsPrivateDelete.Size = new System.Drawing.Size(177, 22);
            this.CmsPrivateDelete.Text = "De&lete";
            this.CmsPrivateDelete.Click += new System.EventHandler(this.CmsPrivateDelete_Click);
            // 
            // TabPublicKeys
            // 
            this.TabPublicKeys.Controls.Add(this.BtnSelectPublicDirectory);
            this.TabPublicKeys.Controls.Add(this.TbPublicDirectory);
            this.TabPublicKeys.Controls.Add(this.LvPublicKeys);
            this.TabPublicKeys.Location = new System.Drawing.Point(4, 22);
            this.TabPublicKeys.Name = "TabPublicKeys";
            this.TabPublicKeys.Size = new System.Drawing.Size(560, 202);
            this.TabPublicKeys.TabIndex = 2;
            this.TabPublicKeys.Text = "Public Keys";
            // 
            // BtnSelectPublicDirectory
            // 
            this.BtnSelectPublicDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectPublicDirectory.Location = new System.Drawing.Point(479, 12);
            this.BtnSelectPublicDirectory.Name = "BtnSelectPublicDirectory";
            this.BtnSelectPublicDirectory.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectPublicDirectory.TabIndex = 1;
            this.BtnSelectPublicDirectory.Text = "Select...";
            this.BtnSelectPublicDirectory.UseVisualStyleBackColor = true;
            this.BtnSelectPublicDirectory.Click += new System.EventHandler(this.BtnSelectPublicDirectory_Click);
            // 
            // TbPublicDirectory
            // 
            this.TbPublicDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPublicDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TbPublicDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.TbPublicDirectory.Location = new System.Drawing.Point(6, 14);
            this.TbPublicDirectory.Name = "TbPublicDirectory";
            this.TbPublicDirectory.Size = new System.Drawing.Size(467, 20);
            this.TbPublicDirectory.TabIndex = 0;
            this.TbPublicDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbPublicDirectory_KeyDown);
            // 
            // LvPublicKeys
            // 
            this.LvPublicKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvPublicKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChPublicName,
            this.ChPublicType,
            this.ChPublicAlgorithm,
            this.ChPublicEnabled});
            this.LvPublicKeys.ContextMenuStrip = this.CmsPublic;
            this.LvPublicKeys.FullRowSelect = true;
            this.LvPublicKeys.HideSelection = false;
            this.LvPublicKeys.Location = new System.Drawing.Point(6, 53);
            this.LvPublicKeys.MultiSelect = false;
            this.LvPublicKeys.Name = "LvPublicKeys";
            this.LvPublicKeys.Size = new System.Drawing.Size(548, 143);
            this.LvPublicKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LvPublicKeys.TabIndex = 2;
            this.LvPublicKeys.UseCompatibleStateImageBehavior = false;
            this.LvPublicKeys.View = System.Windows.Forms.View.Details;
            // 
            // ChPublicName
            // 
            this.ChPublicName.Text = "Name";
            // 
            // ChPublicType
            // 
            this.ChPublicType.Text = "Type";
            // 
            // ChPublicAlgorithm
            // 
            this.ChPublicAlgorithm.Text = "Algorithm";
            // 
            // ChPublicEnabled
            // 
            this.ChPublicEnabled.Text = "Enabled";
            // 
            // CmsPublic
            // 
            this.CmsPublic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.CmsPublicRename,
            this.CmsPublicEnable,
            this.CmsPublicDelete});
            this.CmsPublic.Name = "CmsPrivate";
            this.CmsPublic.Size = new System.Drawing.Size(181, 114);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsPublicCopyPublicKey,
            this.CmsPublicCopyPublicLine});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "C&opy";
            // 
            // CmsPublicCopyPublicKey
            // 
            this.CmsPublicCopyPublicKey.Name = "CmsPublicCopyPublicKey";
            this.CmsPublicCopyPublicKey.Size = new System.Drawing.Size(180, 22);
            this.CmsPublicCopyPublicKey.Text = "&Key";
            this.CmsPublicCopyPublicKey.Click += new System.EventHandler(this.CmsPublicCopyPublicKey_Click);
            // 
            // CmsPublicCopyPublicLine
            // 
            this.CmsPublicCopyPublicLine.Name = "CmsPublicCopyPublicLine";
            this.CmsPublicCopyPublicLine.Size = new System.Drawing.Size(180, 22);
            this.CmsPublicCopyPublicLine.Text = "&Entire Line";
            this.CmsPublicCopyPublicLine.Click += new System.EventHandler(this.CmsPublicCopyPublicLine_Click);
            // 
            // CmsPublicRename
            // 
            this.CmsPublicRename.Name = "CmsPublicRename";
            this.CmsPublicRename.Size = new System.Drawing.Size(180, 22);
            this.CmsPublicRename.Text = "&Rename";
            this.CmsPublicRename.Click += new System.EventHandler(this.CmsPublicRename_Click);
            // 
            // CmsPublicEnable
            // 
            this.CmsPublicEnable.Name = "CmsPublicEnable";
            this.CmsPublicEnable.Size = new System.Drawing.Size(180, 22);
            this.CmsPublicEnable.Text = "&Enable/Disable";
            this.CmsPublicEnable.Click += new System.EventHandler(this.CmsPublicEnable_Click);
            // 
            // CmsPublicDelete
            // 
            this.CmsPublicDelete.Name = "CmsPublicDelete";
            this.CmsPublicDelete.Size = new System.Drawing.Size(180, 22);
            this.CmsPublicDelete.Text = "De&lete";
            this.CmsPublicDelete.Click += new System.EventHandler(this.CmsPublicDelete_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 279);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FrmMain";
            this.Text = ".onion Authentication Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FrmMain_HelpRequested);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.TabKeyDetails.ResumeLayout(false);
            this.TabKeyDetails.PerformLayout();
            this.TabPrivateKeys.ResumeLayout(false);
            this.TabPrivateKeys.PerformLayout();
            this.CmsPrivate.ResumeLayout(false);
            this.TabPublicKeys.ResumeLayout(false);
            this.TabPublicKeys.PerformLayout();
            this.CmsPublic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Label LblKeyInfo;
        private System.Windows.Forms.CheckBox CbHideClientValues;
        private System.Windows.Forms.Button BtnCopyClientKey;
        private System.Windows.Forms.Button BtnCopyServerLine;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuNewKey;
        private System.Windows.Forms.ToolStripMenuItem MnuOpenKey;
        private System.Windows.Forms.ToolStripMenuItem MnuSaveKey;
        private System.Windows.Forms.ToolStripMenuItem MnuExportPublic;
        private System.Windows.Forms.ToolStripMenuItem MnuExit;
        private System.Windows.Forms.ToolStripSeparator MnuSeparator;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage TabKeyDetails;
        private System.Windows.Forms.TabPage TabPrivateKeys;
        private System.Windows.Forms.TabPage TabPublicKeys;
        private System.Windows.Forms.Button BtnSelectPrivateDirectory;
        private System.Windows.Forms.TextBox TbPrivateDirectory;
        private System.Windows.Forms.ListView LvPrivateKeys;
        private System.Windows.Forms.ColumnHeader ChPrivateName;
        private System.Windows.Forms.ColumnHeader chPrivateOnion;
        private System.Windows.Forms.ColumnHeader chPrivateType;
        private System.Windows.Forms.ColumnHeader chPrivateAlg;
        private System.Windows.Forms.ColumnHeader chPrivateEnabled;
        private System.Windows.Forms.ContextMenuStrip CmsPrivate;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateRename;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateChangeOnion;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateDuplicate;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateEnable;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateDelete;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateCopy;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateCopyPrivate;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateCopyPrivateKey;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateCopyPrivateLine;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateCopyPublic;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateCopyPublicKey;
        private System.Windows.Forms.ToolStripMenuItem CmsPrivateCopyPublicLine;
        private System.Windows.Forms.Button BtnSelectPublicDirectory;
        private System.Windows.Forms.TextBox TbPublicDirectory;
        private System.Windows.Forms.ListView LvPublicKeys;
        private System.Windows.Forms.ColumnHeader ChPublicName;
        private System.Windows.Forms.ColumnHeader ChPublicType;
        private System.Windows.Forms.ColumnHeader ChPublicAlgorithm;
        private System.Windows.Forms.ColumnHeader ChPublicEnabled;
        private System.Windows.Forms.ContextMenuStrip CmsPublic;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CmsPublicCopyPublicKey;
        private System.Windows.Forms.ToolStripMenuItem CmsPublicRename;
        private System.Windows.Forms.ToolStripMenuItem CmsPublicEnable;
        private System.Windows.Forms.ToolStripMenuItem CmsPublicDelete;
        private System.Windows.Forms.ToolStripMenuItem CmsPublicCopyPublicLine;
    }
}

