using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Common;

namespace RosyModule.Machinery
{
    public partial class frmResource_Edit : RosySystem.Customize.frmEdit
    {
        object objFileContent = null;

        public frmResource_Edit()
        {
            InitializeComponent();

            btUpLoad.Click += new EventHandler(btUpLoad_Click);
            btRemove.Click += new EventHandler(btRemove_Click);
            btDownLoad.Click += new EventHandler(btDownLoad_Click);

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + ", " + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.Edit)
            {
                objFileContent = this.LoadResource(drEdit["Catalog"].ToString(), drEdit["File_Name"].ToString(), drEdit["File_Type"].ToString());

                if (objFileContent != null)
                    using (Stream s = new MemoryStream())
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        formatter.Serialize(s, objFileContent);
                        lblSize.Text = "(" + s.Length.ToString() + ")";
                    }
            }

            this.ShowImage();
            this.LoadDicName();

            this.ShowDialog();
        }

        private object LoadResource(string strCatalog, string strFile_Name, string strFile_Type)
        {
            if (((strCatalog != null) && (strFile_Name != null)) && (strFile_Type != null))
            {
                System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                hashtable.Add("CATALOG", strCatalog);
                hashtable.Add("FILE_NAME", strFile_Name);
                hashtable.Add("FILE_TYPE", strFile_Type);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM R06Resource WHERE Catalog = @Catalog AND File_Name = @File_Name AND File_Type = @File_Type", hashtable, CommandType.Text);
                if (((obj2 != null) && (obj2 != System.DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return obj2;
                }
            }
            return null;
        }

        void LoadDicName()
        {
            lbtFile_Tag.Text = drEdit["File_Tag"].ToString();

            if (txtMa_Vt_Tb.Text.Trim() != string.Empty)
                lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb.Text.Trim());
            else
                lbtTen_Vt_Tb.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            if (txtMa_Vt_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgCancel("Mã vật tư không đc rỗng");
                return false;
            }

            if (txtFile_Name.Text.Trim() == string.Empty)
            {
                Common.MsgCancel("Loại cột không đc rỗng");
                return false;
            }

            if (cboFile_Type.Text.Trim() == string.Empty)
            {
                Common.MsgCancel("Loại cột không đc rỗng");
                return false;
            }

            return true;
        }

        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);
            drEdit["File_Tag"] = lbtFile_Tag.Text; //Lưu lại phần mở rộng của File

            //Kiem tra Valid tren Form
            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            //Luu vao CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R06Resource", ref drEdit))
                return false;

            SaveResource(drEdit["Catalog"].ToString(), drEdit["File_Name"].ToString(), drEdit["File_Type"].ToString(), objFileContent);

            return true;
        }

        private bool SaveResource(string strCatalog, string strFile_Name, string strFile_Type, object objFile_Content)
        {
            string str;
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            hashtable.Add("CATALOG", strCatalog);
            hashtable.Add("FILE_NAME", strFile_Name);
            hashtable.Add("FILE_TYPE", strFile_Type);
            hashtable.Add("FILE_CONTENT", (objFile_Content == null) ? ((object)new byte[0]) : ((object)((byte[])objFile_Content)));
            if (DataTool.SQLCheckExist("R06Resource", new string[] { "Catalog", "File_Name", "File_Type" }, new object[] { strCatalog, strFile_Name, strFile_Type }))
            {
                str = "UPDATE R06Resource SET File_Content = @File_Content WHERE Catalog = @Catalog AND File_Name = @File_Name AND File_Type = @File_Type";
            }
            else
            {
                str = "INSERT INTO R06Resource (Catalog, File_Name, File_Type, File_Content) VALUES (@Catalog, @File_Name, @File_Type, @File_Content)";
            }
            return SQLExec.Execute(str, hashtable, CommandType.Text);
        }

        void btDownLoad_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*." + lbtFile_Tag.Text + ")|*." + lbtFile_Tag.Text + "|All files (*.*)|*.*";
            sfd.FileName = txtFile_Name.Text;

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fileStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write((byte[])objFileContent, 0, ((byte[])objFileContent).Length);
                fileStream.Close();

                if (chkOpen.Checked)
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        void btRemove_Click(object sender, EventArgs e)
        {
            RemoveFile();
        }

        void btUpLoad_Click(object sender, EventArgs e)
        {
            this.UploadFile();
        }

        private void UploadFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;

            if (cboFile_Type.Text == "IMG")
            {
                fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*";
            }
            else if (cboFile_Type.Text == "XLS")
            {
                fileDialog.Filter = "(*.XLS;*.XLSX)|*.XLS;*.XLSX|All files (*.*)|*.*";
            }
            else if (cboFile_Type.Text == "DOC")
            {
                fileDialog.Filter = "(*.DOC;*.DOCX)|*.DOC;*.DOCX|All files (*.*)|*.*";
            }
            else if (cboFile_Type.Text == "EXE")
            {
                fileDialog.Filter = "(*.EXE)|*.EXE|All files (*.*)|*.*";
            }
            else if (cboFile_Type.Text == "PDF")
            {
                fileDialog.Filter = "(*.PDF)|*.PDF|All files (*.*)|*.*";
            }
            else if (cboFile_Type.Text == "DWG")
            {
                fileDialog.Filter = "(*.DWG)|*.DWG|All files (*.*)|*.*";
            }

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            this.objFileContent = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);
            this.ShowImage();

            cboFile_Type.Enabled = false;
            lbtFile_Tag.Text = Path.GetExtension(fileDialog.FileName).Substring(1).ToUpper();
        }

        private void RemoveFile()
        {
            objFileContent = null;
            picImage.Image = null;
            cboFile_Type.Enabled = true;
        }

        private void ShowImage()
        {
            if (objFileContent != null)
            {
                if (cboFile_Type.Text == "IMG")
                    picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((Byte[])objFileContent)), picImage.Size);
                else if (cboFile_Type.Text == "XLS")
                    picImage.Image = imageList1.Images["Excel"];
                else if (cboFile_Type.Text == "DOC")
                    picImage.Image = imageList1.Images["Word"];
                else if (cboFile_Type.Text == "EXE")
                    picImage.Image = imageList1.Images["ExeFile"];
            }
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                isAccept = true;
                this.Close();
            }
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }
    }
}
