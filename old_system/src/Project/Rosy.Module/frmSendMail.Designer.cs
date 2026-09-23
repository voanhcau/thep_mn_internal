namespace RosyModule
{
    partial class frmSendMail
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendMail));
			this.btSendMail = new RosySystem.Customize.btPreview();
			this.label1 = new System.Windows.Forms.Label();
			this.txtToMail = new System.Windows.Forms.TextBox();
			this.txtMessa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btExit = new RosySystem.Customize.btPreview();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btSendMail
			// 
			this.btSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btSendMail.Image = ((System.Drawing.Image)(resources.GetObject("btSendMail.Image")));
			this.btSendMail.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btSendMail.ImageKey = "Preview.png";
			this.btSendMail.Location = new System.Drawing.Point(469, 271);
			this.btSendMail.Name = "btSendMail";
			this.btSendMail.Size = new System.Drawing.Size(87, 34);
			this.btSendMail.TabIndex = 28;
			this.btSendMail.Tag = "";
			this.btSendMail.Text = "SUBMIT";
			this.btSendMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btSendMail.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 13);
			this.label1.TabIndex = 29;
			this.label1.Text = "To:";
			// 
			// txtToMail
			// 
			this.txtToMail.Location = new System.Drawing.Point(69, 23);
			this.txtToMail.Name = "txtToMail";
			this.txtToMail.Size = new System.Drawing.Size(566, 20);
			this.txtToMail.TabIndex = 30;
			// 
			// txtMessa
			// 
			this.txtMessa.Location = new System.Drawing.Point(69, 74);
			this.txtMessa.Multiline = true;
			this.txtMessa.Name = "txtMessa";
			this.txtMessa.Size = new System.Drawing.Size(566, 160);
			this.txtMessa.TabIndex = 32;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 31;
			this.label2.Text = "Message:";
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
			this.btExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btExit.ImageKey = "Preview.png";
			this.btExit.Location = new System.Drawing.Point(562, 270);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(83, 34);
			this.btExit.TabIndex = 33;
			this.btExit.Tag = "";
			this.btExit.Text = "Cancel";
			this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btExit.UseVisualStyleBackColor = true;
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(69, 48);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(566, 20);
			this.txtSubject.TabIndex = 35;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 34;
			this.label3.Text = "Subject:";
			// 
			// frmSendMail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(670, 317);
			this.Controls.Add(this.txtSubject);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btExit);
			this.Controls.Add(this.txtMessa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtToMail);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSendMail);
			this.Name = "frmSendMail";
			this.Text = "frmSendMail";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private RosySystem.Customize.btPreview btSendMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToMail;
        private System.Windows.Forms.TextBox txtMessa;
        private System.Windows.Forms.Label label2;
        private RosySystem.Customize.btPreview btExit;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label3;
    }
}