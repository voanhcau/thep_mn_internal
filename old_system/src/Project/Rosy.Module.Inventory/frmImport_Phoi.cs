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
	public partial class frmImport_Phoi : RosySystem.Control.frmBase
	{
		public frmImport_Phoi()
		{
			InitializeComponent();

			
			btOk.Click += new EventHandler(btOk_Click);
			btCancel.Click += new EventHandler(btCancel_Click);
		}



		new public void Load()
		{
			this.txtNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
			this.txtNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

			

            this.BindingLanguage();
			this.Show();
		}

		

		

		void btOk_Click(object sender, EventArgs e)
		{
			
			DateTime dteNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
			DateTime dteNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);

            if (Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R00NAM WHERE NAM = YEAR('" + Library.DateToStr(dteNgay_Ct1) + "')")) == 0)
            {
                Common.MsgCancel("Ngày được chọn không được có trong hệ thống năm làm việc, vui lòng xem lại");
                return;
            }

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

           
			string[] strArrParaName = new string[] { "@Ngay_Ct1", "@Ngay_Ct2", "@Create_Log", "@Ma_DvCs" };
			object[] objArrParaValue = new object[] { dteNgay_Ct1, dteNgay_Ct2, Common.GetCurrent_Log(), Element.sysMa_DvCs };

			Common.ShowStatus(Languages.GetLanguage("In_Process"));

            //if(rdbPhoi_Sx.Checked ==true)
			SQLExec.Execute("sp_Import_Phoi_Kt", strArrParaName, objArrParaValue, CommandType.StoredProcedure);
            //else
            //    SQLExec.Execute("sp_Import_Phoi_Kt1", strArrParaName, objArrParaValue, CommandType.StoredProcedure);

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

		//void btMa_Kho_Click(object sender, EventArgs e)
		//{
		//    bool bRequire = true;
		//    string strFilter = string.Empty;
		//    strFilter = "";
		//    DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

		//    if (drLookup == null)
		//    {
		//        txtMa_Kho_List.Text = string.Empty;
		//    }
		//    else
		//    {
		//        txtMa_Kho_List.Text = drLookup["MultiSelectValue"].ToString();
		//    }
		//}
      
	}
}
