namespace RosyModule.Machinery
{
    partial class frmResource_Edit
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
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.lblSize = new RosySystem.Control.rsLabel();
            this.lbtFile_Tag = new RosySystem.Control.rsLabel();
            this.btDownLoad = new System.Windows.Forms.Button();
            this.lblMedia_Type = new RosySystem.Control.rsLabel();
            this.cboFile_Type = new RosySystem.Control.rsComboBox();
            this.rsLabel4 = new RosySystem.Control.rsLabel();
            this.rsLabel3 = new RosySystem.Control.rsLabel();
            this.rsLabel1 = new RosySystem.Control.rsLabel();
            this.btRemove = new System.Windows.Forms.Button();
            this.btUpLoad = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btgAccept = new RosySystem.Customize.btgAccept();
            this.label2 = new RosySystem.Control.rsLabel();
            this.txtMa_Vt_Tb = new RosySystem.Control.rsTextBox();
            this.lblMedia_ID = new RosySystem.Control.rsLabel();
            this.txtFile_Name = new RosySystem.Control.rsTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbtTen_Vt_Tb = new RosySystem.Control.rsLabel();
            this.txtGhi_Chu = new RosySystem.Control.rsTextBox();
            this.lblGhi_Chu = new RosySystem.Control.rsLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Location = new System.Drawing.Point(267, 201);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(180, 18);
            this.chkOpen.TabIndex = 87;
            this.chkOpen.Text = "Open when download complete";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // lblSize
            // 
            this.lblSize.AutoEllipsis = true;
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(159, 223);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(36, 14);
            this.lblSize.TabIndex = 96;
            this.lblSize.Tag = "";
            this.lblSize.Text = "(Size)";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtFile_Tag
            // 
            this.lbtFile_Tag.AutoEllipsis = true;
            this.lbtFile_Tag.AutoSize = true;
            this.lbtFile_Tag.Location = new System.Drawing.Point(264, 43);
            this.lbtFile_Tag.Name = "lbtFile_Tag";
            this.lbtFile_Tag.Size = new System.Drawing.Size(46, 14);
            this.lbtFile_Tag.TabIndex = 95;
            this.lbtFile_Tag.Tag = "";
            this.lbtFile_Tag.Text = "File_Tag";
            this.lbtFile_Tag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btDownLoad
            // 
            this.btDownLoad.Location = new System.Drawing.Point(265, 172);
            this.btDownLoad.Name = "btDownLoad";
            this.btDownLoad.Size = new System.Drawing.Size(100, 27);
            this.btDownLoad.TabIndex = 86;
            this.btDownLoad.Tag = "Download";
            this.btDownLoad.Text = "Download";
            this.btDownLoad.UseVisualStyleBackColor = true;
            // 
            // lblMedia_Type
            // 
            this.lblMedia_Type.AutoEllipsis = true;
            this.lblMedia_Type.AutoSize = true;
            this.lblMedia_Type.Location = new System.Drawing.Point(22, 67);
            this.lblMedia_Type.Name = "lblMedia_Type";
            this.lblMedia_Type.Size = new System.Drawing.Size(63, 14);
            this.lblMedia_Type.TabIndex = 94;
            this.lblMedia_Type.Tag = "Media_Type";
            this.lblMedia_Type.Text = "Kiểu dữ liệu";
            this.lblMedia_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFile_Type
            // 
            this.cboFile_Type.Items.AddRange(new object[] {
            "IMG",
            "DOC",
            "XLS",
            "EXE",
            "PDF",
            "DWG"});
            this.cboFile_Type.Location = new System.Drawing.Point(123, 64);
            this.cboFile_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFile_Type.Name = "cboFile_Type";
            this.cboFile_Type.Size = new System.Drawing.Size(136, 22);
            this.cboFile_Type.TabIndex = 2;
            // 
            // rsLabel4
            // 
            this.rsLabel4.AutoEllipsis = true;
            this.rsLabel4.AutoSize = true;
            this.rsLabel4.Location = new System.Drawing.Point(22, 152);
            this.rsLabel4.Name = "rsLabel4";
            this.rsLabel4.Size = new System.Drawing.Size(82, 14);
            this.rsLabel4.TabIndex = 93;
            this.rsLabel4.Tag = "";
            this.rsLabel4.Text = "(100x100 pixel)";
            this.rsLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel3
            // 
            this.rsLabel3.AutoEllipsis = true;
            this.rsLabel3.AutoSize = true;
            this.rsLabel3.Location = new System.Drawing.Point(37, 134);
            this.rsLabel3.Name = "rsLabel3";
            this.rsLabel3.Size = new System.Drawing.Size(49, 14);
            this.rsLabel3.TabIndex = 92;
            this.rsLabel3.Tag = "";
            this.rsLabel3.Text = "The best";
            this.rsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsLabel1
            // 
            this.rsLabel1.AutoEllipsis = true;
            this.rsLabel1.AutoSize = true;
            this.rsLabel1.Location = new System.Drawing.Point(22, 94);
            this.rsLabel1.Name = "rsLabel1";
            this.rsLabel1.Size = new System.Drawing.Size(47, 14);
            this.rsLabel1.TabIndex = 91;
            this.rsLabel1.Tag = "";
            this.rsLabel1.Text = "Preview";
            this.rsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(265, 122);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(100, 27);
            this.btRemove.TabIndex = 85;
            this.btRemove.Tag = "Remove";
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            // 
            // btUpLoad
            // 
            this.btUpLoad.Location = new System.Drawing.Point(265, 94);
            this.btUpLoad.Name = "btUpLoad";
            this.btUpLoad.Size = new System.Drawing.Size(100, 27);
            this.btUpLoad.TabIndex = 84;
            this.btUpLoad.Tag = "Upload";
            this.btUpLoad.Text = "Upload";
            this.btUpLoad.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(123, 90);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(136, 129);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 90;
            this.picImage.TabStop = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(381, 254);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 50);
            this.btgAccept.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 89;
            this.label2.Tag = "";
            this.label2.Text = "Mã thiết bị";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt_Tb
            // 
            this.txtMa_Vt_Tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt_Tb.Enabled = false;
            this.txtMa_Vt_Tb.Location = new System.Drawing.Point(123, 15);
            this.txtMa_Vt_Tb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt_Tb.Name = "txtMa_Vt_Tb";
            this.txtMa_Vt_Tb.Size = new System.Drawing.Size(136, 20);
            this.txtMa_Vt_Tb.TabIndex = 0;
            // 
            // lblMedia_ID
            // 
            this.lblMedia_ID.AutoEllipsis = true;
            this.lblMedia_ID.AutoSize = true;
            this.lblMedia_ID.Location = new System.Drawing.Point(22, 43);
            this.lblMedia_ID.Name = "lblMedia_ID";
            this.lblMedia_ID.Size = new System.Drawing.Size(42, 14);
            this.lblMedia_ID.TabIndex = 82;
            this.lblMedia_ID.Tag = "";
            this.lblMedia_ID.Text = "Tên file";
            this.lblMedia_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile_Name
            // 
            this.txtFile_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFile_Name.Location = new System.Drawing.Point(123, 40);
            this.txtFile_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Name.Name = "txtFile_Name";
            this.txtFile_Name.Size = new System.Drawing.Size(136, 20);
            this.txtFile_Name.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbtTen_Vt_Tb
            // 
            this.lbtTen_Vt_Tb.AutoEllipsis = true;
            this.lbtTen_Vt_Tb.AutoSize = true;
            this.lbtTen_Vt_Tb.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Vt_Tb.Location = new System.Drawing.Point(264, 18);
            this.lbtTen_Vt_Tb.Name = "lbtTen_Vt_Tb";
            this.lbtTen_Vt_Tb.Size = new System.Drawing.Size(90, 14);
            this.lbtTen_Vt_Tb.TabIndex = 141;
            this.lbtTen_Vt_Tb.Text = "Tên vật tư thiết bị";
            this.lbtTen_Vt_Tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.Location = new System.Drawing.Point(123, 254);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(242, 42);
            this.txtGhi_Chu.TabIndex = 3;
            // 
            // lblGhi_Chu
            // 
            this.lblGhi_Chu.AutoEllipsis = true;
            this.lblGhi_Chu.AutoSize = true;
            this.lblGhi_Chu.Location = new System.Drawing.Point(22, 258);
            this.lblGhi_Chu.Name = "lblGhi_Chu";
            this.lblGhi_Chu.Size = new System.Drawing.Size(44, 14);
            this.lblGhi_Chu.TabIndex = 158;
            this.lblGhi_Chu.Tag = "";
            this.lblGhi_Chu.Text = "Ghi chú";
            this.lblGhi_Chu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmResource_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 317);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.lblGhi_Chu);
            this.Controls.Add(this.lbtTen_Vt_Tb);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lbtFile_Tag);
            this.Controls.Add(this.btDownLoad);
            this.Controls.Add(this.lblMedia_Type);
            this.Controls.Add(this.cboFile_Type);
            this.Controls.Add(this.rsLabel4);
            this.Controls.Add(this.rsLabel3);
            this.Controls.Add(this.rsLabel1);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btUpLoad);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMa_Vt_Tb);
            this.Controls.Add(this.lblMedia_ID);
            this.Controls.Add(this.txtFile_Name);
            this.Name = "frmResource_Edit";
            this.Text = "Danh sách file";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOpen;
        private RosySystem.Control.rsLabel lblSize;
        private RosySystem.Control.rsLabel lbtFile_Tag;
        private System.Windows.Forms.Button btDownLoad;
        private RosySystem.Control.rsLabel lblMedia_Type;
        private RosySystem.Control.rsComboBox cboFile_Type;
        private RosySystem.Control.rsLabel rsLabel4;
        private RosySystem.Control.rsLabel rsLabel3;
        private RosySystem.Control.rsLabel rsLabel1;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btUpLoad;
        private System.Windows.Forms.PictureBox picImage;
        private RosySystem.Customize.btgAccept btgAccept;
        private RosySystem.Control.rsLabel label2;
        private RosySystem.Control.rsTextBox txtMa_Vt_Tb;
        private RosySystem.Control.rsLabel lblMedia_ID;
        private RosySystem.Control.rsTextBox txtFile_Name;
        private System.Windows.Forms.ImageList imageList1;
        private RosySystem.Control.rsLabel lbtTen_Vt_Tb;
        private RosySystem.Control.rsTextBox txtGhi_Chu;
        private RosySystem.Control.rsLabel lblGhi_Chu;
    }
}