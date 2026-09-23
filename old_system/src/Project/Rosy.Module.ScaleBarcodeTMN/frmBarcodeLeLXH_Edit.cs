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
	public partial class frmBarcodeLeLXH_Edit : RosySystem.Customize.frmView
	{
		

		private DataTable dtBarcodePT;
		private BindingSource bdsBarcodePT = new BindingSource();		
		private DataRow drCurrent;
        public bool isAccept = false;
        string strMa_Kho = string.Empty;
        string strSo_LXH_Goc = string.Empty;
		#region Phuong thuc

        public frmBarcodeLeLXH_Edit()
		{
			InitializeComponent();

            btAccept.Click += new EventHandler(btAccept_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btInherit.Click += new EventHandler(btInherit_Click);
            dgvReplaceBarcodePT.CellValidated += new DataGridViewCellEventHandler(dgvReplaceBarcodePT_CellValidated);
            dgvReplaceBarcodePT.CellClick += new DataGridViewCellEventHandler(dgvReplaceBarcodePT_CellClick);
            
		}

        

        

		private void Build()
		{
   
            dgvReplaceBarcodePT.strZone = "BARCODELELXH_XUAT";
            dgvReplaceBarcodePT.Dock = DockStyle.Fill;

            dgvReplaceBarcodePT.BuildGridView(false);

            foreach (DataGridViewColumn dgvc in dgvReplaceBarcodePT.Columns)
                dgvc.ReadOnly = true;

            if (dgvReplaceBarcodePT.Columns.Contains("CHON"))
                dgvReplaceBarcodePT.Columns["CHON"].ReadOnly = false;
            if (dgvReplaceBarcodePT.Columns.Contains("NUM_BARS_XUAT"))
                dgvReplaceBarcodePT.Columns["NUM_BARS_XUAT"].ReadOnly = false;
            if (dgvReplaceBarcodePT.Columns.Contains("SO_LUONG_XUAT"))
                dgvReplaceBarcodePT.Columns["SO_LUONG_XUAT"].ReadOnly = false;
		}

		private void FillData()
		{
            if(txtMa_Vt_Sp.Text != "")
            {
                Hashtable htPara = new Hashtable();

                htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
                htPara.Add("MA_KHO", strMa_Kho);
                dtBarcodePT = SQLExec.ExecuteReturnDt("sp_GetBarcodeLeLXHKKV_Xuat", htPara, CommandType.StoredProcedure);

			    bdsBarcodePT.DataSource = dtBarcodePT;
			    dgvReplaceBarcodePT.DataSource = bdsBarcodePT;
            }
		}

        new public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strMa_Kho)
		{
            this.strMa_Kho = strMa_Kho;
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
        private void Save()
        {        
            //DataRow drDmCtAuto = DataTool.SQLGetDataRowByID("R81DMCTAUTO", "Ma_Ct", "PXTH");

            //    //Tu dong tao phieu xuat kho chan.
            //    //Insert vao R80PH_SCALE
            //    Hashtable htPara = new Hashtable();
            //    htPara.Add("STRNEW_EDIT", "N");
            //    htPara.Add("MA_CT", drDmCtAuto["Ma_Ct"]);
            //    htPara.Add("MA_DT", drDmCtAuto["Ma_Dt"]);
            //    htPara.Add("MA_VT_SP", drDmCtAuto["Ma_Vt_Sp"]);
            //    htPara.Add("DIEN_GIAI", "XUẤT BARCODE LẺ PHỤC VỤ BÁN HÀNG");
            //    htPara.Add("SO_XE", drDmCtAuto["So_Xe"]);
            //    htPara.Add("SO_XA_LAN_TAU", drDmCtAuto["So_Xa_Lan_Tau"]);
            //    htPara.Add("DUYET", true);
            //    htPara.Add("LOAI_CT", "2");
            //    htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
            //    htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            //    string strStt = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_PH_Scale", htPara, CommandType.StoredProcedure));
            //    if (strStt != string.Empty)
            //    {
            //        //Insert vao Ct - R05CTX_BARCODE
            //        //this.UpdateCtX_Barcode(strStt, drBarcode);
            //    }
            //    else
            //    {
            //        Common.MsgCancel("Có lỗi xảy ra khi tạo phiếu!");
            //        return;
            //    } 
           
            
            
			
            // Lưu dữ liệu vào R05BARCODELE
            if (dtBarcodePT.Select("Chon = 1") == null)
                return;

            if (numSo_Luong_CL.Value < 0)
            {
                Common.MsgOk("Số lượng barcode lớn hơn số lượng LXH. Không được phép lưu !!!");
                return;
            }
            //Xử lý SL tổng
            double numBarWeight = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "BarWeight", txtMa_Vt_Sp.Text));
            double numLength = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Length", txtMa_Vt_Sp.Text));
            // Bằng thêm phần barem
            double numBarem = Math.Round((numBarWeight * numLength), 2);
            double dbSo_Luong_Barem = Math.Round(numTSo_Luong.Value * numBarem, 0, MidpointRounding.AwayFromZero);
            double dbSo_Luong_Xuat = Common.SumDCValue(dtBarcodePT, "So_Luong_Xuat", "");
            if (dbSo_Luong_Barem != dbSo_Luong_Xuat && txtMa_Vt_Sp.Text.StartsWith("BD"))
            {
                double dbSo_Luong_CL = dbSo_Luong_Barem - dbSo_Luong_Xuat;
                double dbSl_Max = Common.MaxDCValue(dtBarcodePT, "So_Luong_Xuat");
                foreach (DataRow dr in dtBarcodePT.Select("Chon = true AND So_Luong_Xuat = " + dbSl_Max + ""))
                {
                    dr["So_Luong_Xuat"] = Convert.ToDouble(dr["So_Luong_Xuat"]) + dbSo_Luong_CL;
                }
            }
            foreach (DataRow dr in dtBarcodePT.Select("Chon = true"))
            {
                Hashtable htBLXH = new Hashtable();
                htBLXH.Add("BARCODE_LXH", txtBarcode.Text);
                htBLXH.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
                htBLXH.Add("MA_KHO", strMa_Kho);
                htBLXH.Add("BARCODE", dr["Barcode"]);
                htBLXH.Add("NUM_BARS", dr["Num_Bars_Xuat"]);
                htBLXH.Add("SO_LUONG", dr["So_Luong_Xuat"]);
                htBLXH.Add("NGAY_CT", Convert.ToDateTime(DateTime.Now).ToShortDateString());
                htBLXH.Add("SO_LXH", txtSo_Ct_LXH.Text);
                htBLXH.Add("SO_LXH_GOC", strSo_LXH_Goc);
                htBLXH.Add("CREATE_LOG", Common.GetCurrent_Log());
                htBLXH.Add("LASTMODIFY_LOG", string.Empty);
                htBLXH.Add("MA_DATA", Element.sysMa_Data);

                SQLExec.Execute("Sp_Update_BarcodeLe_LXH_KKV", htBLXH, CommandType.StoredProcedure);
            }
            ////Lưu dữ liệu vào CTNX
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

            ht2.Add("BARCODE_LXH", txtBarcode.Text);
            ht2.Add("NGAY_CT", DateTime.Now.ToShortDateString());
            ht2.Add("CREATE_LOG", Common.GetCurrent_Log());
            ht2.Add("MA_DVCS", Element.sysMa_DvCs);
            if (SQLExec.Execute("sp_UpdateCtNXBarcodeLeLXHKKV", ht2, CommandType.StoredProcedure))
            {
                Common.MsgCancel("Đã hoàn thành!!!");
            }



            ////string strStt = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_PH_Scale", htPara, CommandType.StoredProcedure));
            //if (strStt != string.Empty)
            //{
            //    //Insert vao Ct - R05CTX_BARCODE
            //    Hashtable htBarcodeXuat = new Hashtable();
            //    htBarcodeXuat.Add("BARCODE_LXH", txtBarcode.Text);
            //    htBarcodeXuat.Add("STT", strStt);

            //    SQLExec.Execute("sp_Update_BarcodeLe_LXH_Xuat", htBarcodeXuat, CommandType.StoredProcedure);
            //}
            else
            {
                Common.MsgCancel("Có lỗi xảy ra khi tạo phiếu!");
                return;
            }
        }
        void btAccept_Click(object sender, EventArgs e)
        {
            isAccept = true;
            Save();
            this.Close();
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		#endregion

		#region Su kien
        void btInherit_Click(object sender, EventArgs e)
        {

            frmInherit_LXHKKV frm = new frmInherit_LXHKKV();
            frm.Load(strMa_Kho);

            if (frm.is_Accept)
            {
                if (frm.dtInheritVoucher.Select("Chon = true").Length == 0)
                    return;

                DataRow drInheritVoucher = frm.dtInheritVoucher.Select("Chon = 1")[0];

               
                Hashtable ht = new Hashtable();
                ht.Add("BARCODE", "");
                ht.Add("SO_LXH", drInheritVoucher["So_Ct"].ToString());
                txtBarcode.Text = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetBarcodeLeKKV(@Barcode,@So_LXH)", ht, CommandType.Text);
                
                txtSo_Ct_LXH.Text = drInheritVoucher["So_Ct"].ToString();
                txtMa_Vt_Sp.Text = drInheritVoucher["Ma_Vt"].ToString();
                lbtTen_Vt_Sp.Text = drInheritVoucher["Ma_Vt"].ToString().StartsWith("BD") ? drInheritVoucher["Ten_Vt"].ToString() + " số cây cần xuất " + drInheritVoucher["So_Luong_Cay_Le"].ToString() : drInheritVoucher["Ten_Vt"].ToString() + " số lượng cần xuất " + drInheritVoucher["So_Luong"].ToString();
                numSo_Luong_LXH.Value = drInheritVoucher["Ma_Vt"].ToString().StartsWith("BD") ? Convert.ToDouble(drInheritVoucher["So_Luong_Cay_Le"]) : Convert.ToDouble(drInheritVoucher["So_Luong"]);
                strSo_LXH_Goc = drInheritVoucher["So_LXH"].ToString();
                //Lấy thông tin barcode theo mã SP
                if (txtMa_Vt_Sp.Text != "")
                {
                    Hashtable htPara = new Hashtable();
                    htPara.Add("MA_KHO", strMa_Kho);
                    htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
                    dtBarcodePT = SQLExec.ExecuteReturnDt("sp_GetBarcodeLeLXHKKV_Xuat", htPara, CommandType.StoredProcedure);

                    bdsBarcodePT.DataSource = dtBarcodePT;
                    dgvReplaceBarcodePT.DataSource = bdsBarcodePT;
                }
            }
        }

       
        void dgvReplaceBarcodePT_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.InlistLike(strColumnName, "NUM_BARS_XUAT,SO_LUONG_XUAT"))
            {
                if (Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) != 0 && Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) > Convert.ToDouble(drCurrent["Num_Bars_Ton"]))
                {
                    Common.MsgOk("Số lượng xuất không lớn hơn số tồn !!!");
                    drCurrent["Num_Bars_Xuat"] = 0;// drCurrent["Num_Bars_Ton"];
                }
                else if (Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) != 0 && Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) > numSo_Luong_LXH.Value)
                {
                    Common.MsgOk("Số lượng xuất không lớn hơn số LXH !!!");
                    drCurrent["Num_Bars_Xuat"] = 0;// drCurrent["Num_Bars_Ton"];
                }
                double numBarWeight = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "BarWeight", txtMa_Vt_Sp.Text));
                double numLength = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Length", txtMa_Vt_Sp.Text));
                // Bằng thêm phần barem
                double numBarem = Math.Round((numBarWeight * numLength), 2);
                if (txtMa_Vt_Sp.Text.StartsWith("BD"))
                {
                    drCurrent["SO_LUONG_XUAT"] = Math.Round(Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) * numBarem, 0, MidpointRounding.AwayFromZero);
                    numTSo_Luong.Value = Common.SumDCValue(dtBarcodePT, "Num_Bars_Xuat", "");
                }
                else
                    numTSo_Luong.Value = Common.SumDCValue(dtBarcodePT, "So_Luong_Xuat", "");
            }
           
        }
        void dgvReplaceBarcodePT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.InlistLike(strColumnName, "CHON"))
            {
                double numBarWeight = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "BarWeight", txtMa_Vt_Sp.Text));
                double numLength = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Length", txtMa_Vt_Sp.Text));
                // Bằng thêm phần barem
                double numBarem = Math.Round((numBarWeight * numLength), 2);
                if (txtMa_Vt_Sp.Text.StartsWith("BD"))
                {
                    if ((numSo_Luong_LXH.Value - numTSo_Luong.Value) >= Convert.ToDouble(drCurrent["Num_Bars_Ton"]))
                    {
                        drCurrent["Num_Bars_Xuat"] = drCurrent["Num_Bars_Ton"];
                        drCurrent["SO_LUONG_XUAT"] = drCurrent["So_Luong_Ton"];
                        //drCurrent["SO_LUONG_XUAT"] = Math.Round(Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) * numBarem, 0, MidpointRounding.AwayFromZero);
                        numTSo_Luong.Value = Common.SumDCValue(dtBarcodePT, "Num_Bars_Xuat", "");
                        numSo_Luong_CL.Value = numSo_Luong_LXH.Value - numTSo_Luong.Value;
                    }
                    else
                    {
                        drCurrent["Num_Bars_Xuat"] = numSo_Luong_LXH.Value - numTSo_Luong.Value;
                        if (Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) - Convert.ToDouble(drCurrent["Num_Bars_Ton"]) != 0)
                        {
                            drCurrent["SO_LUONG_XUAT"] = Math.Round(Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) * numBarem, 0, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            drCurrent["So_Luong_Xuat"] = drCurrent["So_Luong_Ton"];
                        }
                        numTSo_Luong.Value = Common.SumDCValue(dtBarcodePT, "Num_Bars_Xuat", "");
                        numSo_Luong_CL.Value = numSo_Luong_LXH.Value - numTSo_Luong.Value;
                    }
                }
                else
                {
                    if ((numSo_Luong_LXH.Value - numTSo_Luong.Value) >= Convert.ToDouble(drCurrent["So_Luong_Ton"]))
                    {
                        drCurrent["So_Luong_Xuat"] = drCurrent["So_Luong_Ton"];
                        //drCurrent["SO_LUONG_XUAT"] = Math.Round(Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) * numBarem, 0, MidpointRounding.AwayFromZero);
                        numTSo_Luong.Value = Common.SumDCValue(dtBarcodePT, "So_Luong_Xuat", "");
                        numSo_Luong_CL.Value = numSo_Luong_LXH.Value - numTSo_Luong.Value;
                    }
                    else
                    {
                        drCurrent["So_Luong_Xuat"] = numSo_Luong_LXH.Value - numTSo_Luong.Value;
                        //if (Convert.ToDouble(drCurrent["So_Luong_Xuat"]) - Convert.ToDouble(drCurrent["So_Luong_Ton"]) != 0)
                        //{
                        //    drCurrent["SO_LUONG_XUAT"] = Math.Round(Convert.ToDouble(drCurrent["Num_Bars_Xuat"]) * numBarem, 0, MidpointRounding.AwayFromZero);
                        //}
                        //else
                        //{
                        //    drCurrent["So_Luong_Xuat"] = drCurrent["So_Luong_Ton"];
                        //}
                        numTSo_Luong.Value = Common.SumDCValue(dtBarcodePT, "So_Luong_Xuat", "");
                        numSo_Luong_CL.Value = numSo_Luong_LXH.Value - numTSo_Luong.Value;
                    }
                }
            }
        }
		#endregion

      

      
        
	}
}