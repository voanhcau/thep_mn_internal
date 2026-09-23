using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Machinery
{
    public partial class frmCongViecBTDK_Edit : RosySystem.Customize.frmEdit
    {
        string strMa_Nh_Tb = string.Empty;
        public frmCongViecBTDK_Edit()
        {
            InitializeComponent();
            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
            txtPhan_Loai_Cv.Validating += new CancelEventHandler(txtPhan_Loai_Cv_Validating);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.isAccept = true;
                this.Close();
            }
        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);
            
            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }
        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {

            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Tb.Text = drLookup["Ma_Nh_Tb"].ToString();
                lbtTen_Nh_Tb.Text = drLookup["Ten_Nh_Tb"].ToString();
                strMa_Nh_Tb = drLookup["Ma_Nh_Tb"].ToString();
            }
        }
        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
           
            string strValue = txtMa_Tb.Text.Trim();
            bool bRequire = true;
            string strKey = "Ma_Nh_Tb = '" + strMa_Nh_Tb + "'";
            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Tb.Text = drLookup["Ma_Tb"].ToString();
                lbtTen_Tb.Text = drLookup["Ten_Tb"].ToString();

            }
        }
        void txtPhan_Loai_Cv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtPhan_Loai_Cv.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "LOAI_CV_BTTB");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'LOAI_CV_BTTB'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtPhan_Loai_Cv.Text = string.Empty;
                lbtTen_Phan_Loai_Cv.Text = string.Empty;
            }
            else
            {
                txtPhan_Loai_Cv.Text = drLookup["Type_ID"].ToString();
                lbtTen_Phan_Loai_Cv.Text = drLookup["Type_Name"].ToString();
            }
        }

        private void LoadDicName()
        {
           

            if (txtMa_Tb.Text != string.Empty)
                lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", txtMa_Tb.Text.Trim());
            else
                lbtTen_Tb.Text = string.Empty;
            
            if (txtMa_Nh_Tb.Text != string.Empty)
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
            else
                lbtTen_Nh_Tb.Text = string.Empty;

            if(txtPhan_Loai_Cv.Text != "")
            {
            DataTable dtPhan_Loai_Cv = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMTYPE WHERE Type = 'LOAI_CV_BTTB' AND TYPE_ID = '" + txtPhan_Loai_Cv.Text + "'");
            DataRow drPhan_Loai_Cv = dtPhan_Loai_Cv.Rows[0];
            lbtTen_Phan_Loai_Cv.Text = drPhan_Loai_Cv["Type_Name"].ToString();
            }
        }

        private bool FormCheckValid()
        {
            //KIỂM TRA NÔI DUNG THỰC HIỆN
            if (txtNoi_Dung_Th.Text == "")
            {
                Common.MsgOk("Nội dung thực hiện không được phép rỗng. Yêu cầu bổ sung thông tin công việc thực hiện!!!");
                return false;
            }
            if (txtPhan_Loai_Cv.Text == "")
            {
                Common.MsgOk("Bạn chưa nhập phân loại công việc!!!");
                return false;
            }
            bool bvalid = true;
         

            return bvalid;
        }

      

        public bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            if (!FormCheckValid())
                return false;
            DataTable dtCongViecBT = SQLExec.ExecuteReturnDt("SELECT Stt_Nd FROM R06CONGVIECBTDK WHERE Ma_Nh_Tb = '" + drEdit["Ma_Nh_Tb"] + "' AND Ma_Tb = '" + drEdit["Ma_Tb"] + "'");



            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Stt_Nd"] = Common.MaxDCValue(dtCongViecBT, "Stt_Nd") + 1;
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06CONGVIECBTDK", ref drEdit))
                return false;

            return true;
        }

        protected override void OnShown(EventArgs e)
        {
            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }
    }
}
