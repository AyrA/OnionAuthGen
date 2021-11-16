
namespace OnionAuthGen
{
    partial class FrmKeydesign
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCharset = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFirstLimit = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSecondLimit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblThirdLimit = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLength, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCharset, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstLimit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSecondLimit, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblThirdLimit, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 124);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To generate a valid key you have to fulfill the criteria below";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Length is 52 characters";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(303, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(35, 13);
            this.lblLength.TabIndex = 1;
            this.lblLength.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Only use A-Z as well as 2-7";
            // 
            // lblCharset
            // 
            this.lblCharset.AutoSize = true;
            this.lblCharset.Location = new System.Drawing.Point(303, 24);
            this.lblCharset.Name = "lblCharset";
            this.lblCharset.Size = new System.Drawing.Size(35, 13);
            this.lblCharset.TabIndex = 3;
            this.lblCharset.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "2nd character must be: A,B,C,D";
            // 
            // lblFirstLimit
            // 
            this.lblFirstLimit.AutoSize = true;
            this.lblFirstLimit.Location = new System.Drawing.Point(303, 48);
            this.lblFirstLimit.Name = "lblFirstLimit";
            this.lblFirstLimit.Size = new System.Drawing.Size(35, 13);
            this.lblFirstLimit.TabIndex = 5;
            this.lblFirstLimit.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "50th character (3rd last) must be: B,F,J,N,R,V,Z,5";
            // 
            // lblSecondLimit
            // 
            this.lblSecondLimit.AutoSize = true;
            this.lblSecondLimit.Location = new System.Drawing.Point(303, 72);
            this.lblSecondLimit.Name = "lblSecondLimit";
            this.lblSecondLimit.Size = new System.Drawing.Size(35, 13);
            this.lblSecondLimit.TabIndex = 7;
            this.lblSecondLimit.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Last character must be: A,Q";
            // 
            // lblThirdLimit
            // 
            this.lblThirdLimit.AutoSize = true;
            this.lblThirdLimit.Location = new System.Drawing.Point(303, 96);
            this.lblThirdLimit.Name = "lblThirdLimit";
            this.lblThirdLimit.Size = new System.Drawing.Size(41, 13);
            this.lblThirdLimit.TabIndex = 9;
            this.lblThirdLimit.Text = "label11";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(264, 208);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbKey
            // 
            this.tbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKey.AsciiOnly = true;
            this.tbKey.Location = new System.Drawing.Point(12, 174);
            this.tbKey.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(408, 20);
            this.tbKey.TabIndex = 2;
            this.tbKey.TextChanged += new System.EventHandler(this.tbKey_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "This is probably unsafe and a bad idea.\r\nPress F1 for more information as to why";
            // 
            // FrmKeydesign
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(432, 243);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(440, 270);
            this.Name = "FrmKeydesign";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Key designer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCharset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFirstLimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSecondLimit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblThirdLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox tbKey;
        private System.Windows.Forms.Label label3;
    }
}