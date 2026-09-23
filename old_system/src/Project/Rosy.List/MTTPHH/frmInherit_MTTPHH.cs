using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Data;

namespace RosyList
{
	public partial class frmInherit_MTTPHH : RosySystem.Customize.frmView
	{
        public bool Is_Accept = false;
        public DataTable dtInheritVoucher;
        BindingSource bdsInheritVoucher = new BindingSource();
        public frmInherit_MTTPHH()
		{
			InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);

            txtCa_Sx.Validating += new CancelEventHandler(txtCa_Sx_Validating);
            txtLoai_Phoi.Validating += new CancelEventHandler(txtCa_Sx_Validating);
            numTT_Seq.Validating += new CancelEventHandler(txtCa_Sx_Validating);
            txtPattern_Pos.Validating += new CancelEventHandler(txtCa_Sx_Validating);
		}




        public void Load(string strNo_Melt, string strCa, string strLoai_Phoi, double dbTT_Seq, string strPattern_Pos)
        {
            txtNo_Melt.Text = strNo_Melt;
            txtCa_Sx.Text = strCa;
            txtLoai_Phoi.Text = strLoai_Phoi;
            numTT_Seq.Value = dbTT_Seq;
            txtPattern_Pos.Text = strPattern_Pos;
            Build();
            FillData();
            BindingLanguage();


            this.ShowDialog();
        }

        void Build()
        {
            dgvInherit.strZone = "MTTPHH";
            dgvInherit.BuildGridView();
            dgvInherit.ReadOnly = false;

            foreach (DataGridViewColumn dgvc in dgvInherit.Columns)
                dgvc.ReadOnly = true;


            if (dgvInherit.Columns.Contains("Chon"))
                dgvInherit.Columns["Chon"].ReadOnly = false;
        }
        void FillData()
        {
            Hashtable htPara = new Hashtable();

            htPara.Add("NO_MELT", txtNo_Melt.Text);
            htPara.Add("TT_SEQ", numTT_Seq.Value);
            htPara.Add("CA_SX", txtCa_Sx.Text);
           
            htPara.Add("LOAI_PHOI", txtLoai_Phoi.Text);
            htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_InheritMTTPHH", htPara, CommandType.StoredProcedure);


            DataColumn dc = new DataColumn("Chon", typeof(bool));
            dc.DefaultValue = false;
            dtInheritVoucher.Columns.Add(dc);

            bdsInheritVoucher.DataSource = dtInheritVoucher;
            dgvInherit.DataSource = bdsInheritVoucher;

        }
        bool FormCheckValid()
        {
            
            if (dtInheritVoucher == null || dtInheritVoucher.Select("Chon = 1").Length == 0)
            {
                Common.MsgCancel("Không có dữ liệu kế thừa!");
                return false;
            }
            if (dtInheritVoucher.Select("Chon = 1").Length > 1)
            {
                Common.MsgCancel("Dữ liệu có 2 dòng được chọn. chỉ được chọn 1 dữ liệu!");
                return false;
            }
            if (DataTool.SQLCheckExist("R81MTTPHH", "No_Melt", txtNo_Melt.Text))
            {
                Common.MsgCancel("Số mẻ " + txtNo_Melt.Text  + " đã có dữ liệu!");
                return false;
            }
            if (numTT_Seq.Value == 0)
            {
                Common.MsgCancel("Vui lòng nhập TT Seq!");
                return false;
            }
            if (txtCa_Sx.Text == "" || !Common.Inlist(txtCa_Sx.Text, "1A,1B,1C,2A,2B,2C"))
            {
                Common.MsgCancel("Vui lòng nhập Ca sản xuất hoặc ca SX bị sai!");
                return false;
            }
            if (txtLoai_Phoi.Text == "" || !Common.Inlist(txtLoai_Phoi.Text,"150x150,120x120"))
            {
                Common.MsgCancel("Vui lòng nhập loại phôi 150x150 hay 120x120!");
                return false;
            }
            return true;
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.FormCheckValid())
            {
                this.Is_Accept = true;
                this.Close();
            }
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.Is_Accept = false;
            this.Close();
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            this.FillData();
        }
        void txtCa_Sx_Validating(object sender, CancelEventArgs e)
        {
            FillData();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            dgvInherit.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

            if (dgvInherit.Columns.Contains("C"))
                dgvInherit.Columns["C"].HeaderText = "C";

            if (dgvInherit.Columns.Contains("N"))
                dgvInherit.Columns["N"].HeaderText = "N";

            if (dgvInherit.Columns.Contains("Description"))
                dgvInherit.Columns["Description"].HeaderText = "Ghi chú";

            if (dgvInherit.Columns.Contains("Grade_Name"))
                dgvInherit.Columns["Grade_Name"].Frozen = true;
        }
	}
}
