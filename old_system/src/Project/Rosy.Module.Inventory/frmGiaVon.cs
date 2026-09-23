using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Inventory
{
	public partial class frmGiaVon : RosySystem.Control.frmBase
	{
        private string strLoai_Gv = string.Empty;
		public frmGiaVon()
		{
			InitializeComponent();

			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			btOk.Click += new EventHandler(btOk_Click);
			btCancel.Click += new EventHandler(btCancel_Click);

			btMa_Kho.Click += new EventHandler(btMa_Kho_Click);
		}



		new public void Load(string strLoai_Gv)
		{
            this.strLoai_Gv = strLoai_Gv;
			this.txtNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
			this.txtNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

			switch ((string)Parameters.GetParaValue("PP_GIAVON"))
			{
				case "BQTH":
					rdbGiaBQTH.Checked = true;
					break;
				case "BQTT":
					rdbGiaBQTT.Checked = true;
					break;
				default:
					rdbGiaNTXT.Checked = true;
					break;
			}

            this.BindingLanguage();
			this.Show();
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text;
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text;
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}
		}

		void btOk_Click(object sender, EventArgs e)
		{
			string strMa_Vt = txtMa_Vt.Text.Trim();
			string strMa_Kho = txtMa_Kho.Text.Trim();
			DateTime dteNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
			DateTime dteNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);
           
            if (strLoai_Gv == "KT")
            {
                if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != dteNgay_Ct1.Year && Common.GetPartitionCurrent() != dteNgay_Ct2.Year)
                {
                    Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + dteNgay_Ct1.Year.ToString() + "!");
                    return;
                }

                if (!Common.CheckDataLocked(dteNgay_Ct1) || !Common.CheckDataLocked(dteNgay_Ct2))
                {
                    Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
                    return;
                }
            }
			string[] strArrParaName = new string[] { "@Ngay_Ct1", "@Ngay_Ct2", "@Ma_Vt", "@Ma_Kho", "@Ma_Kho_List", "@Ma_DvCs" };
			object[] objArrParaValue = new object[] { dteNgay_Ct1, dteNgay_Ct2, strMa_Vt, strMa_Kho, txtMa_Kho_List.Text, Element.sysMa_DvCs };

			Common.ShowStatus(Languages.GetLanguage("In_Process"));

			lock (this)
			{
				if (rdbGiaBQTH.Checked)
				{
                    if (strLoai_Gv == "KT")
					{ 
						//if(txtMa_Kho_List.Text == "")
							SQLExec.Execute("sp_GiaBQTH", strArrParaName, objArrParaValue, CommandType.StoredProcedure);
						//else if(txtMa_Kho_List.Text != "")
						//	SQLExec.Execute("sp_GiaBQTH_List", strArrParaName, objArrParaValue, CommandType.StoredProcedure);
					}
					else
                        SQLExec.Execute("sp_GiaBQTH_PT", strArrParaName, objArrParaValue, CommandType.StoredProcedure);
				}
				else if (rdbGiaBQTT.Checked)
				{
					SQLExec.Execute("sp_GiaBQTT", strArrParaName, objArrParaValue, CommandType.StoredProcedure);
				}
				else if (rdbGiaNTXT.Checked)
					return;
			}

			Element.sysNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
			Element.sysNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);

			Common.MsgOk(Languages.GetLanguage("EndProcess"));
			Common.EndShowStatus();

			//this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void btMa_Kho_Click(object sender, EventArgs e)
		{
			bool bRequire = true;
			string strFilter = string.Empty;
			strFilter = "";

            frmQuickLookup_Customize frmLookup = new frmQuickLookup_Customize();
            //frmQuickLookup frmLookup = new frmQuickLookup();
            frmLookup.bMultiLookup = true;

            //Hien Form Lookup
            frmLookup.isLookup = true;
            frmLookup.strLookupColumn = "Ma_Kho";
            frmLookup.strLookupValue = txtMa_Kho_List.Text;
            frmLookup.strLookupKeyFilter = strFilter;
            frmLookup.strLookupKeyValid = "";

            frmLookup.LoadLookup();




            //DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (frmLookup.strColumnSelect == null)
            {
                txtMa_Kho_List.Text = string.Empty;
            }
            else
            {
                txtMa_Kho_List.Text = frmLookup.strColumnSelect;
            }
		}
      
	}
}
