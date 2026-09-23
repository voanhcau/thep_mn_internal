using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;


namespace RosyModule.Machinery
{
    public partial class frmDuyet_KT : RosySystem.Customize.frmEdit
    {
		string strTypeOfMaintenance = string.Empty;

        public frmDuyet_KT()
        {
            InitializeComponent();
            chkDuyet.CheckedChanged += new EventHandler(chkDuyet_CheckedChanged);
            this.btExit.Click += new EventHandler(btExit_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
        }

        void chkDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuyet.Checked)
                dteNgay_Duyet.Text = Library.DateToStr(DateTime.Now);
            else
                dteNgay_Duyet.Text = string.Empty;

            btSave.Enabled = true;
        }

		public void Load(DataRow drEdit, string strTypeOfMaintenance)
        {
			this.strTypeOfMaintenance = strTypeOfMaintenance;
            this.drEdit = drEdit;
            Common.ScaterMemvar(this, ref drEdit);
            chkDuyet.Enabled = !chkDuyet.Checked;
			txtKy_Hieu.Text = "N";

            btSave.Enabled = false;
            this.ShowDialog();
        }

        private bool FormCheckValid()
        {
            if (dteNgay_Duyet.IsNull)
            {
                Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
                return false;
            }

            return true;
        }


        private bool Save()
        {

            //Lưu phần Checked vào R80Ph
            if (chkDuyet.Enabled)
            {
				DataTable dtBTSC =  SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R06BTSC");

				Common.CopyDataColumn(dtBTSC, drEdit.Table, "TypeOfMaintenance,Ngay_Sua_Chua");

				if (drEdit.Table.Columns.Contains("TypeOfMaintenance"))
					drEdit["TypeOfMaintenance"] = strTypeOfMaintenance;

				if (drEdit.Table.Columns.Contains("Ngay_Sua_Chua"))
					drEdit["Ngay_Sua_Chua"] = Library.StrToDate(dteNgay_Duyet.Text);
				
				if (DataTool.SQLUpdate(RosySystem.enuEdit.New, "R06BTSC", ref drEdit))
				{
					Hashtable ht = new Hashtable();
					ht.Add("MA_VT_TB", (string)drEdit["Ma_Vt_Tb"]);
					ht.Add("MA_VT_TB_KT", (string)drEdit["Ma_Vt_Tb_Kt"]);
					ht.Add("NGAY_SUA_CHUA", Library.StrToDate(dteNgay_Duyet.Text));
					ht.Add("LOAI", "Kiểm tra định kỳ");

					SQLExec.Execute("DELETE FROM R06BTSC WHERE Ma_Vt_Tb = @Ma_Vt_Tb AND Ma_Vt_Tb_Kt = @Ma_Vt_Tb_Kt AND Ngay_Sua_Chua > @Ngay_Sua_Chua AND TypeOfMaintenance = @Loai", ht, CommandType.Text);

					drEdit["Duyet_KT"] = chkDuyet.Checked;
					drEdit["Ngay_Sua_Chua_CC"] = Library.StrToDate(dteNgay_Duyet.Text);
					drEdit["Ngay_Sua_Chua_DK"] = Library.StrToDate(dteNgay_Duyet.Text).AddDays(Convert.ToInt32(drEdit["Dinh_Ky"]));
				}
            }

            return true;
        }

        void btSave_Click(object sender, EventArgs e)
        {
            if (this.FormCheckValid())
            {
                this.Save();
                this.Close();
            }
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
