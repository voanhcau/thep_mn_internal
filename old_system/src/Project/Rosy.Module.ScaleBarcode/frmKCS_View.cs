using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Library;
using System.Collections;

using RosySystem;
using RosySystem.Common;
using System.Data.SqlClient;
using RosySystem.Public;
using RosySystem.Customize;

namespace RosyModule.ScaleBarcode
{
	public partial class frmKCS_View : RosySystem.Customize.frmView
	{
		BindingSource bdsKCS = new BindingSource();
		DataTable dtKCS;
		DataRow drCurrent;
		string strFilter_Update = "A";
		string strLoai = "TMN";
		public frmKCS_View()
		{
			InitializeComponent();
			this.btPrint.Click += new EventHandler(btPrint_Click);
			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.btEdit_CoTinh.Click += new EventHandler(btEdit_CoTinh_Click);
            this.btUpdate.Click += new EventHandler(btUpdate_Click);
            

			this.rdbFilter_Edit1.CheckedChanged += new EventHandler(rdbFilter_Edit_CheckedChanged);
			this.rdbFilter_Edit2.CheckedChanged += new EventHandler(rdbFilter_Edit_CheckedChanged);
			this.rdbFilter_Edit3.CheckedChanged += new EventHandler(rdbFilter_Edit_CheckedChanged);
            
			this.rdbGC.CheckedChanged += RdbAll_CheckedChanged;
			this.rdbTMN.CheckedChanged += RdbAll_CheckedChanged;

			this.dgvKCS.CellContentClick += new DataGridViewCellEventHandler(dgvKCS_CellContentClick);
			this.dgvKCS.CellContentDoubleClick += new DataGridViewCellEventHandler(dgvKCS_CellContentDoubleClick);
			this.dgvKCS.CellValidating += new DataGridViewCellValidatingEventHandler(dgvKCS_CellValidating);
			this.dgvKCS.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvKCS_DataBindingComplete);
			this.dgvKCS.KeyDown += new KeyEventHandler(dgvKCS_KeyDown);
			this.dgvKCS.ReadOnly = false;
		}

       

        public void Load()
		{
			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

            //check permission
            if(!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
            {
                btUpdate.Enabled = false;
                btEdit_CoTinh.Enabled = false;
            }

			this.Build();
			this.BindingLanguage();
			this.BuildDataGridView();
			this.Show();
		}

		private void Build()
		{
			dgvKCS.strZone = "KCS";
			dgvKCS.BuildGridView();

			//Danh mục sản phẩm
			DataTable dtDmSize = DataTool.SQLGetDataTable("R81DMSIZE", "", "", "Ma_Size");
			
			DataRow drDmVt_Empty = dtDmSize.NewRow();
			drDmVt_Empty["Ma_Size"] = drDmVt_Empty["Ten_Size"] = string.Empty;
			dtDmSize.Rows.Add(drDmVt_Empty);
			
			dtDmSize.DefaultView.Sort = "Ma_Size";
			cboMa_Size.DataSource = dtDmSize;
			cboMa_Size.DisplayMember = "Ten_Size";
			cboMa_Size.ValueMember = "Ma_Size";

			//Danh mục mác thép
			DataTable dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEP", "", "", "Grade_ID");

			DataRow drDmMacThep_Empty = dtDmMacThep.NewRow();
			drDmMacThep_Empty["Grade_Name"] = drDmMacThep_Empty["Grade_ID"] = string.Empty;
			dtDmMacThep.Rows.Add(drDmMacThep_Empty);

			dtDmMacThep.DefaultView.Sort = "Grade_ID";
			cboGrade_ID.DataSource = dtDmMacThep;
			cboGrade_ID.DisplayMember = "Grade_Name";
			cboGrade_ID.ValueMember = "Grade_ID";

			//Chất lượng
			DataTable dtDmCL = DataTool.SQLGetDataTable("R81DMCL", "", "", "Ma_CL");

			DataRow drDmCL_Empty = dtDmCL.NewRow();
			drDmCL_Empty["Ma_CL"] = drDmCL_Empty["Ten_CL"] = string.Empty;
			dtDmCL.Rows.Add(drDmCL_Empty);

			dtDmCL.DefaultView.Sort = "Ma_CL";
			cboMa_CL.DataSource = dtDmCL;
			cboMa_CL.DisplayMember = "Ten_CL";
			cboMa_CL.ValueMember = "Ma_CL";

			cboMa_Size.SelectedValue = cboGrade_ID.SelectedValue = cboMa_CL.SelectedValue = string.Empty;
			cboIs_OutPut.SelectedIndex = cboIs_Ton_Kho.SelectedIndex = cboStatus.SelectedIndex = 0;
		}

		private void BuildDataGridView()
		{
			this.dgvKCS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKCS.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (this.dgvKCS.Columns.Contains("Num_Bars"))
				this.dgvKCS.Columns["Num_Bars"].Frozen = true;

			if (dgvKCS.Columns.Contains("NGAY_NHAP"))
				dgvKCS.Columns["NGAY_NHAP"].HeaderText = "Ngày sản xuất";

			if (this.dgvKCS.Columns.Contains("Remark"))
				this.dgvKCS.Columns["Remark"].HeaderText = "Điểm KPH";

			if (dgvKCS.Columns.Contains("SO_LUONG"))
				dgvKCS.Columns["SO_LUONG"].HeaderText = "Khối lượng";

			if (dgvKCS.Columns.Contains("CHON"))
				dgvKCS.Columns["CHON"].HeaderText = "Chọn thêm bó";

            if (dgvKCS.Columns.Contains("IS_TL"))
                dgvKCS.Columns["IS_TL"].HeaderText = "Trả lại";

			string strColumn_Name = "NO_MELT,NO_MELT_CONFIRM,NUM_BARS,BARCODE,TEN_SIZE,LENGTH,SO_LUONG,SO_LUONG_BAREM,TRY_ID,GRADE_NAME,TEN_CL,IS_OUTPUTED,YEILD,TENSION,ELONG,BEND_TESTED,CA,NGAY_NHAP,NUM_LOT,LASTMODIFY_LOG_KCS";
			foreach (var strColumn in strColumn_Name.Split(','))
			{
				if (dgvKCS.Columns.Contains(strColumn))
					dgvKCS.Columns[strColumn].ReadOnly = true;
			}
		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			htPara.Add("BARCODE1", txtBarcode1.Text.Trim());
			htPara.Add("BARCODE2", txtBarcode2.Text.Trim());
			htPara.Add("MA_SIZE", cboMa_Size.SelectedValue);
			htPara.Add("GRADE_ID", cboGrade_ID.SelectedValue);
			htPara.Add("MA_CL", cboMa_CL.SelectedValue);
			htPara.Add("NUM_LOT", txtNum_Lot.Text.Trim());
			htPara.Add("CA", cboCa.SelectedItem);
			htPara.Add("XUONG", cboXuong.SelectedItem);
			htPara.Add("IS_OUTPUT", cboIs_OutPut.SelectedIndex == 0 || cboIs_OutPut.SelectedIndex == -1 ? "" : cboIs_OutPut.SelectedIndex == 2 ? "0" : Convert.ToString(cboIs_OutPut.SelectedIndex));
			htPara.Add("IS_TON_KHO", cboIs_Ton_Kho.SelectedIndex == 0 || cboIs_Ton_Kho.SelectedIndex == -1 ? "" : Convert.ToString(cboIs_Ton_Kho.SelectedIndex));
			htPara.Add("LOAI", strLoai);
			htPara.Add("STATUS", cboStatus.SelectedIndex == 0 || cboStatus.SelectedIndex == -1 ? "" : Convert.ToString(cboStatus.SelectedIndex));
			htPara.Add("FILTER_UPDATE", strFilter_Update); //Lọc để nhập hoặc nhập để sửa
			htPara.Add("MA_DATA", Element.sysMa_Data);

			dtKCS = SQLExec.ExecuteReturnDt("sp_GetDmBarcode_To_KCS", htPara, CommandType.StoredProcedure);

			if(!dtKCS.Columns.Contains("Chon"))
			{
				DataColumn dcAdd = new DataColumn("Chon", typeof(bool));
				dcAdd.DefaultValue = false;
				dtKCS.Columns.Add(dcAdd);
			}

			if (!dtKCS.Columns.Contains("So_Luong_Org"))
			{
				DataColumn dcAdd = new DataColumn("So_Luong_Org", typeof(double));
				dcAdd.DefaultValue = 0;
				dtKCS.Columns.Add(dcAdd);
			}

			bdsKCS.DataSource = dtKCS;
			dgvKCS.DataSource = bdsKCS;
			bdsKCS.Position = 0;

			bdsSearch = bdsKCS;
			ExportControl = dgvKCS;
		}

		void btEdit_CoTinh_Click(object sender, EventArgs e)
		{
			if (dtKCS == null || dtKCS.Rows.Count == 0)
				return;

			DataTable dtFilter = new DataTable();
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Barcode1", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Barcode2", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Size", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Grade_ID", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Cl", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Num_Lot", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ca", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			drFilter["Ngay_Ct1"] = dteNgay_Ct1.Text;
			drFilter["Ngay_Ct2"] = dteNgay_Ct2.Text;
			drFilter["Barcode1"] = txtBarcode1.Text;
			drFilter["Barcode2"] = txtBarcode2.Text;
			drFilter["Ma_Size"] = cboMa_Size.SelectedValue;
			drFilter["Grade_ID"] = cboMa_CL.SelectedValue;
			drFilter["Ma_Cl"] = cboMa_CL.SelectedValue;
			drFilter["Num_Lot"] = txtNum_Lot.Text.Trim();
			drFilter["Ca"] = cboCa.SelectedItem;

			frmKCS_Edit frm = new frmKCS_Edit();
			frm.Load(dtKCS, drFilter);

            if (frm.strBarcode2 != "" && frm.isAccept)
            {
                DateTime dteNgay_Ct = (DateTime)SQLExec.ExecuteReturnValue("SELECT Ngay_Nhap FROM R81DMBARCODE WHERE BarCode = '" + frm.strBarcode2 + "'");
				string strMa_Nvu = "NKTP";
				if(SQLExec.ExecuteReturnValue("SELECT So_Ct_LXH FROM R81DMBARCODE WHERE Barcode = '"+ frm.strBarcode2 + "'").ToString() == "GCPOM")
					strMa_Nvu = "NKGC";
				// Nhập thành phẩm
				if (Common.CheckDataLocked(Convert.ToDateTime(dteNgay_Ct)))
                {
                    Hashtable htPara = new Hashtable();

                    htPara.Add("NGAY_CT1", dteNgay_Ct);
                    htPara.Add("NGAY_CT2", dteNgay_Ct);
                    htPara.Add("MA_CT", "TP");
                    htPara.Add("MA_NVU", strMa_Nvu);
                    htPara.Add("EXCEPT_INHERITED", true);
                    htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
                    htPara.Add("IS_HACH_TOAN", true);
                    htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                    SQLExec.ExecuteReturnDs("sp_Inherit_Nhap_Barcode", htPara, CommandType.StoredProcedure);
                }

            }
            //xong

            if (frm.isAccept)
				this.FillData();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			Element.sysNgay_Ct1 = Library.StrToDate(dteNgay_Ct1.Text);
			Element.sysNgay_Ct2 = Library.StrToDate(dteNgay_Ct2.Text);

			this.FillData();
		}

		void dgvKCS_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsKCS.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsKCS.Current).Row;
			string strColumn_Name = dgvKCS.Columns[e.ColumnIndex].DataPropertyName;
			string strSQLExec = string.Empty;
			Hashtable htPara = new Hashtable();

			//Tinh trang KCS
			if (Common.CheckPermission("ACCESS_KCS_STATUS", enuPermission_Type.Allow_Access))
			{
				if (strColumn_Name == "CHON")
				{
					if (!(bool)drCurrent["Is_Wait_Process"])
						drCurrent[strColumn_Name] = false;

					drCurrent.AcceptChanges();
					return;
				}
                if (Common.Inlist(strColumn_Name, "IS_WAIT_PROCESS,IS_THU_PHAM"))
                {
                    //Kiem tra bo thep da kế thừa vào nhập thành phẩm. Neu ke thua roi thi khong xu ly tinh trang gi het
                    if (!(bool)Voucher_Scale.CheckInheritBarCode_PNTLB(drCurrent["Barcode"].ToString()))
                    {
                        Common.MsgCancel("Bó thép đã kế thừa nhập thành phẩm rồi không xử lý được");
                        drCurrent[strColumn_Name] = false;
                        drCurrent.RejectChanges();
                        return;
                    }
                }
				if (Common.Inlist(strColumn_Name, "IS_KHO_CHAN,IS_KHO_LE,IS_WAIT_PROCESS,IS_THU_PHAM"))
				{
					//Kiem tra bo thep da xuat chua. Neu xuat roi thi khong xu ly tinh trang gi het
					if (this.CheckOutPutAndInput(drCurrent["Barcode"].ToString()) != 0)
					{
						Common.MsgCancel("Bó thép đã xuất rồi không xử lý được");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}
                    ////Kiểm tra tình trạng bó thép đã kế thừa vào kế toán nhưng nhập vào PNTLB
                    if (!(bool)Voucher_Scale.CheckInheritBarCode_PNTLB(drCurrent["BarCode"].ToString()) && strColumn_Name == "IS_KHO_CHAN")
                    {
                        drCurrent[strColumn_Name] = false;
                        drCurrent.AcceptChanges();
                        return;
                    }
					double dbLength = drCurrent["Length"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Length"]);
					bool bIs_Wait_Process = drCurrent["Is_Wait_Process"] == DBNull.Value ? false : Convert.ToBoolean(drCurrent["Is_Wait_Process"]);
                    bool bIs_TL = drCurrent["Is_TL"] == DBNull.Value ? false : Convert.ToBoolean(drCurrent["Is_TL"]);

					if (strColumn_Name == "IS_KHO_LE" && dbLength == 0)//(dbLength >= 12 || dbLength == 0))
					{
						Common.MsgCancel("Bó thép có chiều dài không cho phép chuyển kho.");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}

					//Neu bo le ma la cho xu ly chuyen qua chan khong duoc
					if (strColumn_Name == "IS_KHO_CHAN" && drCurrent["Barcode"].ToString().StartsWith("L"))
					{
						Common.MsgCancel("Bó thép này là bó lẻ, không chuyển sang kho chẵn được.");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}

					//Neu bo thep duoc tach tu bo chan thi khong lam gi het
					if (drCurrent["Barcode_Org"].ToString() != string.Empty)
					{
                        Common.MsgCancel("Bó thép này được chuyển từ bó chẵn nên không chuyển tình trạng được");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}

					//Neu bo le ma la cho xu ly chuyen qua chan khong duoc
					if (strColumn_Name == "IS_KHO_CHAN" && Convert.ToBoolean(drCurrent["Is_Wait_Process"]) && drCurrent["Barcode"].ToString().StartsWith("L"))
					{
                        Common.MsgCancel("Bó thép này là bó lẻ, không chuyển sang kho chẵn được.");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}

					//Neu bo le ma la thu pham qua chan khong duoc
					if (strColumn_Name == "IS_KHO_CHAN" && Convert.ToBoolean(drCurrent["Is_Thu_Pham"]) && drCurrent["Barcode"].ToString().StartsWith("L"))
					{
                        Common.MsgCancel("Bó thép này đang là bó lẻ, không chuyển sang bó chẵn được.");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}

					//Neu la chan ma cho xu ly chuyen qua le khong duoc
					if (strColumn_Name == "IS_KHO_LE" && Convert.ToBoolean(drCurrent["Is_Wait_Process"]) && !drCurrent["Barcode"].ToString().StartsWith("L"))
					{
                        Common.MsgCancel("Chuyển sang bó chẵn trước khi chuyển sang bó lẻ");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}

					//Neu la chan ma thu pham chuyen qua le khong duoc
					if (strColumn_Name == "IS_KHO_LE" && Convert.ToBoolean(drCurrent["Is_Thu_Pham"]) && !drCurrent["Barcode"].ToString().StartsWith("L"))
					{
                        Common.MsgCancel("Chuyển sang bó chẵn trước khi chuyển sang bó lẻ");
						drCurrent[strColumn_Name] = false;
						drCurrent.RejectChanges();
						return;
					}

					if ((bool)drCurrent[strColumn_Name] && strColumn_Name != "IS_THU_PHAM")
					{
						drCurrent[strColumn_Name] = true;
						drCurrent.AcceptChanges();
						return;
					}

					if (strColumn_Name == "IS_THU_PHAM")
					{
						drCurrent["IS_THU_PHAM"] = true;
                        drCurrent["IS_KHO_CHAN"] = drCurrent["IS_KHO_LE"] = drCurrent["IS_WAIT_PROCESS"] = drCurrent["IS_TL"] = false;

						frmBarcode_Waiting_Process frm = new frmBarcode_Waiting_Process();
						frm.Load(enuEdit.Edit, drCurrent);

						if (frm.isAccept)
						{
							Common.CopyDataRow(drCurrent, ((DataRowView)bdsKCS.Current).Row);

							if ((bool)drCurrent["Is_OutPut"])
								drCurrent["Is_OutPuted"] = "Cho phép xuất";
							else
								drCurrent["Is_OutPuted"] = "Không cho phép xuất";

							dtKCS.AcceptChanges();
						}
						else
							dtKCS.RejectChanges();

						return;
					}

					//Kiểm tra dữ liệu bị khóa chưa.
					if (Common.Inlist(strColumn_Name, "IS_KHO_CHAN,IS_WAIT_PROCESS,IS_THU_PHAM"))
					{
						if (!Voucher.CheckDataLocked_Barcode((DateTime)drCurrent["Ngay_Nhap"]))
						{
							Common.MsgCancel("Dữ liệu đã bị khóa.Vui lòng liên hệ với người dùng có quyền mở khóa");
							drCurrent[strColumn_Name] = false;
							drCurrent.AcceptChanges();
							return;
						}
					}

					if (Common.MsgYes_No("Bạn có chắc chắn chuyển tình trạng bó thép không?"))
					{
						//Lay lai du lieu. Tranh truong hop bi sai khi da filter san
						DataRow drBarcode = DataTool.SQLGetDataRowByID("R81DMBARCODE", "Barcode", (string)drCurrent["Barcode"]);

						if (strColumn_Name == "IS_KHO_CHAN")
						{
							drCurrent["IS_KHO_CHAN"] = true;
							
							//Kiểm tra xem Barcode này có kéo cơ tính chưa.
							if ((string)drBarcode["Try_ID"] == string.Empty)
								drCurrent["IS_OUTPUT"] = false;
							else
								drCurrent["IS_OUTPUT"] = true;
							
							drCurrent["MA_CL"] = "1";
                            drCurrent["IS_KHO_LE"] = drCurrent["IS_WAIT_PROCESS"] = drCurrent["IS_THU_PHAM"] = drCurrent["IS_TL"] = false;
						}
						else if (strColumn_Name == "IS_KHO_LE" && Convert.ToBoolean(drCurrent["Is_Kho_Chan"]))
						{
							if (!Common.CheckPermission("ACCESS_KHO_LE", enuPermission_Type.Allow_Access))
							{
								Common.MsgCancel("Bạn không có quyền tạo kho lẻ");
								drCurrent[strColumn_Name] = false;
								drCurrent.RejectChanges();
								return;
							}

							if (drBarcode != null)
							{
								if (!Convert.ToBoolean(drBarcode["Is_OutPut"]))
								{
									Common.MsgCancel("Bó thép này chưa được phép xuất kho.KCS đang cập nhật lại.Vui lòng lọc lại dữ li");
									drCurrent[strColumn_Name] = false;
									drCurrent.RejectChanges();
									return;
								}

								if ((string)drBarcode["Try_ID"] == string.Empty)
								{
									Common.MsgCancel("Bó thép này chưa cập nhật cơ tính");
									drCurrent[strColumn_Name] = false;
									drCurrent.RejectChanges();
									return;
								}

                                if (!Common.MsgYes_No("Bạn chọn Yes phần mềm tự động tạo phiếu xuất kho chẵn và nhập kho lẻ", "N"))
								{
									drCurrent[strColumn_Name] = false;
									drCurrent.AcceptChanges();
									return;
								}

								drCurrent["IS_KHO_LE"] = true;
								drCurrent["IS_KHO_CHAN"] = false;
								drCurrent["IS_OUTPUT"] = drBarcode["IS_OUTPUT"] = true;
								drCurrent["IS_WAIT_PROCESS"] = drBarcode["IS_WAIT_PROCESS"] = drCurrent["IS_THU_PHAM"] = drBarcode["IS_THU_PHAM"] = false;

								DataRow drDmCtAuto = DataTool.SQLGetDataRowByID("R81DMCTAUTO", "Ma_Ct", "PXTH");

								//Tu dong tao phieu xuat kho chan.
								//Insert vao R80PH_SCALE
								htPara = new Hashtable();
								htPara.Add("STRNEW_EDIT", "N");
								htPara.Add("MA_CT", drDmCtAuto["Ma_Ct"]);
								htPara.Add("MA_DT", drDmCtAuto["Ma_Dt"]);
								htPara.Add("MA_VT_SP", drDmCtAuto["Ma_Vt_Sp"]);
								htPara.Add("DIEN_GIAI", drDmCtAuto["Dien_Giai"]);
								htPara.Add("SO_XE", drDmCtAuto["So_Xe"]);
								htPara.Add("SO_XA_LAN_TAU", drDmCtAuto["So_Xa_Lan_Tau"]);
								htPara.Add("DUYET", true);
								htPara.Add("LOAI_CT", "2");
								htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
								htPara.Add("MA_DVCS", Element.sysMa_DvCs);

								string strStt = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_PH_Scale", htPara, CommandType.StoredProcedure));
								if (strStt != string.Empty)
								{
									//Insert vao Ct - R05CTX_BARCODE
									this.UpdateCtX_Barcode(strStt, drBarcode);
								}
								else
								{
									Common.MsgCancel("Có lỗi xảy ra khi tạo phiếu!");
									return;
								}

								//Tu dong tao barcode kho le
								htPara = new Hashtable();
								htPara.Add("STRNEW_EDIT", "L");
								htPara.Add("BARCODE", drBarcode["Barcode"]);
								htPara.Add("MA_SIZE", drBarcode["Ma_Size"]);
								htPara.Add("MA_VT_SP", drBarcode["Ma_Vt_Sp"]);
								htPara.Add("MA_CA", drBarcode["Ma_Ca"]);
								htPara.Add("STANDARD_ID", drBarcode["Standard_ID"]);
								htPara.Add("GRADE_ID", drBarcode["Grade_ID"]);
								htPara.Add("MA_CL", drBarcode["Ma_CL"]);
								htPara.Add("LOT_ID", drBarcode["Lot_ID"]);
								htPara.Add("NUM_LOT", drBarcode["Num_Lot"]);
								htPara.Add("NO_MELT", drBarcode["No_Melt"]);
								htPara.Add("NO_MELT_CONFIRM", drBarcode["No_Melt_Confirm"]);
								htPara.Add("NUM_BARS", drBarcode["Num_Bars"]);
								htPara.Add("LENGTH", drBarcode["Length"]);
								htPara.Add("SO_LUONG", drBarcode["So_Luong"]);
								htPara.Add("SO_LUONG_BAREM", drBarcode["So_Luong_Barem"]);
								htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
								htPara.Add("LASTMODIFY_LOG", string.Empty);
								htPara.Add("TRY_ID", drBarcode["Try_ID"]);
								htPara.Add("YEILD", drBarcode["Yeild"]);
								htPara.Add("TENSION", drBarcode["Tension"]);
								htPara.Add("ELONG", drBarcode["ELong"]);
								htPara.Add("BEND_TEST", drBarcode["Bend_Test"]);
								htPara.Add("IS_OUTPUT", drBarcode["IS_OUTPUT"]);
								htPara.Add("REMARK", drBarcode["Remark"]);
								htPara.Add("REMARK_KCS", drBarcode["Remark_KCS"]);
								htPara.Add("LASTMODIFY_LOG_KCS", drBarcode["LastModify_Log_KCS"]);
								htPara.Add("NUM_BARS_EMBRYOS", drBarcode["Num_Bars_Embryos"]);
								htPara.Add("LY_DO", drBarcode["Ly_Do"]);

								htPara.Add("BARCODE_ORG", drBarcode["Barcode"]);
								htPara.Add("IS_WAIT_PROCESS", drBarcode["Is_Wait_Process"]);
								htPara.Add("DATE_PROCESS", drBarcode["Date_Process"] == DBNull.Value ? "19000101" : drBarcode["Date_Process"]);
								htPara.Add("INPUT_TYPE", 0);
								htPara.Add("SO_CT_LXH", drBarcode["So_Ct_LXH"]);
								htPara.Add("IS_BAREM", drBarcode["Is_Barem"]);
								htPara.Add("IS_THU_PHAM", drBarcode["Is_Thu_Pham"]);
								htPara.Add("MA_DATA", Element.sysMa_Data);

								SQLExec.Execute("sp_Update_DmBarcode", htPara, CommandType.StoredProcedure);
								drCurrent.AcceptChanges();
								return;
							}
							else
							{
								Common.MsgCancel("Không tồn tại bó thép này");
								return;
							}
						}
						else if (strColumn_Name == "IS_KHO_LE")
						{
							drCurrent["IS_KHO_LE"] = true;
							//Kiểm tra xem Barcode này có kéo cơ tính chưa.
							if ((string)drBarcode["Try_ID"] == string.Empty)
								drCurrent["IS_OUTPUT"] = false;
							else
								drCurrent["IS_OUTPUT"] = true;

							drCurrent["MA_CL"] = "1";
                            drCurrent["IS_KHO_CHAN"] = drCurrent["IS_WAIT_PROCESS"] = drCurrent["IS_THU_PHAM"] = drCurrent["IS_TL"] = false;
						}
						else if (strColumn_Name == "IS_WAIT_PROCESS")
						{
							drCurrent["IS_WAIT_PROCESS"] = true;
							drCurrent["MA_CL"] = "2";
							drCurrent["IS_OUTPUT"] = false;
                            drCurrent["IS_KHO_CHAN"] = drCurrent["IS_KHO_LE"] = drCurrent["IS_THU_PHAM"] = drCurrent["IS_TL"] = false;
						}

                        strSQLExec = "UPDATE R81DMBARCODE SET Ma_CL = @Ma_CL, Is_OutPut = @Is_OutPut, Is_Wait_Process = @Is_Wait_Process, Is_TL = @Is_TL, Is_Thu_Pham = @Is_Thu_Pham, " +
                                    " LastModify_Log_Status = @LastModify_Log_Status, Date_Process = @Date_Process, Ngay_XLNTL = @Ngay_XLNTL WHERE Barcode = @Barcode";
						htPara = new Hashtable();
						htPara["MA_CL"] = drCurrent["Ma_CL"];
						htPara["IS_OUTPUT"] = drCurrent["Is_OutPut"];
						htPara["IS_WAIT_PROCESS"] = drCurrent["Is_Wait_Process"];
						htPara["IS_THU_PHAM"] = drCurrent["Is_Thu_Pham"];
                        htPara["IS_TL"] = drCurrent["Is_TL"];
                        htPara["NGAY_XLNTL"] = bIs_TL ? Voucher.GetDate_Server() : Element.sysNgay_Min;
						htPara["LASTMODIFY_LOG_STATUS"] = Common.GetCurrent_Log();
						//Tu bo cho xu ly ma chuyen sang bo chan thi bat buoc phai ghi ngay xu ly.

                        //Bang xu ly lai 
                        if (bIs_Wait_Process && drCurrent["Date_Process"].ToString() == "")
                        {
                            DateTime dtDate_Process = Voucher.GetDate_Server();

                            if (drCurrent["Ma_Ca"].ToString() == SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Ca) FROM R81DMCA WHERE Loai = 'CAN' AND Ngay_Sx <= '" + Voucher.GetDate_Server().ToShortDateString() + "'").ToString())
                                dtDate_Process = Convert.ToDateTime(drCurrent["Ngay_Nhap"]);
                            //htPara["DATE_PROCESS"] = bIs_Wait_Process && drCurrent["Date_Process"].ToString() == "" ? Voucher.GetDate_Server() : drCurrent["Date_Process"] == DBNull.Value ? "19000101" : drCurrent["Date_Process"];
                          
                            htPara["DATE_PROCESS"] = dtDate_Process;
                        }
                        else
                            htPara["DATE_PROCESS"] = drCurrent["Date_Process"] == DBNull.Value ? "19000101" : drCurrent["Date_Process"];
                        //xong
                        htPara["BARCODE"] = drCurrent["Barcode"];

						try
						{
							RosySystem.Data.SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

							if (drCurrent.Table.Columns.Contains("Ten_CL"))
								drCurrent["Ten_CL"] = DataTool.SQLGetNameByCode("R81DMCL", "Ma_CL", "Ten_CL", drCurrent["Ma_CL"].ToString());

							if (drCurrent.Table.Columns.Contains("Date_Process"))
								drCurrent["Date_Process"] = bIs_Wait_Process ? Voucher.GetDate_Server() : Element.sysNgay_Min;

                            if (drCurrent.Table.Columns.Contains("Ngay_XLNTL"))
                                drCurrent["Ngay_XLNTL"] = bIs_TL ? Voucher.GetDate_Server() : Element.sysNgay_Min;

							if ((bool)drCurrent["Is_OutPut"])
								drCurrent["Is_OutPuted"] = "Cho phép xuất";
							else
								drCurrent["Is_OutPuted"] = "Không cho phép xuất";

							drCurrent.AcceptChanges();
						}
						catch (Exception ex)
						{
							Common.MsgCancel("Có lỗi cập nhật");
							return;
						}
					}
					else
					{
						drCurrent[strColumn_Name] = false;
						drCurrent.AcceptChanges();
					}
				}
			}
			else
			{
				this.dgvKCS.CurrentCell.DataGridView.CancelEdit();
			}
		}

		private void UpdateCtX_Barcode(string strStt, DataRow drCurrent)
		{
			string strBarcode = drCurrent["Barcode"].ToString();
			string strSQLExec =
				@"SELECT T1.*,
						T1.So_Luong + ISNULL(T3.So_Luong, 0) - ISNULL(T2.So_Luong, 0) AS So_Luong_Current,
						T1.Num_Bars + ISNULL(T3.Num_Bars, 0) - ISNULL(T2.Num_Bars, 0) AS Num_Bars_Current,
						CASE WHEN T4.Ngay_Sx IS NULL THEN T1.Ngay_Nhap ELSE T4.Ngay_Sx END AS Ngay_Nhap, CASE WHEN T4.Ca IS NULL THEN T1.Ma_Ca ELSE T4.Ca END AS Ca,
						T5.Ten_Size, T6.Grade_Name, T7.Standard_Name, T8.Ten_CL
					FROM R81DMBARCODE T1 WITH(NOLOCK)
							LEFT JOIN(SELECT Barcode, ISNULL(SUM(So_Luong), 0) AS So_Luong, ISNULL(SUM(Num_Bars), 0) AS Num_Bars
											FROM R05CTX_BARCODE WITH(NOLOCK) WHERE Stt <> '" + strStt + "' AND Barcode = '" + strBarcode + "' GROUP BY Barcode) T2 ON T1.Barcode = T2.Barcode" + @"
							LEFT JOIN(SELECT Barcode, ISNULL(SUM(So_Luong), 0) AS So_Luong, ISNULL(SUM(Num_Bars), 0) AS Num_Bars
											FROM R05CTN_BARCODE WITH(NOLOCK) WHERE Barcode = '" + strBarcode + "' GROUP BY Barcode) T3 ON T1.Barcode = T3.Barcode" + @"
							LEFT JOIN R81DMCA T4 WITH(NOLOCK) ON T1.Ma_Ca = T4.Ma_Ca
							LEFT JOIN R81DMSIZE T5 WITH(NOLOCK) ON T1.Ma_Size = T5.Ma_Size
							LEFT JOIN R81DMMACTHEP T6 WITH(NOLOCK) ON T1.Grade_ID = T6.Grade_ID
							LEFT JOIN R81DMSTANDARD T7 WITH(NOLOCK) ON T1.Standard_ID = T7.Standard_ID
							LEFT JOIN R81DMCL T8 WITH(NOLOCK) ON T1.Ma_CL = T8.Ma_CL
					WHERE T1.Barcode = '" + strBarcode + "' AND T1.So_Luong + ISNULL(T3.So_Luong,0) - ISNULL(T2.So_Luong,0) <> 0";

			DataTable dtBarcode = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);

			DataRow drEditPh = DataTool.SQLGetDataRowByID("R80PH_SCALE", "Stt", strStt);
			
			DataTable dtEditCt = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale_Ct", new string[] { "Ma_Ct", "Stt" }, new object[] { "PXTH", strStt }, CommandType.StoredProcedure);
			
			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

			DataRow drDmBarcode = dtBarcode.Rows[0];
			DataRow drNewRow = dtEditCt.NewRow();
			Common.SetDefaultDataRow(ref drNewRow);
			
			drNewRow["Stt"] = strStt;
			drNewRow["Stt0"] = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0") + 1);
			drNewRow["Ma_Nvu"] = "PX30";
			drNewRow["Ma_Ct"] = drEditPh["Ma_Ct"];
			drNewRow["So_Ct"] = strStt;
			drNewRow["Ngay_Ct"] = drEditPh["Ngay_Ct"];
			drNewRow["Ma_Dt"] = drEditPh["Ma_Dt"];
			drNewRow["Dien_Giai"] = drEditPh["Dien_Giai"];

			drNewRow["Barcode"] = drDmBarcode["Barcode"];
			drNewRow["Ma_Vt_Sp"] = drDmBarcode["Ma_Vt_Sp"];

			drNewRow["Ma_Size"] = drDmBarcode["Ma_Size"];
			drNewRow["Ten_Size"] = drDmBarcode["Ten_Size"];
			drNewRow["So_Luong"] = drDmBarcode["So_Luong_Current"];
			drNewRow["Num_Bars"] = drDmBarcode["Num_Bars_Current"];

			drNewRow["So_Luong_Current"] = drDmBarcode["So_Luong_Current"];
			drNewRow["Num_Bars_Current"] = drDmBarcode["Num_Bars_Current"];

			drNewRow["So_Luong_Barcode"] = drDmBarcode["So_Luong"];
			drNewRow["Num_Bars_Barcode"] = drDmBarcode["Num_Bars"];

			drNewRow["Length"] = drDmBarcode["Length"];
			drNewRow["Ma_Ca"] = drDmBarcode["Ma_Ca"];
			drNewRow["Ngay_Nhap"] = drDmBarcode["Ngay_Nhap"];
			drNewRow["Ca"] = drDmBarcode["Ca"];
			drNewRow["Grade_ID"] = drDmBarcode["Grade_ID"];
			drNewRow["Grade_Name"] = drDmBarcode["Grade_Name"];
			drNewRow["Standard_ID"] = drDmBarcode["Standard_ID"];
			drNewRow["Standard_Name"] = drDmBarcode["Standard_Name"];
			drNewRow["Ma_CL"] = drDmBarcode["Ma_CL"];
			drNewRow["Ten_CL"] = drDmBarcode["Ten_CL"];
			drNewRow["Num_Lot"] = drDmBarcode["Num_Lot"];
			drNewRow["Is_OutPut"] = drDmBarcode["Is_OutPut"];
			
			dtEditCt.Rows.Add(drNewRow);
			dtEditCt.AcceptChanges();

			if (dtEditCt == null || dtEditCt.Rows.Count <= 0)
			{
				Common.MsgCancel("Không có dữ liệu chi tiết. Vui lòng quét mã vạch");
				return;
			}

			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();

			sqlCom.CommandText = "sp_Update_Ct";
			sqlCom.CommandType = CommandType.StoredProcedure;

			sqlCom.Parameters.Clear();
			sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)enuEdit.New);
			sqlCom.Parameters.AddWithValue("@Stt", strStt);
			sqlCom.Parameters.AddWithValue("@Ma_Ct", drEditPh["Ma_Ct"]);
			sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

			//Tạo Table cho TVP_PH
			SqlParameter paraPH = new SqlParameter();
			paraPH.SqlDbType = SqlDbType.Structured;
			paraPH.ParameterName = "@PH";

			//Tạo Table cho TVP_PH
			SqlParameter paraCt = new SqlParameter();
			paraCt.SqlDbType = SqlDbType.Structured;
			paraCt.ParameterName = "@Ct";

			sqlCom.CommandText = "sp_Update_CtX_Barcode";

			//TVP_PH
			paraPH.TypeName = "TVP_PH_SCALE";
			paraPH.Value = Voucher.GetTVPValue("R80PH_SCALE", "TVP_PH_SCALE", drEditPh.Table);
			sqlCom.Parameters.Add(paraPH);

			//TVP_CT
			paraCt.TypeName = "TVP_CtX_BARCODE";
			paraCt.Value = Voucher.GetTVPValue("R05CTX_BARCODE", "TVP_CtX_BARCODE", dtEditCt);
			sqlCom.Parameters.Add(paraCt);

			try
			{
				sqlCom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
				sqlCom.CommandType = CommandType.Text;
				sqlCom.Parameters.Clear();
				sqlCom.ExecuteNonQuery();

				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
			}
		}

		private double CheckOutPutAndInput(string strBarcode)
		{
			string strSQLExec = @"
				SELECT ISNULL(SUM(T2.So_Luong), 0) - ISNULL(SUM(T1.So_Luong), 0)
					FROM R05CTX_BARCODE T1 WITH(NOLOCK) LEFT JOIN (SELECT Barcode, SUM(So_Luong) AS So_Luong FROM R05CTN_BARCODE WITH(NOLOCK) WHERE Barcode = '" + strBarcode + "' GROUP BY Barcode) T2 ON T1.Barcode = T2.Barcode" + @"
					WHERE T1.Barcode = '" + strBarcode + "'";

			return Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));
		}
        
       
		void dgvKCS_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			dgvKCS_CellContentClick(sender, e);
		}

              
        //
		void dgvKCS_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.RowIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsKCS.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsKCS.Current).Row;
			string strColName = dgvKCS.Columns[e.ColumnIndex].Name;

            
			if (Common.CheckPermission("ACCESS_KCS_STATUS", enuPermission_Type.Allow_Access))
			{
				if (dgvKCS.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode && strColName == "REMARK_KCS")
				{
					//Kiểm tra dữ liệu bị khóa chưa.
					if (!Voucher.CheckDataLocked_Barcode((DateTime)drCurrent["Ngay_Nhap"]))
					{
						Common.MsgCancel("Dữ liệu đã bị khóa.Vui lòng liên hệ với người dùng có quyền mở khóa");
						
						if (drCurrent.HasVersion(DataRowVersion.Original))
							drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
						else
							drCurrent.RejectChanges();

						return;
					}

					//Check Barcode đã được xuất chưa
					if (this.CheckOutPutAndInput(drCurrent["Barcode"].ToString()) != 0)
					{
						Common.MsgCancel("Bó thép đã được xuất rồi. Không được phép sửa");
						
						if (drCurrent.HasVersion(DataRowVersion.Original))
							drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
						else
							drCurrent.RejectChanges();

						return;
					}
                    //Check BarCode da ke thua nhap thanh pham
                    if (!(bool)Voucher_Scale.CheckInheritBarCode_PNTLB(drCurrent["Barcode"].ToString()))
                    {
                        Common.MsgCancel("Bó thép đã được kế thừa nhập kho thành phẩm. Không được phép sửa");

                        if (drCurrent.HasVersion(DataRowVersion.Original))
                            drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
                        else
                            drCurrent.RejectChanges();

                        return;
                    }
					string strSQL = "UPDATE R81DMBARCODE SET " + strColName + " = @Value, LastModify_Log_KCS = @LastModify_Log_KCS WHERE Barcode = @Barcode";
					Hashtable htPara = new Hashtable();
					htPara["BARCODE"] = drCurrent["Barcode"];
					htPara["VALUE"] = e.FormattedValue;
					htPara["LASTMODIFY_LOG_KCS"] = Common.GetCurrent_Log();

					if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
					{
						drCurrent[strColName] = e.FormattedValue;
						drCurrent.AcceptChanges();
					}

					return;
				}

				if (dgvKCS.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode && strColName == "DATE_PROCESS")
				{
					//Kiểm tra dữ liệu bị khóa chưa.
					if (!Voucher.CheckDataLocked_Barcode((DateTime)drCurrent["Ngay_Nhap"]))
					{
						Common.MsgCancel("Dữ liệu đã bị khóa.Vui lòng liên hệ với người dùng có quyền mở khóa");
						if (drCurrent.HasVersion(DataRowVersion.Original))
							drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
						else
							drCurrent.RejectChanges();

						return;
					}
					//Neu bo thep duoc tach tu bo chan thi khong lam gi het
					if (drCurrent["Barcode_Org"].ToString() != string.Empty)
					{
                        Common.MsgCancel("Bó thép này được chuyển từ bó chẵn.Không xử lý được.");

						if (drCurrent.HasVersion(DataRowVersion.Original))
							drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
						else
							drCurrent.RejectChanges();

						return;
					}
					
					//Check Barcode đã được xuất chưa
					if (this.CheckOutPutAndInput(drCurrent["Barcode"].ToString()) != 0)
					{
						Common.MsgCancel("Bó thép đã được xuất rồi. Không được phép sửa");
						
						if (drCurrent.HasVersion(DataRowVersion.Original))
							drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
						else
							drCurrent.RejectChanges();

						return;
					}
                    //Check BarCode da ke thua nhap thanh pham
                    if (!(bool)Voucher_Scale.CheckInheritBarCode_PNTLB(drCurrent["Barcode"].ToString()))
                    {
                        Common.MsgCancel("Bó thép đã được kế thừa nhập kho thành phẩm. Không được phép sửa");

                        if (drCurrent.HasVersion(DataRowVersion.Original))
                            drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
                        else
                            drCurrent.RejectChanges();

                        return;
                    }
					DateTime dteDate_Process = Element.sysNgay_Min;
					string strFormattedValue = e.FormattedValue.ToString().Replace(" ","").Trim();
					string strOutValue = string.Empty;
					if (strFormattedValue != string.Empty && strFormattedValue != "//")
					{
						Int64 iTest;
						if ((strFormattedValue.Length == 4 || strFormattedValue.Length == 6 || strFormattedValue.Length == 8) && Int64.TryParse(strFormattedValue, out iTest))
						{
							string strDay = strFormattedValue.Substring(0, 2);
							string strMonth = strFormattedValue.Substring(2, 2);
							string strYear = DateTime.Today.Year.ToString();
							if (strFormattedValue.Length == 6)
								strYear = strFormattedValue.Substring(4, 2);
							else if (strFormattedValue.Length == 8)
								strYear = strFormattedValue.Substring(4, 4);

							DateTime outValue;
							
							if (DateTime.TryParse(strDay + "/" + strMonth + "/" + strYear, out outValue))
							{
								strOutValue = strDay + "/" + strMonth + "/" + strYear;
								e.Cancel = false;
							}
						}

						DateTime dteCheckType;
						if (DateTime.TryParse(strOutValue, out dteCheckType) != true)
						{
							e.Cancel = true;
							Common.MsgOk("Ngày xử lý không hợp lệ!");
						}
						else
							dteDate_Process = Convert.ToDateTime(strOutValue);
					}

					string strSQL = "UPDATE R81DMBARCODE SET " + strColName + " = @Value, LastModify_Log_Status = @LastModify_Log_Status WHERE Barcode = @Barcode";
					Hashtable htPara = new Hashtable();
					htPara["BARCODE"] = drCurrent["Barcode"];
					htPara["VALUE"] = dteDate_Process;
					htPara["LASTMODIFY_LOG_STATUS"] = Common.GetCurrent_Log();

					if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
					{
						drCurrent[strColName] = dteDate_Process;
						drCurrent.AcceptChanges();
					}

					return;

				}

				if (dgvKCS.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode && strColName == "REMARK")
				{
					//Kiểm tra dữ liệu bị khóa chưa.
					if (!Voucher.CheckDataLocked_Barcode((DateTime)drCurrent["Ngay_Nhap"]))
					{
						Common.MsgCancel("Dữ liệu đã bị khóa.Vui lòng liên hệ với người dùng có quyền mở khóa");

                        if (drCurrent.HasVersion(DataRowVersion.Original))
                            drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
                        else
                            drCurrent.RejectChanges();
					}

					//Check Barcode đã được xuất chưa
					if (this.CheckOutPutAndInput(drCurrent["Barcode"].ToString()) != 0)
					{
						Common.MsgCancel("Bó thép đã được xuất rồi. Không được phép sửa");
						
						if (drCurrent.HasVersion(DataRowVersion.Original))
							drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
						else
							drCurrent.RejectChanges();

						return;
					}

					//Neu bo thep duoc tach tu bo chan thi khong lam gi het
					if (drCurrent["Barcode_Org"].ToString() != string.Empty)
					{
                        Common.MsgCancel("Bó thép này được chuyển từ bó chẵn.Không xử lý được.");
						
						if (drCurrent.HasVersion(DataRowVersion.Original))
							drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
						else
							drCurrent.RejectChanges();

						return;
					}
                    //Check BarCode da ke thua nhap thanh pham
                    if (!(bool)Voucher_Scale.CheckInheritBarCode_PNTLB(drCurrent["Barcode"].ToString()))
                    {
                        Common.MsgCancel("Bó thép đã được kế thừa nhập kho thành phẩm. Không được phép sửa");

                        if (drCurrent.HasVersion(DataRowVersion.Original))
                            drCurrent[strColName] = drCurrent[strColName, DataRowVersion.Original];
                        else
                            drCurrent.RejectChanges();

                        return;
                    }
                   //Bang them
                    //string strValue = string.Empty;

                    //if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                    //    strValue = this.ActiveControl.Text;
                    //else
                    //    strValue = drCurrent[strColName].ToString();
                    //bool bRequire = true;

                    //System.Collections.Hashtable htField = new System.Collections.Hashtable();
                    //htField.Add("strType", "DIEM_KPH_BARCODE");
                    //DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'DIEM_KPH_BARCODE'", "", htField);

                    //if (bRequire && drLookup == null)
                    //    return;

                    //if (drLookup == null)
                    //{
                    //    return;
                    //}
                    //else
                    //{
                    //    drCurrent[strColName] = drLookup["Type_ID"].ToString();
                    //}
                   
                   //
					if (e.FormattedValue.ToString() != string.Empty)
					{
						bool bIs_Wait_Process = true;
						string strSQL = "UPDATE R81DMBARCODE SET " + strColName + " = @Value, Is_Wait_Process = @Is_Wait_Process, Is_OutPut = @Is_OutPut, Is_Thu_Pham = @Is_Thu_Pham, Ma_Cl = @Ma_Cl, LastModify_Log_Status =  @LastModify_Log_Status WHERE Barcode = @Barcode";
						Hashtable htPara = new Hashtable();
						htPara["BARCODE"] = drCurrent["Barcode"];
                        htPara["VALUE"] = e.FormattedValue;// drCurrent["Remark"];
						htPara["IS_WAIT_PROCESS"] = bIs_Wait_Process;
						htPara["IS_OUTPUT"] = !bIs_Wait_Process;
						htPara["IS_THU_PHAM"] = !bIs_Wait_Process;
						htPara["MA_CL"] = "2";
						htPara["LASTMODIFY_LOG_STATUS"] = Common.GetCurrent_Log();

						if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
						{
                            drCurrent[strColName] = e.FormattedValue;
							drCurrent["Is_Wait_Process"] = bIs_Wait_Process;
							drCurrent["Is_OutPut"] = !bIs_Wait_Process;
							drCurrent["Is_Kho_Le"] = !bIs_Wait_Process;
							drCurrent["Is_Kho_Chan"] = !bIs_Wait_Process;
							drCurrent["Is_Thu_Pham"] = !bIs_Wait_Process;
							drCurrent["Is_OutPuted"] = "Không cho phép xuất";
							drCurrent["Ten_CL"] = "KPH";

							drCurrent.AcceptChanges();
						}
					}
					else
					{
						string strSQL = "UPDATE R81DMBARCODE SET " + strColName + " = @Value, LastModify_Log_Status =  @LastModify_Log_Status WHERE Barcode = @Barcode";
						Hashtable htPara = new Hashtable();
						htPara["BARCODE"] = drCurrent["Barcode"];
						htPara["VALUE"] = e.FormattedValue;
						htPara["LASTMODIFY_LOG_STATUS"] = Common.GetCurrent_Log();

						if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
						{
							drCurrent[strColName] = e.FormattedValue;
							drCurrent.AcceptChanges();
						}
					}
				}
			}
			else
				dgvKCS.CurrentCell.DataGridView.CancelEdit();
		}

		void dgvKCS_KeyDown(object sender, KeyEventArgs e)
		{
			string strSQLExec = string.Empty;
			string strValue = string.Empty;
			string strBarcode = string.Empty;
			bool bIs_Wait_Process = true;

			if (e.KeyCode == Keys.D && e.Control) //Lấy dữ liệu từ phía trên, gán xuống dưới
			{
				if (!Common.CheckPermission("ACCESS_KCS_STATUS", enuPermission_Type.Allow_Access))
				{
					for (int i = dgvKCS.CurrentCell.RowIndex - 1; i >= 0; i--)
					{
						if (dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value != DBNull.Value)
						{
							dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
						}
					}
					return;
				}

				if (dgvKCS.CurrentCell.OwningColumn.DataPropertyName == "REMARK_KCS")
				{
					if (dgvKCS.CurrentCell != null && !dgvKCS.CurrentCell.ReadOnly)
					{
						if (Common.MsgYes_No("Bạn có chắc chắn sao chép từ dòng trên xuống không?", "N"))
						{
							for (int i = dgvKCS.CurrentCell.RowIndex - 1; i >= 0; i--)
							{
								if (dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value != DBNull.Value)
								{
									dgvKCS.CurrentCell.Value = dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value;
									strValue = dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value.ToString();
									strBarcode = dgvKCS.CurrentRow.Cells["Barcode"].Value.ToString();
									DateTime dteNgay_Nhap = Convert.ToDateTime(dgvKCS.CurrentRow.Cells["Ngay_Nhap"].Value);

									//Kiểm tra dữ liệu bị khóa chưa.
									if (!Voucher.CheckDataLocked_Barcode(dteNgay_Nhap))
									{
										dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
										return;
									}

									if (this.CheckOutPutAndInput(strBarcode) != 0)
									{
										dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
										return;
									}

									strSQLExec = "UPDATE R81DMBARCODE SET Remark_KCS = @Value, LastModify_Log_KCS = @LastModify_Log_KCS WHERE Barcode = @Barcode";
									Hashtable htPara = new Hashtable();
									htPara["BARCODE"] = strBarcode;
									htPara["VALUE"] = strValue;
									htPara["LASTMODIFY_LOG_KCS"] = Common.GetCurrent_Log();
									return;
								}
							}
						}
						else
						{
							for (int i = dgvKCS.CurrentCell.RowIndex - 1; i >= 0; i--)
							{
								if (dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value != DBNull.Value)
								{
									dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
								}
							}
							return;
						}
					}
				}

				if (dgvKCS.CurrentCell.OwningColumn.DataPropertyName == "REMARK")
				{
					if (dgvKCS.CurrentCell != null && !dgvKCS.CurrentCell.ReadOnly)
					{
						if (Common.MsgYes_No("Bạn có chắc chắn sao chép từ dòng trên xuống không?", "N"))
						{
							for (int i = dgvKCS.CurrentCell.RowIndex - 1; i >= 0; i--)
							{
								if (dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value != DBNull.Value)
								{
									dgvKCS.CurrentCell.Value = dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value;
									strValue = dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value.ToString();
									strBarcode = dgvKCS.CurrentRow.Cells["Barcode"].Value.ToString();
									DateTime dteNgay_Nhap = Convert.ToDateTime(dgvKCS.CurrentRow.Cells["Ngay_Nhap"].Value);

									//Kiểm tra dữ liệu bị khóa chưa.
									if (!Voucher.CheckDataLocked_Barcode(dteNgay_Nhap))
									{
										dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
										return;
									}

									if (this.CheckOutPutAndInput(strBarcode) != 0)
									{
										dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
										return;
									}

									strSQLExec = "UPDATE R81DMBARCODE SET Remark = @Value, Is_Wait_Process = @Is_Wait_Process, Is_OutPut = @Is_OutPut, Is_Thu_Pham = @Is_Thu_Pham, Ma_Cl = @Ma_Cl, LastModify_Log_Status = @LastModify_Log_Status WHERE Barcode = @Barcode";
									Hashtable htPara = new Hashtable();
									htPara["BARCODE"] = strBarcode;
									htPara["VALUE"] = strValue;
									htPara["IS_WAIT_PROCESS"] = bIs_Wait_Process;
									htPara["IS_OUTPUT"] = !bIs_Wait_Process;
									htPara["IS_THU_PHAM"] = !bIs_Wait_Process;
									htPara["MA_CL"] = "2";
									htPara["LASTMODIFY_LOG_STATUS"] = Common.GetCurrent_Log();

									if (RosySystem.Data.SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
									{
										dgvKCS.CurrentRow.Cells["Is_Wait_Process"].Value = bIs_Wait_Process;
										dgvKCS.CurrentRow.Cells["Is_Kho_Le"].Value = !bIs_Wait_Process;
										dgvKCS.CurrentRow.Cells["Is_Thu_Pham"].Value = !bIs_Wait_Process;
										dgvKCS.CurrentRow.Cells["Is_OutPuted"].Value = "Không cho phép xuất";
										dgvKCS.CurrentRow.Cells["Ten_CL"].Value = "KPH";
									}
									return;
								}
							}
						}
						else
						{
							for (int i = dgvKCS.CurrentCell.RowIndex - 1; i >= 0; i--)
							{
								if (dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value != DBNull.Value)
								{
									dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
								}
							}
							return;
						}
					}
				}
				return;
			}

			else if (e.KeyCode == Keys.W && e.Control) //Lấy dữ liệu từ hiện tại, gán xuống dưới
			{
				if (!Common.CheckPermission("ACCESS_KCS_STATUS", enuPermission_Type.Allow_Access))
				{
					for (int i = dgvKCS.CurrentCell.RowIndex + 1; i < dgvKCS.RowCount; i++)
					{
						if (!dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].ReadOnly)
						{
							if (dgvKCS.CurrentCell.Value != DBNull.Value)
							{
								dtKCS.Rows[i].RejectChanges();
							}
						}
					}

					return;
				}

				if (dgvKCS.CurrentCell.OwningColumn.DataPropertyName == "REMARK_KCS")
				{
					if (dgvKCS.CurrentCell != null)
					{
						if (Common.MsgYes_No("Bạn có chắc chắn sao chép từ dòng trên xuống tất cả không?", "N"))
						{
							for (int i = dgvKCS.CurrentCell.RowIndex + 1; i < dgvKCS.RowCount; i++)
							{
								if (!dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].ReadOnly)
								{
									if (dgvKCS.CurrentCell.Value != DBNull.Value)
									{
										dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value = dgvKCS.CurrentCell.Value;
										strValue = dgvKCS.CurrentCell.Value.ToString();
										strBarcode = dgvKCS.Rows[i].Cells["Barcode"].Value.ToString();
										DateTime dteNgay_Nhap = Convert.ToDateTime(dgvKCS.Rows[i].Cells["Ngay_Nhap"].Value);

										//Kiểm tra dữ liệu bị khóa chưa.
										if (!Voucher.CheckDataLocked_Barcode(dteNgay_Nhap))
										{
											dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
											continue;
										}

										if (this.CheckOutPutAndInput(strBarcode) != 0)
										{
											dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
											continue;
										}

										strSQLExec = "UPDATE R81DMBARCODE SET Remark_KCS = @Value, LastModify_Log_KCS = @LastModify_Log_KCS WHERE Barcode = @Barcode";
										Hashtable htPara = new Hashtable();
										htPara["BARCODE"] = strBarcode;
										htPara["VALUE"] = strValue;
										htPara["LASTMODIFY_LOG_KCS"] = Common.GetCurrent_Log();
										RosySystem.Data.SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
									}
								}
							}
						}
						else
						{
							for (int i = dgvKCS.CurrentCell.RowIndex + 1; i < dgvKCS.RowCount; i++)
							{
								if (!dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].ReadOnly)
								{
									if (dgvKCS.CurrentCell.Value != DBNull.Value)
									{
										dtKCS.Rows[i].RejectChanges();	
									}
								}
							}
							return;
						}
					}
					else
						return;
				}
			

				if (dgvKCS.CurrentCell.OwningColumn.DataPropertyName == "REMARK")
				{
					if (dgvKCS.CurrentCell != null)
					{
						if (Common.MsgYes_No("Bạn có chắc chắn sao chép từ dòng trên xuống tất cả không?", "N"))
						{
							for (int i = dgvKCS.CurrentCell.RowIndex + 1; i < dgvKCS.RowCount; i++)
							{
								if (!dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].ReadOnly)
								{
									if (dgvKCS.CurrentCell.Value != DBNull.Value)
									{
										dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].Value = dgvKCS.CurrentCell.Value;
										strValue = dgvKCS.CurrentCell.Value.ToString();
										strBarcode = dgvKCS.Rows[i].Cells["Barcode"].Value.ToString();
										DateTime dteNgay_Nhap = Convert.ToDateTime(dgvKCS.Rows[i].Cells["Ngay_Nhap"].Value);

										//Kiểm tra dữ liệu bị khóa chưa.
										if (!Voucher.CheckDataLocked_Barcode(dteNgay_Nhap))
										{
											dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
											continue;
										}

										if (this.CheckOutPutAndInput(strBarcode) != 0)
										{
											dtKCS.Rows[dgvKCS.CurrentRow.Index].RejectChanges();
											continue;
										}

										strSQLExec = "UPDATE R81DMBARCODE SET Remark = @Value, Is_Wait_Process = @Is_Wait_Process, Is_OutPut = @Is_OutPut, Is_Thu_Pham = @Is_Thu_Pham, Ma_Cl = @Ma_Cl, LastModify_Log_Status = @LastModify_Log_Status WHERE Barcode = @Barcode";
										Hashtable htPara = new Hashtable();
										htPara["BARCODE"] = strBarcode;
										htPara["VALUE"] = strValue;
										htPara["IS_WAIT_PROCESS"] = bIs_Wait_Process;
										htPara["IS_OUTPUT"] = !bIs_Wait_Process;
										htPara["IS_THU_PHAM"] = !bIs_Wait_Process;
										htPara["MA_CL"] = "2";
										htPara["LASTMODIFY_LOG_STATUS"] = Common.GetCurrent_Log();

										if (RosySystem.Data.SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
										{
											dgvKCS.Rows[i].Cells["Is_Wait_Process"].Value = bIs_Wait_Process;
											dgvKCS.Rows[i].Cells["Is_Kho_Le"].Value = !bIs_Wait_Process;
											dgvKCS.Rows[i].Cells["Is_Thu_Pham"].Value = !bIs_Wait_Process;
											dgvKCS.Rows[i].Cells["Is_OutPuted"].Value = "Không cho phép xuất";
											dgvKCS.Rows[i].Cells["Ten_CL"].Value = "KPH";
										}
									}
								}
							}
						}
						else
						{
							for (int i = dgvKCS.CurrentCell.RowIndex + 1; i < dgvKCS.RowCount; i++)
							{
								if (!dgvKCS.Rows[i].Cells[dgvKCS.CurrentCell.ColumnIndex].ReadOnly)
								{
									if (dgvKCS.CurrentCell.Value != DBNull.Value)
									{
										dtKCS.Rows[i].RejectChanges();	
									}
								}
							}
							return;
						}
					}
					else
						return;
				}
				return;
			}
		}

		void rdbFilter_Edit_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbFilter_Edit1.Checked)
				strFilter_Update = "N";
			else if (rdbFilter_Edit2.Checked)
				strFilter_Update = "E";
			else
				strFilter_Update = "A";
		}
		private void RdbAll_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbTMN.Checked)
				strLoai = "TMN";
			else if (rdbGC.Checked)
				strLoai = "GC";
		}

		void dgvKCS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			DataTable dtView = dtKCS.DefaultView.ToTable();

			if (dtView.Rows.Count > 0)
			{
				numTKhoi_Luong.Value = Common.SumDCValue(dtView, "So_Luong", "");
				numTKL_Kho_Chan.Value = Common.SumDCValue(dtView, "So_Luong", "Is_Kho_Chan = true");
				numTKL_Kho_Le.Value = Common.SumDCValue(dtView, "So_Luong", "Is_Kho_Le = true");
				numTKL_CXL.Value = Common.SumDCValue(dtView, "So_Luong", "Is_Wait_Process = true");
				numTKL_Thu_Pham.Value = Common.SumDCValue(dtView, "So_Luong", "Is_Thu_Pham = true");

				numTBo.Value = Convert.ToDouble(dtView.Compute("Count(Barcode)", ""));
				numTBo_Kho_Chan.Value = Convert.ToDouble(dtView.Compute("Count(Barcode)", "Is_Kho_Chan = true"));
				numTBo_Kho_Le.Value = Convert.ToDouble(dtView.Compute("Count(Barcode)", "Is_Kho_Le = true"));
				numTBo_CXL.Value = Convert.ToDouble(dtView.Compute("Count(Barcode)", "Is_Wait_Process = true"));
				numTBo_Thu_Pham.Value = Convert.ToDouble(dtView.Compute("Count(Barcode)", "Is_Thu_Pham = true"));
			}
			else
			{
				numTKhoi_Luong.Value = numTKL_Kho_Chan.Value = numTKL_Kho_Le.Value = numTKL_CXL.Value = numTKL_Thu_Pham.Value = 0;
				numTBo.Value = numTBo_Kho_Chan.Value = numTBo_Kho_Le.Value = numTBo_CXL.Value = numTBo_Thu_Pham.Value = 0;
			}

		}

		void btPrint_Click(object sender, EventArgs e)
		{
			Voucher.PrintKCS(true, true);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
		}
        
        void btUpdate_Click(object sender, EventArgs e)
        {
            DateTime dteNgay_Ct = Convert.ToDateTime(dteNgay_Ct2.Text);
			
			string strMa_Nvu = "NKTP";
			if (rdbGC.Checked)
				strMa_Nvu = "NKGC";
			if (Common.CheckDataLocked(Convert.ToDateTime(dteNgay_Ct)))
            {
                Hashtable htPara = new Hashtable();

                htPara.Add("NGAY_CT1", dteNgay_Ct);
                htPara.Add("NGAY_CT2", dteNgay_Ct);
                htPara.Add("MA_CT", "TP");
                htPara.Add("MA_NVU", strMa_Nvu);
                htPara.Add("EXCEPT_INHERITED", true);
                htPara.Add("IS_CXL", true);
                htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
                htPara.Add("IS_HACH_TOAN", true);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                SQLExec.ExecuteReturnDs("sp_Inherit_Nhap_Barcode", htPara, CommandType.StoredProcedure);
            }
        }

    

	}
}
