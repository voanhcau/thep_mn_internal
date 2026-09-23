using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Element;

namespace RosyControllerTMN
{
	public partial class frmProgram : RosySystem.Customize.frmView
	{
		
		#region Khai bao bien

		private DataTable dtProgram;
		private BindingSource bdsProgram = new BindingSource();

		private DataRow drCurrent;

		#endregion

		#region Contructor

		public frmProgram()
		{
			InitializeComponent();

			bdsProgram.PositionChanged += new EventHandler(bdsProgram_PositionChanged);
            dgvProgram.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvProgram_CellMouseDoubleClick);
            this.btUpload.Click += new EventHandler(btUpload_Click);

			this.KeyDown += new KeyEventHandler(KeyDownEvent);
		}

        void dgvProgram_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsProgram.Current).Row;
            frmProgramUp frm = new frmProgramUp();
            frm.Load(drCurrent["File_Name"].ToString());
        }

		void bdsProgram_PositionChanged(object sender, EventArgs e)
		{
			if (bdsProgram.Position < 0)
				return;

			txtPath_Name.Text = ((DataRowView)bdsProgram.Current).Row["Path_Name"].ToString();
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvProgram.strZone = "PROGRAM";
			dgvProgram.BuildGridView(false);
		}

		private void FillData()
		{
			dtProgram = SQLExec.ExecuteReturnDt("SELECT Ident00, Path_Name, File_Name, File_Size, Create_Date, Last_Modify, UpLoad_Date FROM R00Program ORDER BY Path_Name, File_Name");

			bdsProgram.DataSource = dtProgram;
			dgvProgram.DataSource = bdsProgram;

			bdsProgram.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsProgram;
		}

		#endregion

		#region Update

		public override void Delete()
		{
			if (bdsProgram.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsProgram.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("Sure_Delete")))
				return;

			if (DataTool.SQLDelete("R00PROGRAM", drCurrent))
			{
				bdsProgram.RemoveAt(bdsProgram.Position);
				dtProgram.AcceptChanges();
			}
		}

		#endregion
		
		#region Su kien

		private void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Delete();
					break;
			}
		}

		void btUpload_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Upload files (*.*)|*.*";
			ofd.Multiselect = true;
			ofd.RestoreDirectory = true;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string strFile_Name_List = "";
				int iStt = 0;

				foreach (string strFile in ofd.FileNames)
				{
					iStt++;
					strFile_Name_List += iStt.ToString() + ". " + strFile + "\r";
					continue;
				}

				if (strFile_Name_List != "" && !Common.MsgYes_No("Bạn có chắc chắn cập nhật Danh sách file: " + "\r" + strFile_Name_List))
				{
					return;
				}
                //nhập lý do cập nhật
                frmProgramUp_Edit frm = new frmProgramUp_Edit();
                frm.Load();

				foreach (string strFile in ofd.FileNames)
				{
					string strFile_Name = System.IO.Path.GetFileName(strFile);

					//Xóa dòng hiện tại
					if (dtProgram.Select("Path_Name = '" + txtPath_Name.Text + "' AND File_Name = '" + strFile_Name + "'").Length > 0)
					{
						DataRow drDelete = dtProgram.Select("Path_Name = '" + txtPath_Name.Text + "' AND File_Name = '" + strFile_Name + "'")[0];

						if (DataTool.SQLDelete("R00Program", drDelete))
							dtProgram.Rows.Remove(drDelete);
					}

					int iFile_Size = System.IO.File.ReadAllBytes(strFile).Length;
					byte[] bFile_Content = (byte[])System.IO.File.ReadAllBytes(strFile);

					System.IO.FileInfo fi = new System.IO.FileInfo(strFile);

					Hashtable htPara = new Hashtable();
					htPara.Add("PATH_NAME", txtPath_Name.Text.Trim());
					htPara.Add("FILE_NAME", strFile_Name);
					htPara.Add("FILE_SIZE", iFile_Size);
					htPara.Add("FILE_CONTENT", bFile_Content);
					htPara.Add("CREATE_DATE", fi.CreationTime);
					htPara.Add("LAST_MODIFY", fi.LastWriteTime);
					htPara.Add("UPLOAD_DATE", DateTime.Now.Date);

					string strSQL = @"
							INSERT INTO R00PROGRAM (Path_Name, File_Name, File_Size, File_Content, Create_Date, Last_Modify, Upload_Date)
								VALUES(@Path_Name, @File_Name, @File_Size, @File_Content, @Create_Date, @Last_Modify, @Upload_Date)

							SELECT Ident00, Path_Name, File_Name, File_Size, File_Content, Create_Date, Last_Modify, Upload_Date
								FROM R00PROGRAM
								WHERE Ident00 = @@IDENTITY";

					DataTable dtAdd = SQLExec.ExecuteReturnDt(strSQL, htPara, CommandType.Text);

					if (dtAdd != null && dtAdd.Rows.Count > 0)
					{
						DataRow drNew = dtProgram.NewRow();

						Common.CopyDataRow(dtAdd.Rows[0], drNew);

						dtProgram.Rows.Add(drNew);
					}

                    Hashtable htParaUp = new Hashtable();
                   
                    htParaUp.Add("FILE_NAME", strFile_Name);
                    htParaUp.Add("LY_DO", frm.txtLy_Do.Text);
                    htParaUp.Add("UPLOAD_DATE", DateTime.Now.Date);
                    htParaUp.Add("CREATE_LOG", Common.GetCurrent_Log());
                    string strUp = "INSERT INTO R00PROUP (File_Name, Ly_Do, UpLoad_Date, Create_Log) VALUES (@File_Name, @Ly_Do, @UpLoad_Date, @Create_Log)";
                    SQLExec.Execute(strUp, htParaUp, CommandType.Text);
				}
			}

			
		}

		#endregion
	}
}
