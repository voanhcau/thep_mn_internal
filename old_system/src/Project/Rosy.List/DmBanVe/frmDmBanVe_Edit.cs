using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosyList;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmBanVe_Edit : RosyList.frmEdit
	{
		DataRow drCurrent;
		object objFile = null;
		string strFile_Tag = string.Empty;

        #region Phuong thuc

        public frmDmBanVe_Edit()
		{
			InitializeComponent();

			btAttack.Click += new EventHandler(btAttack_Click);
			btOpenFile.Click += new EventHandler(btOpenFile_Click);
		}

		      

		new public void Load(enuEdit enuNew_Edit, DataRow drCurrent)
		{
			this.drCurrent = drCurrent;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			

			//Hải xử lý: Khi Edit, lấy dữ liệu từ SQL ra (không lấy từ C# giống trước kia)
			if (enuNew_Edit == enuEdit.Edit)
			{
				this.txtMa_BanVe.Enabled = false;
				this.drEdit = DataTool.SQLGetDataRowByID("R81DmBanVe", "Ma_BanVe", drCurrent["Ma_Banve"].ToString());
			}
			else
			{
				this.drEdit = DataTool.SQLGetDataTable("R81DmBanVe", null, "0 = 1", "Ma_Banve").NewRow();
				Common.CopyDataRow(drCurrent, drEdit);
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			
		}

		

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_BanVe.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_BanVe") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }

			if (txtTen_BanVe.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_BanVe") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtFile_Name.Text.Trim() == string.Empty)
			{
				Common.MsgOk("Chưa attach bản vẽ " + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            return bvalid;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMBANVE", ref drEdit))
				return false;

			if (drEdit["Image"] != DBNull.Value)
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("MA_BANVE", (string)drEdit["Ma_BanVe"]);
				htPara.Add("IMAGE", drEdit["Image"]);
				string strSQLExec = "";
				strSQLExec = @"UPDATE R81DMBANVE SET Image = @Image WHERE Ma_BanVe = @Ma_BanVe";

				SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
			}
		
			Common.CopyDataRow(drEdit, drCurrent);

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_BANVE", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		
		

		

		void btOpenFile_Click(object sender, EventArgs e)
		{
			string strFileName = (string)drEdit["File_Name"] + "." + (string)drEdit["Tag"];
			string strPath = Application.StartupPath + @"\File\";

			if (!Directory.Exists(strPath))
				Directory.CreateDirectory(strPath);

			object objFile = (object)drEdit["Image"];

			if (objFile != null)
			{

				FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);
				fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
				fileStream.Close();
				System.Diagnostics.Process.Start(strPath + strFileName);

			}
		}

		void btAttack_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.RestoreDirectory = true;
			fileDialog.Filter = "(*.PDF)|*.PDF|All files (*.*)|*.*";

			if (fileDialog.ShowDialog() != DialogResult.OK)
				return;

			this.objFile = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);

			if (objFile != null)
			{
				drEdit["Tag"] = Path.GetExtension(fileDialog.FileName).Substring(1).ToUpper();
				drEdit["Image"] = (objFile == null) ? ((object)new byte[0]) : ((object)((byte[])objFile));
				drEdit["File_Name"] = Path.GetFileNameWithoutExtension(fileDialog.FileName);
				txtFile_Name.Text = (string)drEdit["File_Name"];
			}
		}
		#endregion

   
	}
}