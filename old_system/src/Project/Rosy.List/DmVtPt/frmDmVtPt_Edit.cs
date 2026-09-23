using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;

namespace RosyList
{
	public partial class frmDmVtPt_Edit : RosyList.frmEdit
	{
		#region Phuong thuc

        public frmDmVtPt_Edit()
		{
			InitializeComponent();

			txtMa_Vt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Vt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			

			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
			txtMa_Nh_Vt.Validated += new EventHandler(txtMa_Nh_Vt_Validated);
			
			txtMa_Vt_Ap.Validating += new CancelEventHandler(txtMa_Vt_Ap_Validating);

		

			txtMa_Nhom.Validating += new CancelEventHandler(txtMa_Nhom_Validating);

            txtMa_Tb_Nhom.Validating += new CancelEventHandler(txtMa_Tb_Nhom_Validating);
		
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //drEdit["Create_Log"] = string.Empty;
            //drEdit["LastModify_Log"] = string.Empty;

			if ((enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) && this.drEdit != null)
			{
				if (this.drEdit.Table.Rows.Count > 0)
				{
					System.Collections.Hashtable htPara = new System.Collections.Hashtable();
					htPara["TABLENAME"] = "R81DMVT";
					htPara["COLUMNNAME"] = "MA_VT";
					htPara["CURRENTID"] = drEdit["Ma_Vt"].ToString();
					htPara["KEY"] = "Ma_Vt LIKE '" + drEdit["Ma_Vt"].ToString().Substring(0, 4) + "%'";

					drEdit["Ma_Vt"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
				}
                drEdit["Ngay_End"] = "01/01/1900";               
			}
			else
			{
				if(Common.CheckPermission("IS_EDITDMVT", enuPermission_Type.Allow_Access))
				{
                  
				
					txtMa_Tb_Nha_Sx.Enabled = true;
					txtTen_Nha_Sx.Enabled = true;
                    
				}
			}

			Common.ScaterMemvar(this, ref drEdit);
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Is_Hide"] = false;
                chkIs_Hide.Checked = false;

                drEdit["Is_TieuHao"] = false;
                chkIs_TieuHao.Checked = false;
            }

			BindingLanguage();
			LoadDicName();

			Ma_Nh_Vt_Valid();

			this.ShowDialog();			
		}

		private void LoadDicName()
		{
			//txtMa_Vt_Ap.bUseAutoDropDown = true;
			//Ma_Nh_Vt
			if (txtMa_Nh_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Vt.Text = DataTool.SQLGetNameByCode("R81DmNhVt", "Ma_Nh_Vt", "Ten_Nh_Vt", txtMa_Nh_Vt.Text.Trim());
			}
			else
				lbtTen_Nh_Vt.Text = string.Empty;

			

			

			

			//Ma_Nhom
			if (txtMa_Nhom.Text.Trim() != string.Empty)
			{
				lbtTen_Nhom.Text = DataTool.SQLGetNameByCode("R81DmType", "Type_Id", "Type_Name", txtMa_Nhom.Text.Trim());
			}
			else
				lbtTen_Nhom.Text = string.Empty;

	

			//Ma_Sp
			if (txtMa_Tb_Nhom.Text.Trim() != string.Empty)
			{
				lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R81DMTENTB", "Ma_Tb_Nhom", "Ten_Tb", txtMa_Tb_Nhom.Text.Trim());
			}
			else
				lbtTen_Tb.Text = string.Empty;

            //Ma_Sp
            if (txtMa_Vt_Ap.Text.Trim() != string.Empty)
            {
                lblTen_Vt_Ap.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Ap.Text.Trim());
            }
            else
                lblTen_Vt_Ap.Text = string.Empty;
          
		}

		void Ma_Nh_Vt_Valid()
		{
			string strLoai_Nh_Vt = DataTool.SQLGetNameByCode("R81DmNhVt", "Ma_Nh_Vt", "Loai_Nh_Vt", txtMa_Nh_Vt.Text);

			switch (strLoai_Nh_Vt)
			{
				

				default:
					break;
			}

           
		}

		public override bool FormCheckValid()
		{
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTen_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Vt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Nh_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (!DataTool.SQLCheckExist("R81DmNhVt", "Ma_Nh_Vt", txtMa_Nh_Vt.Text))
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt") + " không tốn tại trong " + Languages.GetLanguage("DmNhVt") + "!");
				return false;
			}

			this.Ma_Nh_Vt_Valid();

			return true;
		}

		public override bool Save()
		{
			this.Ma_Nh_Vt_Valid();

			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["LastModify_Log"] = string.Empty;
            }
            else
            {
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

                if(txtTen_Vt_Chuan.Text != "")
                    drEdit["Ten_Vt"] = txtTen_Vt_Chuan.Text + " " + txtThong_So_Kt.Text + " " + txtMa_Tb_Nha_Sx.Text + " " + txtTen_Nha_Sx.Text;
            }
			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMVT", ref drEdit))
				return false;
            //cập nhật sang dm vtpt tương đương
            if(this.enuNew_Edit == enuEdit.Edit)
            {
                Hashtable ht = new Hashtable();
                ht.Add("Ma_Vt", txtMa_Vt.Text);
                SQLExec.Execute("sp_Update_Ten_VTTD", ht, CommandType.Text);
            }
			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_VT", drEdit);

			return true;
		}

		#endregion

		#region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmVt"))
				 e.Cancel = true;
		}

		
		
        void Them_VTPT()
		{
			frmDmVtPtCt_Edit frm = new frmDmVtPtCt_Edit();
			frm.Load(enuNew_Edit, drEdit);

			if (frm.isAccept)
			{
                txtMa_Vt.Text = drEdit["Ma_Vt"].ToString();
                txtTen_Vt.Text = frm.txtTen_Vt_Chuan.Text + " " + frm.txtThong_So_Kt.Text + " " + frm.txtMa_Tb_Nha_Sx.Text + " " + frm.txtTen_Nha_Sx.Text;
                txtThong_So_Kt.Text = frm.txtThong_So_Kt.Text;
                txtMa_Tb_Nha_Sx.Text = frm.txtMa_Tb_Nha_Sx.Text;
                txtMa_Nhom.Text = frm.txtMa_Nhom.Text;
                txtMa_Tb_Nhom.Text = frm.txtMa_Tb_Nhom.Text;
				
             
				
				txtDvt.Text = frm.txtDvt.Text;
				txtMa_Nh_Vt.Text = frm.txtMa_Nh_Vt.Text;
				txtTen_Nha_Sx.Text = frm.txtTen_Nha_Sx.Text;
				
				txtTen_Vt_Chuan.Text = frm.txtTen_Vt_Chuan.Text;
                lbtTen_Tb.Text = frm.txtTen_Vt_Chuan.Text;
                lbtTen_Nhom.Text = frm.lbtTen_Nhom.Text;
                lbtTen_Nhom.Text = frm.lbtTen_Nhom.Text;
			}
		}
		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			

			if (enuNew_Edit == enuEdit.New && ((txtMa_Vt.Text == "?") || Common.MsgYes_No("Bạn có muốn thêm mới vật tư phụ tùng không")))
			{
				Them_VTPT();
				txtMa_Vt.ReadOnly = true;
				txtTen_Vt.ReadOnly = true;
				txtThong_So_Kt.ReadOnly = true;
			}
		}

		void txtMa_Vt_Ap_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Ap.Text.Trim();
			string strFilter = "";

			

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, strFilter, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Ap.Text = string.Empty;
                lblTen_Vt_Ap.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Ap.Text = ((string)drLookup["Ma_Vt"]).Trim();
                lblTen_Vt_Ap.Text = ((string)drLookup["Ten_Vt"]).Trim();
			}
		}

		void txtMa_Nh_Vt_Validated(object sender, EventArgs e)
		{
			
		}

		private void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();
			
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt.Text = string.Empty;
				lbtTen_Nh_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt.Text = ((string)drLookup["Ma_Nh_Vt"]).Trim();
				lbtTen_Nh_Vt.Text = ((string)drLookup["Ten_Nh_Vt"]).Trim();

				//Hoặc thêm mới đầu tiên, hoặc người dùng đổi Mã nhóm
				if (!drEdit.HasVersion(DataRowVersion.Original) || txtMa_Nh_Vt.Text != drEdit["Ma_Nh_Vt", DataRowVersion.Original].ToString())
				{
					if (DataTool.SQLCheckExist("R81DmVt", "Ma_Nh_Vt", txtMa_Nh_Vt.Text))
					{
						DataRow drDmVtSimilar = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R81DmVt WHERE Ma_Nh_Vt = '" + txtMa_Nh_Vt.Text + "'").Rows[0];

                        //txtTk_Vtu.Text = drDmVtSimilar["Tk_Vtu"].ToString();
                        //txtTk_DThu.Text = drDmVtSimilar["Tk_Dthu"].ToString();
                        //txtTk_Gvon.Text = drDmVtSimilar["Tk_Gvon"].ToString();
                        //txtTk_Hbtl.Text = drDmVtSimilar["Tk_Hbtl"].ToString();
					}
				}

				//Nếu là sản phẩm, Ma_Vt_Sp = Ma_Vt
                //txtMa_Vt_Sp.Text = (drLookup["Loai_Nh_Vt"].ToString() == "SP" ? txtMa_Vt.Text : "");

				this.Ma_Nh_Vt_Valid();
			}
		}
		

		
        void txtMa_Tb_Nhom_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb_Nhom.Text.Trim();
            bool bRequire = true;
            string strKeyFilter = "Nhom  = '" + txtMa_Nhom.Text + "'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb_Nhom", strValue, bRequire, strKeyFilter, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Tb_Nhom.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Tb_Nhom.Text = ((string)drLookup["Ma_Tb_Nhom"]).Trim();
                txtTen_Vt_Chuan.Text = ((string)drLookup["Ten_Tb"]).Trim();
                lbtTen_Tb.Text = ((string)drLookup["Ten_Tb"]).Trim();

            }
        }

        void txtMa_Nhom_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nhom.Text.Trim();
            bool bRequire = true;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "MA_NHOM");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'MA_NHOM'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nhom.Text = string.Empty;
                lbtTen_Nhom.Text = string.Empty;
            }
            else
            {
                txtMa_Nhom.Text = drLookup["Type_ID"].ToString();
                lbtTen_Nhom.Text = drLookup["Type_Name"].ToString();
            }
        }


        
		#endregion
	}
}
