
namespace OnionAuthGen
{
    partial class FrmHelp
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
            this.LbHelp = new System.Windows.Forms.ListBox();
            this.TbHelp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbHelp
            // 
            this.LbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbHelp.FormattingEnabled = true;
            this.LbHelp.Location = new System.Drawing.Point(12, 12);
            this.LbHelp.Name = "LbHelp";
            this.LbHelp.Size = new System.Drawing.Size(172, 147);
            this.LbHelp.TabIndex = 0;
            this.LbHelp.SelectedIndexChanged += new System.EventHandler(this.LbHelp_SelectedIndexChanged);
            // 
            // TbHelp
            // 
            this.TbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbHelp.BackColor = System.Drawing.SystemColors.Window;
            this.TbHelp.Location = new System.Drawing.Point(190, 12);
            this.TbHelp.Multiline = true;
            this.TbHelp.Name = "TbHelp";
            this.TbHelp.ReadOnly = true;
            this.TbHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbHelp.Size = new System.Drawing.Size(390, 147);
            this.TbHelp.TabIndex = 1;
            // 
            // FrmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 173);
            this.Controls.Add(this.TbHelp);
            this.Controls.Add(this.LbHelp);
            this.Name = "FrmHelp";
            this.Text = ".onion Authentication Generator Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LbHelp;
        private System.Windows.Forms.TextBox TbHelp;
    }
}