
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
            this.SuspendLayout();
            // 
            // RbRandom
            // 
            this.RbRandom.AutoSize = true;
            this.RbRandom.Checked = true;
            this.RbRandom.Location = new System.Drawing.Point(12, 12);
            this.RbRandom.Name = "RbRandom";
            this.RbRandom.Size = new System.Drawing.Size(85, 17);
            this.RbRandom.TabIndex = 0;
            this.RbRandom.TabStop = true;
            this.RbRandom.Text = "&Random key";
            this.RbRandom.UseVisualStyleBackColor = true;
            // 
            // RbPassword
            // 
            this.RbPassword.AutoSize = true;
            this.RbPassword.Location = new System.Drawing.Point(12, 35);
            this.RbPassword.Name = "RbPassword";
            this.RbPassword.Size = new System.Drawing.Size(105, 17);
            this.RbPassword.TabIndex = 1;
            this.RbPassword.Text = "&Deterministic key";
            this.RbPassword.UseVisualStyleBackColor = true;
            // 
            // RbDesign
            // 
            this.RbDesign.AutoSize = true;
            this.RbDesign.Location = new System.Drawing.Point(12, 58);
            this.RbDesign.Name = "RbDesign";
            this.RbDesign.Size = new System.Drawing.Size(113, 17);
            this.RbDesign.TabIndex = 2;
            this.RbDesign.Text = "&User designed key";
            this.RbDesign.UseVisualStyleBackColor = true;
            // 
            // FrmKeygen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 173);
            this.Controls.Add(this.RbDesign);
            this.Controls.Add(this.RbPassword);
            this.Controls.Add(this.RbRandom);
            this.Name = "FrmKeygen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Key Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbRandom;
        private System.Windows.Forms.RadioButton RbPassword;
        private System.Windows.Forms.RadioButton RbDesign;
    }
}