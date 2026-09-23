using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmBarcodeLe_Edit : RosySystem.Customize.frmEdit
	{
		public bool bPrint = false;
        DataRow drCurrent;
        string strBarcode = string.Empty;
        double dbNum_Bars_Cl = 0;

        public frmBarcodeLe_Edit()
		{
			InitializeComponent();
					
			numNum_Bars.Validating += new CancelEventHandler(numNum_Bars_Validating);
            btInherit.Click += new EventHandler(btInherit_Click);
			
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strBarcode, double dbNum_Bars)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strBarcode = strBarcode;
            
			Common.ScaterMemvar(this, ref drEdit);

			//Get New Barcode theo bo le
			if (enuNew_Edit == enuEdit.New)
			{
                Hashtable ht = new Hashtable();
                ht.Add("BARCODE", strBarcode);
                txtBarcode.Text = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetBarcodeLe(@Barcode)", ht, CommandType.Text);
			}
            
            double dbNum_Bars_Le = 0;
            
            if(enuNew_Edit == enuEdit.New && DataTool.SQLCheckExist("R81DMBARCODE","Barcode_Org", strBarcode))
                dbNum_Bars_Le = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(Num_Bars) FROM R81DMBARCODE WHERE Barcode_Org = '" + strBarcode + "'"));
            if (enuNew_Edit == enuEdit.Edit)
                dbNum_Bars_Le = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(Num_Bars) FROM R81DMBARCODE WHERE Barcode_Org = '" + strBarcode + "' AND Barcode <> '" + txtBarcode.Text + "'"));

            this.dbNum_Bars_Cl = dbNum_Bars - dbNum_Bars_Le;

			BindingLanguage();
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
            if (numNum_Bars.Value <= 0)
            {
                Common.MsgCancel("Khối lượng cây không hợp lệ");
                return false;
            }
			if (numSo_Luong.Value <= 0)
			{
				Common.MsgCancel("Khối lượng không hợp lệ");
				return false;
			}
            if (Convert.ToDouble(numNum_Bars.Value) > dbNum_Bars_Cl)
            {
                Common.MsgCancel("Số cây không được lớn hơn SL nhập");
                return false;
            }
			return true;
		}
        void btInherit_Click(object sender, EventArgs e)
        {
            frmInherit_LXH frm = new frmInherit_LXH();
            frm.Load(drEdit["Ma_Vt_Sp"].ToString());

            if (frm.is_Accept)
            {
                if (frm.dtInheritVoucher.Select("Chon = true").Length == 0)
				    return;
                
                DataRow drInheritVoucher = frm.dtInheritVoucher.Select("Chon = 1")[0];
                
                txtSo_Ct_LXH.Text = drInheritVoucher["So_Ct"].ToString();
                numNum_Bars.Value = Convert.ToDecimal(drInheritVoucher["So_Luong_Cay_Le"]);
            }
        }
        //private object GetNewNum_Lot()
        //{
        //    object strResult = string.Empty;
        //    string strSQLExec = string.Empty;
        //    string strChar_Year = string.Empty;
			
			

        //    return strResult;
        //}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            drEdit["Barcode_Org"] = strBarcode;
            drEdit["Ngay_Nhap"] = DateTime.Now;

			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMBARCODE", ref drEdit))
                return false;

            return true;
		}

		void numNum_Bars_Validating(object sender, CancelEventArgs e)
		{
            //if (numNum_Bars.Value <= 0)
            //    numLength.Value = 0;
            DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drEdit["Ma_Vt_Sp"].ToString());
            double dbBarem_Standard = Convert.ToDouble(drDmVt["Barem_Standard"]);
            double dbLength = Convert.ToDouble(drEdit["Length"]);
            numSo_Luong.Value = Math.Round((decimal)((dbBarem_Standard * dbLength * Convert.ToDouble(numNum_Bars.Value))));
		}

		
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				bPrint = false;
				isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			bPrint = false;
			this.isAccept = false;
			this.Close();
		}
		
		private void LockEditInfo(bool bLocked)
		{
			numSo_Luong.Enabled = bLocked;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

            //if (enuNew_Edit == enuEdit.New && txtBarcode.Text.Trim().StartsWith("L"))
            //{
            //    LockEditInfo(true);
            //    btSaveAndPrint.Enabled = false;
            //    numNum_Bars.Enabled = true;
            //}

            //if (enuNew_Edit == enuEdit.Edit)
            //{
            //    LockEditInfo(false);

            //    if (Common.CheckPermission("ACCESS_SO_LUONG", enuPermission_Type.Allow_Access))
            //        numSo_Luong.Enabled = numSo_Luong_Barem.Enabled = true;
            //    else
            //        numSo_Luong.Enabled = numSo_Luong_Barem.Enabled = false;
            //}
		}
	}
}
