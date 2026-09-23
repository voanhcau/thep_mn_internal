using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem;

namespace RosyModule.ScaleBarcode
{
	public partial class frmScale_60T : RosySystem.Customize.frmView
	{
		string strMa_Ct;
		BindingSource bdsDmDt = new BindingSource();
		DataTable dtDmDt;
		
		BindingSource bdsDmVtSp = new BindingSource();
		DataTable dtDmVtSp;
		DataRow drCurrent;

		public enuEdit enuNew_Edit = enuEdit.New;
		string strScale_Name = "CANA";

		double NetWeightMinimum;
		double OldWeight;
		bool bStable = false;

		bool bLedStarted = false;
		bool bEnable = true;
		bool isAccept = false;
		int iStable_Time = 0;

		string strSo_Xe_Old = string.Empty;
		string strMa_Dt_Old = string.Empty;
		double dbSo_Luong_Ra_Old = 0;
		bool bTare = false;

		public frmScale_60T()
		{
			InitializeComponent();

			this.InitForm();

			this.txtTime_Clock.Tick += new EventHandler(txtTime_Clock_Tick);
			this.dgvDmVt.DoubleClick += new EventHandler(dgvDmVt_DoubleClick);
			this.dgvDmDt.DoubleClick += new EventHandler(dgvDmDt_DoubleClick);
			this.btScale_In.Click += new EventHandler(btScale_In_Click);
			this.btScale_Out.Click += new EventHandler(btScale_Out_Click);
			this.btConvert_Scale.Click += new EventHandler(btConvert_Scale_Click);
			this.btScale.Click += new EventHandler(btScale_Click);
			this.numSo_Luong_Vao.TextChanged += new EventHandler(numSo_Luong_Vao_TextChanged);
			this.numSo_Luong_Ra.TextChanged += new EventHandler(numSo_Luong_Ra_TextChanged);
			this.FormClosing += new FormClosingEventHandler(frmScale_FormClosing);

			this.btSave_Print.Click += new EventHandler(btSave_Print_Click);
		}

		void btSave_Print_Click(object sender, EventArgs e)
		{
			this.Save();
		}

		private void Save()
		{
			if (!this.FormCheckValid())
				return;

			switch (this.enuNew_Edit)
			{
				case enuEdit.New:

					if (!this.bEnable)
						return;

					if (numSo_Luong_Vao.Value <= 0)
					{
						Common.MsgCancel("Khối lượng cân vào không phù hợp");
						return;
					}

					Hashtable htInsert = new Hashtable();
					string strStt = Convert.ToString(SQLExec.ExecuteReturnValue("sp_Update_PH_Scale", htInsert, CommandType.StoredProcedure));
					if (strStt != string.Empty)
					{
						this.bEnable = false;
						this.btScale.Enabled = false;
						this.btSave_Print.Enabled = false;

						if (this.chkPrint_In.Checked)
						{
							//Print Voucher
						}
						this.ChangeMode(enuEdit.New);
					}
					break;
				case enuEdit.Edit:

					if (!this.bEnable)
						return;

					if (this.numSo_Luong_Ra.Value <= 0)
					{
						Common.MsgCancel("Khối lượng cân ra không phù hợp");
						return;
					}

					Hashtable htUpdate = new Hashtable();
					if (SQLExec.Execute("sp_Update_PH_Scale", htUpdate, CommandType.StoredProcedure))
					{
						this.strSo_Xe_Old = txtSo_Xe.Text.Trim();
						this.strMa_Dt_Old = cboMa_Dt.Text;
						this.dbSo_Luong_Ra_Old = numSo_Luong_Ra.Value;
						if (this.chkPrint_Out.Checked)
						{
							//Print Voucher
						}

						if (Common.MsgYes_No("Xe có tiếp tục lấy hàng không?", "N"))
						{
							this.bEnable = true;
							this.ChangeMode(enuEdit.New);
							this.txtSo_Xe.Text = strSo_Xe_Old;
							this.cboMa_Dt.SelectedValue = strMa_Dt_Old;
							this.numSo_Luong_Vao.Value = dbSo_Luong_Ra_Old;
							this.cboMa_Vt.Focus();
							this.txtSo_Xe.Enabled = false;
							this.btScale.Enabled = true;
							this.btSave_Print.Enabled = true;
						}
						else
						{
							this.ChangeMode(enuEdit.Edit);
							this.bTare = false;
							this.btScale.Enabled = false;
							this.btSave_Print.Enabled = false;
						}
					}
					break;
			}

			txtSo_Xe.Focus();
		}

		private bool FormCheckValid()
		{
			if (txtSo_Xe.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("So_Xe") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			return true;
		}

		void frmScale_FormClosing(object sender, FormClosingEventArgs e)
		{
			HardwareInterface.DataReceive -= new DataEventHandler(HardwareInterface_DataReceive);
		}

		void numSo_Luong_Ra_TextChanged(object sender, EventArgs e)
		{
			if (numSo_Luong_Vao.Value > 0 & this.numSo_Luong_Ra.Value > 0)
			{
				this.numSo_Luong.Value = Math.Abs(numSo_Luong_Vao.Value - numSo_Luong_Ra.Value);
			}
			else
			{
				this.numSo_Luong.Value = 0;
			}
		}

		void numSo_Luong_Vao_TextChanged(object sender, EventArgs e)
		{
			if (numSo_Luong_Vao.Value > 0 & numSo_Luong_Ra.Value > 0)
			{
				numSo_Luong.Value = Math.Abs(numSo_Luong_Vao.Value - numSo_Luong_Ra.Value);
			}
			else
			{
				numSo_Luong.Value = 0;
			}
		}

		void btScale_Click(object sender, EventArgs e)
		{
			if (this.enuNew_Edit == enuEdit.New)
			{
				numSo_Luong_Vao.Value = Convert.ToInt32(numWeight_Scale.Value);
				if (numSo_Luong_Vao.Value > 0)
				{
					btSave_Print.Enabled = true;
				}
			}
			if (this.enuNew_Edit == enuEdit.Edit)
			{
				numSo_Luong_Ra.Value = Convert.ToInt32(numWeight_Scale.Value);
				if (this.numSo_Luong_Ra.Value > 0)
				{
					btSave_Print.Enabled = true;
				}
			}

			btSave_Print.Focus();
		}

		private void InitForm()
		{
			ChangeMode(enuEdit.New);

			DataRow drEquipment = DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());
			{
				Variables.strEquip_ID = (string)drEquipment["Equip_ID"];
				Variables.StatusInputType = (StatusInputType)Enum.Parse(typeof(StatusInputType), (string)drEquipment["Status_Input_Type"]);
				Variables.dbZero_Coefficient = Convert.ToDouble(drEquipment["Zero_Coefficient"]);
				Variables.dbSpan_Coefficient = Convert.ToDouble(drEquipment["Span_Coefficient"]);
				Variables.dbNet_Weight_Min = Convert.ToDouble(drEquipment["Net_Weight_Min"]);
				Variables.dbNet_Weight_Max = Convert.ToDouble(drEquipment["Net_Weight_Max"]);
				Variables.iStable_Count = Convert.ToInt32(drEquipment["Stable_Count"]);
				Variables.iNum_Ticket_Print = Convert.ToInt32(drEquipment["Num_Ticket_Print"]);
				Variables.strPrint_Report = (string)drEquipment["Print_Report"] ;
				Variables.strPrint_Barcode = (string)drEquipment["Print_Barcode"];
				Variables.strPrint_Eticket = (string)drEquipment["Print_Eticket"];
			}
			
			HardwareInterface.Start();
			HardwareInterface.DataReceive += new DataEventHandler(HardwareInterface_DataReceive);
		}

		void HardwareInterface_DataReceive(double dbValue, string strType)
		{
			UpdateScaleInfo(dbValue, "CANA");
		}

		private void UpdateScaleInfo(double weight, string strScale_Name)
		{
			if (strScale_Name == this.strScale_Name)
			{
				numWeight_Scale.Value = weight;
			}
			if (Variables.bManual)
			{
				this.bEnable = true;
			}
			else
			{
				if (numWeight_Scale.Value < this.NetWeightMinimum)
				{
					this.bEnable = true;
				}
			}
			if (weight > 100.0)
			{
				if (Math.Abs(weight - this.OldWeight) > (double)Variables.iStable_Range)
				{
				    this.bStable = false;
				}
				else
				{
				    this.bStable = true;
				}
				this.OldWeight = numWeight_Scale.Value;
			}
			else
			{
				this.bStable = false;
			}
		}

		new public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;
			this.Build();
			this.FillData();
			this.Init_Ct();
			this.Show();
		}

		private void Init_Ct()
		{
			cboMa_Dt.SelectedValue = cboMa_Vt.SelectedValue = string.Empty;

			txtMa_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ma_Dt", Element.sysUser_Id);
			txtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", Element.sysUser_Id);
		}

		private void Build()
		{
			dgvDmDt.strZone = "DMDT_SCALE";
			dgvDmDt.BuildGridView();

			dgvDmVt.strZone = "DMSP_SCALE";
			dgvDmVt.BuildGridView();

			dgvCtNX_Barcode.strZone = "CTNX_BARCODE";
			dgvCtNX_Barcode.Dock = DockStyle.Fill;
			dgvCtNX_Barcode.BuildGridView();
		}

		private void FillData()
		{
			//Danh mục đối tượng
			dtDmDt = DataTool.SQLGetDataTable("R81DMDT", "*", "Ma_Nh_Dt NOT IN('NV','NB')", "MA_DT");
			bdsDmDt.DataSource = dtDmDt;
			dgvDmDt.DataSource = bdsDmDt;

			//Danh mục vật tư
			dtDmVtSp = DataTool.SQLGetDataTable("R81DMVT", "*", "", "MA_VT");
			bdsDmVtSp.DataSource = dtDmVtSp;
			dgvDmVt.DataSource = bdsDmVtSp;

			DataRow drDmDt_Empty = dtDmDt.NewRow();
			drDmDt_Empty["Ma_Dt"] = drDmDt_Empty["Ten_Dt"] = string.Empty;
			dtDmDt.Rows.Add(drDmDt_Empty);

			DataRow drDmVSp_Empty = dtDmVtSp.NewRow();
			drDmVSp_Empty["Ma_Vt"] = drDmVSp_Empty["Ten_Vt"] = string.Empty;
			dtDmVtSp.Rows.Add(drDmVSp_Empty);

			//ComboBox Đối tượng
			cboMa_Dt.DataSource = dtDmDt;
			cboMa_Dt.DisplayMember = "MA_DT";
			cboMa_Dt.ValueMember = "MA_DT";

			cboTen_Dt.DataSource = dtDmDt;
			cboTen_Dt.DisplayMember = "TEN_DT";
			cboTen_Dt.ValueMember = "MA_DT";

			//Danh mục sản phẩm
			cboMa_Vt.DataSource = dtDmVtSp;
			cboMa_Vt.DisplayMember = "MA_VT";
			cboMa_Vt.ValueMember = "MA_VT";

			cboTen_Vt.DataSource = dtDmVtSp;
			cboTen_Vt.DisplayMember = "TEN_VT";
			cboTen_Vt.ValueMember = "MA_VT";

		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F6:
					this.ChangeMode(enuEdit.Edit);
					return;

				case Keys.F5:
					this.ChangeMode(enuEdit.New);
					return;

				case Keys.F9:
					btConvert_Scale_Click(null, null);
					return;

				case Keys.T:
					if (e.Modifiers == Keys.Control)
					{
						frmTestCom frm = new frmTestCom();
						frm.Load();
					}
					return;

			}

			base.OnKeyDown(e);
		}

		private void ChangeMode(enuEdit enuNew_Edit)
		{
			this.enuNew_Edit = enuNew_Edit;
			if (enuNew_Edit == enuEdit.New)
			{
				this.btSave_Print.Enabled = false;
				this.grbSearch.Visible = false;
				this.btScale_In.ForeColor = Color.Red;
				this.btScale_Out.ForeColor = Color.FromArgb(16, 37, 127);
				this.GetNewSo_Ct();
				this.dgvDmDt.Visible = this.dgvDmVt.Visible = true;
				this.dgvCtNX_Barcode.Visible = false;
			}
			else if (enuNew_Edit == enuEdit.Edit)
			{
				this.btSave_Print.Enabled = false;
				this.grbSearch.Visible = true;
				this.txtBarcode_Search.Focus();
				this.btScale_In.ForeColor = Color.FromArgb(16, 37, 127);
				this.btScale_Out.ForeColor = Color.Red;

				this.dgvDmDt.Visible = this.dgvDmVt.Visible = false;
				this.dgvCtNX_Barcode.Visible = true;
			}
		}

		private void GetNewSo_Ct()
		{
			txtSo_Ct.Text = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ct),0) + 1 FROM R80PH_SCALE WHERE YEAR(Ngay_Ct) = YEAR(GETDATE())"));
			txtSo_Xe.Text = this.txtDien_Giai.Text = string.Empty;

			cboMa_Vt.SelectedValue = cboMa_Dt.SelectedValue = string.Empty;
			numSo_Luong_Vao.Value = numSo_Luong_Ra.Value = numSo_Luong.Value = 0;
			txtSo_Xe.Focus();
		}

		void btScale_Out_Click(object sender, EventArgs e)
		{
			this.ChangeMode(enuEdit.Edit);
		}

		void btScale_In_Click(object sender, EventArgs e)
		{
			this.ChangeMode(enuEdit.New);
		}

		void btConvert_Scale_Click(object sender, EventArgs e)
		{
			if (this.strScale_Name == "CANA")
			{
				this.strScale_Name = "CANB";
				this.lblScale_Name.Text = "CÂN B";
				this.lblScale_Name.ForeColor = (this.numWeight_Scale.LedOnColor = Color.Yellow);
			}
			else
			{
				this.strScale_Name = "CANA";
				this.lblScale_Name.Text = "CÂN A";
				this.lblScale_Name.ForeColor = (this.numWeight_Scale.LedOnColor = Color.Lime);
			}
		}

		void dgvDmDt_DoubleClick(object sender, EventArgs e)
		{
			if (bdsDmDt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;
			cboMa_Dt.SelectedValue = drCurrent["Ma_Dt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Dt"];
		}

		void dgvDmVt_DoubleClick(object sender, EventArgs e)
		{
			if (bdsDmVtSp.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmVtSp.Current).Row;
			cboMa_Vt.SelectedValue = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];
		}

		void txtTime_Clock_Tick(object sender, EventArgs e)
		{
			this.txtTime.Text = string.Format("{0:HH:mm:ss  -  dd/MM/yyyy}", DateTime.Now);

			if (this.bStable)
			{
				iStable_Time++;
			}
			else
			{
				iStable_Time = 0;
			}
			this.lblStatus.Text = string.Concat(new string[] { this.bEnable.ToString(), "-", iStable_Time.ToString(), "-", this.isAccept.ToString() });

			if (iStable_Time >= Variables.iStable_Count)
				this.isAccept = true;
			else
				this.isAccept = false;

			btScale.Enabled = (bEnable && isAccept);
		}
		
	}
}
