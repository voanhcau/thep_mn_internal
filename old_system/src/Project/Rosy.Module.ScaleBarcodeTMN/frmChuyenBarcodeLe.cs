using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosyList;
using RosySystem.Customize;
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;
using RosySystem.Element;

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmChuyenBarcodeLe : RosySystem.Customize.frmView
	{
		

		private DataTable dtBarcodePT;
		private BindingSource bdsBarcodePT = new BindingSource();		
		private DataRow drCurrent;
        public bool isAccept = false;
        string strMa_Kho = string.Empty;
        
		#region Phuong thuc

        public frmChuyenBarcodeLe()
		{
			InitializeComponent();
            btExit.Click += new EventHandler(btExit_Click);
            dgvReplaceBarcodePT.CellValidated += new DataGridViewCellEventHandler(dgvReplaceBarcodePT_CellValidated);
            dgvReplaceBarcodePT.CellClick += new DataGridViewCellEventHandler(dgvReplaceBarcodePT_CellClick);
            
		}

		private void Build()
		{
   
            dgvReplaceBarcodePT.strZone = "CHUYENBARCODELE";
            dgvReplaceBarcodePT.Dock = DockStyle.Fill;

            dgvReplaceBarcodePT.BuildGridView(false);

            foreach (DataGridViewColumn dgvc in dgvReplaceBarcodePT.Columns)
                dgvc.ReadOnly = true;

            if (dgvReplaceBarcodePT.Columns.Contains("IS_KHO_LE"))
                dgvReplaceBarcodePT.Columns["IS_KHO_LE"].ReadOnly = false;
        
		}

		private void FillData()
		{
           
            Hashtable htPara = new Hashtable();

            htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
            htPara.Add("MA_KHO", strMa_Kho);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);
            dtBarcodePT = SQLExec.ExecuteReturnDt("sp_GetTonBarcodeKKV", htPara, CommandType.StoredProcedure);

			bdsBarcodePT.DataSource = dtBarcodePT;
			dgvReplaceBarcodePT.DataSource = bdsBarcodePT;
            
		}

        new public void Load(string strMa_Kho, string strMa_Vt_Sp)
		{
            this.strMa_Kho = strMa_Kho;
           txtMa_Vt_Sp.Text = strMa_Vt_Sp;

			Build();
			FillData();

			BindingLanguage();

			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;

			

			return bvalid;
		}
       
        void btAccept_Click(object sender, EventArgs e)
        {
            isAccept = true;
        
            this.Close();
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		#endregion

		#region Su kien
        //void btInherit_Click(object sender, EventArgs e)
        //{
        //    frmInherit_LXH frm = new frmInherit_LXH();
        //    frm.Load();

        //    if (frm.is_Accept)
        //    {
        //        if (frm.dtInheritVoucher.Select("Chon = true").Length == 0)
        //            return;

        //        DataRow drInheritVoucher = frm.dtInheritVoucher.Select("Chon = 1")[0];

               
        //        Hashtable ht = new Hashtable();
        //        ht.Add("BARCODE", "");
        //        ht.Add("SO_LXH", drInheritVoucher["So_Ct"].ToString());
        //        txtBarcode.Text = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetBarcodeLe(@Barcode,@So_LXH)", ht, CommandType.Text);
                
        //        txtSo_Ct_LXH.Text = drInheritVoucher["So_Ct"].ToString();
        //        txtMa_Vt_Sp.Text = drInheritVoucher["Ma_Vt"].ToString();
        //        lbtTen_Vt_Sp.Text = drInheritVoucher["Ten_Vt"].ToString() + " số cây cần xuất " + drInheritVoucher["So_Luong_Cay_Le"].ToString();
        //        numSo_Luong_LXH.Value = Convert.ToDouble(drInheritVoucher["So_Luong_Cay_Le"]);
        //        //Lấy thông tin barcode theo mã SP
        //        if (txtMa_Vt_Sp.Text != "")
        //        {
        //            Hashtable htPara = new Hashtable();

        //            htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
        //            dtBarcodePT = SQLExec.ExecuteReturnDt("sp_GetBarcodeLeLXH_Xuat", htPara, CommandType.StoredProcedure);

        //            bdsBarcodePT.DataSource = dtBarcodePT;
        //            dgvReplaceBarcodePT.DataSource = bdsBarcodePT;
        //        }
        //    }
        //}

       
        void dgvReplaceBarcodePT_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //dgvVoucher dgvEditCt = (dgvVoucher)sender;

            //drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;
            //DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            //string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            //if (Common.InlistLike(strColumnName, "NUM_BARS_XUAT,SO_LUONG_XUAT"))
            //{
            //    if (Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) != 0 && Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) > Convert.ToDouble(drCurrent["Num_Bars_Ton"]))
            //    {
            //        Common.MsgOk("Số lượng xuất không lớn hơn số tồn !!!");
            //        drCurrent["Num_Bars_Xuat"] = 0;// drCurrent["Num_Bars_Ton"];
            //    }
            //    else if (Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) != 0 && Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) > numSo_Luong_LXH.Value)
            //    {
            //        Common.MsgOk("Số lượng xuất không lớn hơn số LXH !!!");
            //        drCurrent["Num_Bars_Xuat"] = 0;// drCurrent["Num_Bars_Ton"];
            //    }
            //    double numBarWeight = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "BarWeight", txtMa_Vt_Sp.Text));
            //    double numLength = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Length", txtMa_Vt_Sp.Text));
            //    // Bằng thêm phần barem
            //    double numBarem = Math.Round((numBarWeight * numLength), 2);
            //    drCurrent["SO_LUONG_XUAT"] = Math.Round(Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) * numBarem, 0, MidpointRounding.AwayFromZero);
            //    //numTSo_Luong.Value = Common.SumDCValue(dtBarcodePT, "Num_Bars_Xuat", "");
                
            //}
           
        }
        void dgvReplaceBarcodePT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.InlistLike(strColumnName, "IS_KHO_LE"))
            {
                //kiểm tra xem có xuất chưa
                if (DataTool.SQLCheckExist("R05CTX_BARCODE_KKV", new string[] { "Barcode", "Ma_Kho" }, new object[] { drCurrent["Barcode"].ToString(), drCurrent["Ma_Kho"].ToString() }))
                {
                    Common.MsgOk("Barcode này đã được xuất không chuyển kho lẻ");
                    return;
                }
                else
                {
                    if (Common.MsgYes_No("Bạn có muốn tách barcode " + drCurrent["Barcode"] + " thành bó lẻ không?", "Y"))
                    {
                        //không cho gở kho lẻ
                        dgvReplaceBarcodePT[e.ColumnIndex, e.RowIndex].ReadOnly = true;

                        //LẤY NGÀY CHUYỂN KHO LẺ
                        Hashtable ht1 = new Hashtable();
                        ht1.Add("IS_KHO_LE", !(bool)drCurrent["IS_KHO_LE"]);
                        ht1.Add("BARCODE", drCurrent["BARCODE"]);
                        ht1.Add("NGAY_CHUYEN", DateTime.Now);
                        ht1.Add("USER_CHUYEN", Common.GetCurrent_Log());
                        //SQLExec.Execute("UPDATE R05CTN_BARCODE_KKV SET Is_Kho_Le = @Is_Kho_Le, Ngay_Chuyen = @Ngay_Chuyen, User_Chuyen = @User_Chuyen WHERE Barcode = @Barcode");
                        // LƯU DL VÀO R05CTN_BARCODE_KKV
                        string strSttN = string.Empty;
                        int iStt = 1;
                        strSttN = "A0107N" + String.Format("{0:ddMMyy}", DateTime.Now);
                        iStt = Convert.ToInt16(SQLExec.ExecuteReturnValue("SELECT ISNULL(RIGHT(MAX(Stt),3),1) FROM R80PH_BARCODE_KKV WHERE Stt LIKE '" + strSttN + "%'")) + 1;
                        strSttN = strSttN + SQLExec.ExecuteReturnValue("SELECT REPLACE(STR(" + iStt + ",3), ' ','0')").ToString();
                        // LƯU DL VÀO R05CTX_BARCODE_KKV
                        string strSttX = string.Empty;
                        strSttX = strSttN.Replace("N", "X");
                        Hashtable ht2 = new Hashtable();
                        ht2.Add("STTN", strSttN);
                        ht2.Add("STTX", strSttX);
                        ht2.Add("MA_KHO", drCurrent["MA_KHO"]);
                        ht2.Add("BARCODE", drCurrent["BARCODE"]);
                        ht2.Add("NGAY_CT", DateTime.Now.ToShortDateString());
                        ht2.Add("CREATE_LOG", Common.GetCurrent_Log());
                        ht2.Add("MA_DVCS", Element.sysMa_DvCs);
                        SQLExec.Execute("sp_UpdateCtNXBarcodeLeKKV", ht2, CommandType.StoredProcedure);

                        drCurrent["Is_Kho_Le"] = !(bool)drCurrent["Is_Kho_Le"];
                    }
                    else
                    {
                        drCurrent["Is_Kho_Le"] = !(bool)drCurrent["Is_Kho_Le"];
                        return;
                    }
                }
            }
        }
		#endregion

      

      
        
	}
}