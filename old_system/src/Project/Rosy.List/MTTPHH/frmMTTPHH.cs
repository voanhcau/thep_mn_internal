using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Element;
using RosySystem.Customize;
using System.Threading;
using System.Reflection;


namespace RosyList
{
	public partial class frmMTTPHH : RosyList.frmView
	{
		#region Khai bao bien
		DataTable dtMTTPHH;
		DataRow drCurrent;
		BindingSource bdsMTTPHH = new BindingSource();
		rsDataGridView dgvMTTPHH = new rsDataGridView();

		#endregion

		#region Contructor

		public frmMTTPHH()
		{
			InitializeComponent();

			this.dgvMTTPHH.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvMTTPHH_CellMouseDoubleClick);
			this.dgvMTTPHH.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvMTTPHH_DataBindingComplete);
			this.btImport.Click +=new EventHandler(btImport_Click);
			this.btFilter.Click += new EventHandler(btFilter_Click);
            this.btInherit.Click += new EventHandler(btInherit_Click);
		}

        

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();
			this.Show();
		}


		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvMTTPHH.Dock = DockStyle.Fill;
			dgvMTTPHH.strZone = "MTTPHH";
			dgvMTTPHH.BuildGridView(this.isLookup);

            if (dgvMTTPHH.Columns.Contains("Chon"))
                dgvMTTPHH.Columns["Chon"].Visible = false;

			this.rsPanel1.Controls.Add(dgvMTTPHH);

			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			//Mac thep
			DataTable dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEP", "", "", "");
			cboGrade_Name.Items.Clear();
			cboGrade_Name.Items.Add(string.Empty);
			foreach (DataRow drGrade in dtDmMacThep.Rows)
			{
				cboGrade_Name.Items.Add(drGrade["Grade_Name"]);
			}

			//Thanh phan hoa hoc
			this.cboTPHH.Items.Clear();
			object[] objTPHH = new object[] { string.Empty, "C", "Mn", "Si", "P", "S", "Cr", "Ni", "Mo", "Cu", "Al", "V", "W", "Sn", "As", "Cueq", "Ceq" };
			this.cboTPHH.Items.AddRange(objTPHH);

			//Tinh chat
			this.cboTinh_Chat.Items.Clear();
			object[] objTinh_Chat = new object[] { string.Empty, "Đạt", "Không đạt", "Quá lớn", "Quá bé", "Không nhập" };
			this.cboTinh_Chat.Items.AddRange(objTinh_Chat);

			//Patter_Pos
			DataTable dtPattern_Pos = SQLExec.ExecuteReturnDt("SELECT Pattern_Pos FROM R81MTTPHH GROUP BY Pattern_Pos");
			this.cboPattern_Pos.Items.Add(string.Empty);
			foreach (DataRow drPattern_Pos in dtPattern_Pos.Rows)
			{
				cboPattern_Pos.Items.Add(drPattern_Pos["Pattern_Pos"]);
			}

			this.cboGrade_Name.SelectedItem = cboTPHH.SelectedItem = cboTinh_Chat.SelectedItem = cboPattern_Pos.SelectedItem = string.Empty;

			//Remover DataGridView Filter
			string strColumnList = "FE,C,MN,SI,P,S,CR,NI,MO,CU,AL,V,W,SN,ASS,CUEQ,CEQ,C_MN_6,CU_10_SN,CA_PPM,N,PB,PB_S,MN_S,TEN_DT_CBNV,NDo_DAm";
			foreach (string strColumn in strColumnList.Split(','))
			{
				if (dgvMTTPHH.Columns.Contains(strColumn))
					((dgvAutoFilterColumnHeaderCell)dgvMTTPHH.Columns[strColumn].HeaderCell).bFilteringEnabled = false;

			}

		}

		private void FillData()
		{
			string strKey = "(0 = 0)";

			strKey = strKey + " AND (Ngay_Sx >= '" + dteNgay_Ct1.Text + "' AND Ngay_Sx <= '" + dteNgay_Ct2.Text + "')";

			if (cboGrade_Name.SelectedItem.ToString() != string.Empty)
				strKey = strKey + " AND (T2.Grade_Name = '" + cboGrade_Name.SelectedItem.ToString() + "')";

			if (cboPattern_Pos.Text.Trim() != string.Empty)
				strKey = strKey + " AND (T1.Pattern_Pos LIKE '%" + cboPattern_Pos.Text.Trim() + "%')";

			if (txtNo_Melt.Text.Trim() != string.Empty)
				strKey = strKey + " AND (T1.No_Melt LIKE '%" + txtNo_Melt.Text.Trim() + "%')";

			if (this.cboTinh_Chat.SelectedItem.ToString() != string.Empty && this.cboTPHH.SelectedItem.ToString() != string.Empty)
			{
				string strTPHH = string.Empty; ;

				if (this.cboTPHH.SelectedItem.ToString() == "As")
					strTPHH = "Ass";
				else
					strTPHH = cboTPHH.SelectedItem.ToString();

				switch (this.cboTinh_Chat.SelectedIndex)
				{
					case 1:
						strKey += " AND (" + strTPHH + " BETWEEN ISNULL(" + strTPHH + "_Min, 0) AND ISNULL(" + strTPHH + "_Max, 100))";
						break;
					case 2:
						strKey += " AND (" + strTPHH + " > ISNULL(" + strTPHH + "_Max, 100) OR " + strTPHH + " < ISNULL(" + strTPHH + "_Min, 0))";
						break;
					case 3:
						strKey += " AND (" + strTPHH + " > ISNULL(" + strTPHH + "_Max, 100))";
						break;
					case 4:
						strKey += " AND (" + strTPHH + "< ISNULL(" + strTPHH + "_Min, 0))";
						break;
					case 5:
						strKey += " AND (" + strTPHH + " IS NULL)";
						break;
				}
			}

			string strSQLExec = @"
				SELECT  T1.Ident00, T1.Ngay_Sx, T1.Ca, T1.No_Melt, T1.TT_Seq, T1.Num_Bars_Embryos, T1.Billet_Size, T1.Pattern_Pos, ISNULL(T1.Grade_Name, '') AS Grade_Name,
						C, ISNULL(T3.C_Min, 0) AS C_Min, ISNULL(T3.C_Max, 0) AS C_Max,
						Mn, ISNULL(T3.Mn_Min, 0) AS Mn_Min, ISNULL(T3.Mn_Max, 0) AS Mn_Max,
						Si, ISNULL(T3.Si_Min, 0) AS Si_Min, ISNULL(T3.Si_Max, 0) AS Si_Max,
						P, ISNULL(T3.P_Min, 0) AS P_Min, ISNULL(T3.P_Max, 0) AS P_Max,
						S, ISNULL(T3.S_Min, 0) AS S_Min, ISNULL(T3.S_Max, 0) AS S_Max,
						Cr, ISNULL(T3.Cr_Min, 0) AS Cr_Min, ISNULL(T3.Cr_Max, 0) AS Cr_Max,
						Ni, ISNULL(T3.Ni_Min, 0) AS Ni_Min, ISNULL(T3.Ni_Max, 0) AS Ni_Max,
						Mo, ISNULL(T3.Mo_Min, 0) AS Mo_Min, ISNULL(T3.Mo_Max, 0) AS Mo_Max,
						Cu, ISNULL(T3.Cu_Min, 0) AS Cu_Min, ISNULL(T3.Cu_Max, 0) AS Cu_Max,
						Al, ISNULL(T3.Al_Min, 0) AS Al_Min, ISNULL(T3.Al_Max, 0) AS Al_Max,
						V, ISNULL(T3.V_Min, 0) AS V_Min, ISNULL(T3.V_Max, 0) AS V_Max,
						W, ISNULL(T3.W_Min, 0) AS W_Min, ISNULL(T3.W_Max, 0) AS W_Max,
						Sn, ISNULL(T3.Sn_Min, 0) AS Sn_Min, ISNULL(T3.Sn_Max, 0) AS Sn_Max,
						Ass, ISNULL(T3.Ass_Min, 0) AS Ass_Min, ISNULL(T3.Ass_Max, 0) AS Ass_Max,
						Cueq, ISNULL(T3.Cueq_Min, 0) AS Cueq_Min, ISNULL(T3.Cueq_Max, 0) AS Cueq_Max,
						Ceq, ISNULL(T3.Ceq_Min, 0) AS Ceq_Min, ISNULL(T3.Ceq_Max, 0) AS Ceq_Max,
						C_Mn_6, ISNULL(T3.C_Mn_6_Min, 0) AS C_Mn_6_Min, ISNULL(T3.C_Mn_6_Max, 0) AS C_Mn_6_Max,
					    Pb, 
                        T1.Ca_PPM, T1.N, T1.Cu_10_Sn, T1.Mn_S, T1.Ten_Dt_CbNv, T1.Description, T1.Create_Log, T1.LastModify_Log, T1.Ma_Data,
						NDo_DAm
				FROM R81MTTPHH T1 LEFT JOIN (SELECT Grade_Name, MAX(Grade_ID) AS Grade_ID FROM R81DMMACTHEP GROUP BY Grade_Name) T2 ON T1.Grade_Name = T2.Grade_Name
								LEFT JOIN R81DMTPHH T3 ON T3.Grade_ID = T2.Grade_ID WHERE " + strKey;

			dtMTTPHH = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);

			bdsMTTPHH.DataSource = dtMTTPHH;
			dgvMTTPHH.DataSource = bdsMTTPHH;
			bdsMTTPHH.Position = 0;
			
			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsMTTPHH;
			ExportControl = dgvMTTPHH;

		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
		}

		public override void Delete()
		{
			if (bdsMTTPHH.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsMTTPHH.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81MTTPHH", drCurrent))
			{
				bdsMTTPHH.RemoveAt(bdsMTTPHH.Position);
				dtMTTPHH.AcceptChanges();
			}
		}

		#endregion 

		#region Su kien

		void dgvMTTPHH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void dgvMTTPHH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			string strColumn_Name = "C,MN,SI,P,S,CR,NI,MO,CU,AL,V,ASS,CUEQ,CEQ,C_MN_6";
			foreach (DataGridViewRow dgvRow in dgvMTTPHH.Rows)
			{
				foreach (DataGridViewColumn dgvColumn in dgvMTTPHH.Columns)
				{
					if (Common.Inlist(dgvColumn.DataPropertyName, strColumn_Name))
					{
						if (Convert.ToDouble(dtMTTPHH.Rows[dgvRow.Index][dgvColumn.DataPropertyName]) == 0)
							dgvRow.Cells[dgvColumn.DataPropertyName].Style.BackColor = Color.SkyBlue;
						else
						{
							if (Convert.ToDouble(dtMTTPHH.Rows[dgvRow.Index][dgvColumn.DataPropertyName + "_Min"]) != 0)
							{
								if (Convert.ToDouble(dtMTTPHH.Rows[dgvRow.Index][dgvColumn.DataPropertyName]) < Convert.ToDouble(dtMTTPHH.Rows[dgvRow.Index][dgvColumn.DataPropertyName + "_Min"]))
									dgvRow.Cells[dgvColumn.DataPropertyName].Style.BackColor = Color.Yellow;

								if (Convert.ToDouble(dtMTTPHH.Rows[dgvRow.Index][dgvColumn.DataPropertyName + "_Max"]) != 0)
								{
									if (Convert.ToDouble(dtMTTPHH.Rows[dgvRow.Index][dgvColumn.DataPropertyName]) > Convert.ToDouble(dtMTTPHH.Rows[dgvRow.Index][dgvColumn.DataPropertyName + "_Max"]))
										dgvRow.Cells[dgvColumn.DataPropertyName].Style.BackColor = Color.Red;
								}
							}
						}
					}
				}

			}
		}

		void btImport_Click(object sender, EventArgs e)
		{
            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
            {
                frmImport_MTTPHH frmImport = new frmImport_MTTPHH();
                frmImport.Load();
        
			//string strMethodName = "Rosy.System.Library:RosySystem.Control.frmWaitProcess:Show";
			//string[] arrStr = strMethodName.Split(':');
			//if (arrStr.Length != 3)
			//{
			//    MessageBox.Show("Định dạng MethodName = " + strMethodName + " không đúng");
			//    return;
			//}

			//Assembly asl = Assembly.Load(arrStr[0]);

			//Type type = asl.GetType(arrStr[1]);

			//RosySystem.Control.frmWaitProcess frmWait = (RosySystem.Control.frmWaitProcess)Activator.CreateInstance(type);
			//type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frmWait, null);

			//RosySystem.Control.frmWaitProcess frmWait = new frmWaitProcess();
			//frmWait.prbWaiting.Refresh();
			//frmWait.prbWaiting.Value = 0;
			//frmWait.ShowDialog();
			
			if (frmImport.isAccept && frmImport.dtImport != null)
			{
				string strTableName = "MTTPHH";

				DataRow drDmTable = DataTool.SQLGetDataRowByID("R00DmTable", "Table_Name", strTableName);

				if (drDmTable == null)
				{
					Common.MsgCancel("Chưa khai báo bảng [" + strTableName + "]");
					return;
				}

				//Kiểm tra cột Unique phải bắt buộc có dữ liệu
				string strSQL = @"SELECT Index_Id, COL_NAME(Object_id, Column_Id) AS Column_Name
									FROM sys.index_Columns 
									WHERE Object_id = Object_id('" + drDmTable["Table_Name0"].ToString() + @"') AND 
										Index_Id IN (
													SELECT Index_Id 
														FROM sys.indexes
														WHERE object_id = object_id('" + drDmTable["Table_Name0"].ToString() + @"') AND  IS_UNIQUE = 1) AND
										Column_Id NOT IN (
													SELECT Column_Id 
														FROM Sys.Columns 
														WHERE Object_Id = Object_Id('" + drDmTable["Table_Name0"].ToString() + @"') AND Is_Identity = 1)";

				DataTable dtUniqueColumn = SQLExec.ExecuteReturnDt(strSQL);
				foreach (DataRow drCheck in dtUniqueColumn.Rows)
				{
					if (!frmImport.dtImport.Columns.Contains(drCheck["Column_Name"].ToString()))
					{
						Common.MsgCancel("Import dữ liệu bảng [" + strTableName + "] thiếu trường [" + drCheck["Column_Name"].ToString() + "], không thể import!");
						return;
					}
				}
				
				int iPrerform = 0;
				int iCount = frmImport.dtImport.Rows.Count;
				
				//Thực hiện Import
				foreach (DataRow drImport in frmImport.dtImport.Rows)
				{
					iPrerform++;
					//frmWait.prbWaiting.Value++;
					//frmWait.lblPerform.Text = iPrerform + "/" + iCount;

					if (drImport.RowState == DataRowState.Deleted)
						continue;

					if (frmImport.rdbImport_Not_All_Melt.Checked)
					{
						if (DataTool.SQLCheckExist("R81MTTPHH", "No_Melt", drImport["No_Melt"].ToString()))
							continue;
					}

					if (drImport.Table.Columns.Contains("TT_Seq") && drImport["TT_Seq"].ToString() == "")
						drImport["TT_Seq"] = 0;

					if (drImport.Table.Columns.Contains("C") && drImport["C"].ToString() == "")
						drImport["C"] = 0;

					if (drImport.Table.Columns.Contains("C") && drImport["C"].ToString() == "")
						drImport["C"] = 0;

					if (drImport.Table.Columns.Contains("Mn") && drImport["Mn"].ToString() == "")
						drImport["Mn"] = 0;

					if (drImport.Table.Columns.Contains("Si") && drImport["Si"].ToString() == "")
						drImport["Si"] = 0;

					if (drImport.Table.Columns.Contains("P") && drImport["P"].ToString() == "")
						drImport["P"] = 0;

					if (drImport.Table.Columns.Contains("S") && drImport["S"].ToString() == "")
						drImport["S"] = 0;

					if (drImport.Table.Columns.Contains("Cr") && drImport["Cr"].ToString() == "")
						drImport["Cr"] = 0;

					if (drImport.Table.Columns.Contains("Ni") && drImport["Ni"].ToString() == "")
						drImport["Ni"] = 0;

					if (drImport.Table.Columns.Contains("Mo") && drImport["Mo"].ToString() == "")
						drImport["Mo"] = 0;

					if (drImport.Table.Columns.Contains("Cu") && drImport["Cu"].ToString() == "")
						drImport["Cu"] = 0;
					
					if (drImport.Table.Columns.Contains("Al") && drImport["Al"].ToString() == "")
						drImport["Al"] = 0;

					if (drImport.Table.Columns.Contains("V") && drImport["V"].ToString() == "")
						drImport["V"] = 0;

					if (drImport.Table.Columns.Contains("W") && drImport["W"].ToString() == "")
						drImport["W"] = 0;
					
					if (drImport.Table.Columns.Contains("Sn") && drImport["Sn"].ToString() == "")
						drImport["Sn"] = 0;

					if (drImport.Table.Columns.Contains("Pb") && drImport["Pb"].ToString() == "")
						drImport["Pb"] = 0;

					if (drImport.Table.Columns.Contains("Cueq") && drImport["Cueq"].ToString() == "")
						drImport["Cueq"] = 0;

					if (drImport.Table.Columns.Contains("Ceq") && drImport["Ceq"].ToString() == "")
						drImport["Ceq"] = 0;

					if (drImport.Table.Columns.Contains("N") && drImport["N"].ToString() == "")
						drImport["N"] = 0;

					if (drImport.Table.Columns.Contains("C_Mn_6") && drImport["C_Mn_6"].ToString() == "")
						drImport["C_Mn_6"] = 0;

					if (drImport.Table.Columns.Contains("Ca_PPM") && drImport["Ca_PPM"].ToString() == "")
						drImport["Ca_PPM"] = 0;

					if (drImport.Table.Columns.Contains("C_10_Sn") && drImport["C_10_Sn"].ToString() == "")
						drImport["C_10_Sn"] = 0;


					DataRow drNew = dtMTTPHH.NewRow();
					DataTool.SetDefaultDataRow(ref drNew);
					Common.CopyDataRow(drImport, drNew);

					if (drNew.Table.Columns.Contains("Ma_DvCs") && drNew["Ma_DvCs"].ToString() == "")
						drNew["Ma_DvCs"] = RosySystem.Element.Element.sysMa_DvCs;

					if (drNew.Table.Columns.Contains("Ma_Data") && drNew["Ma_Data"].ToString() == "")
						drNew["Ma_Data"] = RosySystem.Element.Element.sysMa_Data;

					if (drNew.Table.Columns.Contains("Create_Log"))
						drNew["Create_Log"] = Common.GetCurrent_Log();

					if (DataTool.SQLUpdate(enuEdit.New, drDmTable["Table_Name0"].ToString(), ref drNew))
					{
						dtMTTPHH.Rows.Add(drNew);
					}
				}
			}
            }
            else
                Common.MsgOk("Bạn không có quyền import dữ liệu");
			//frmWait.Close();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

        void btInherit_Click(object sender, EventArgs e)
        {
            //lấy mẻ mới nhất
            int iMax = Common.MaxDCPosition(dtMTTPHH, "Ident00","LEN(Ca) = 2");
            string strNo_Melt = ""; string strCa = ""; double dbTT_Seq = 0; string strLoai_Phoi = ""; string strPattern_Pos = "";
            if (iMax != null && iMax != 0)
            {
               
                DataRow drMTTPHH = dtMTTPHH.Rows[iMax];
                string strMaxMelt = drMTTPHH["No_Melt"].ToString();
                strCa = drMTTPHH["Ca"].ToString();
                strLoai_Phoi = drMTTPHH["Billet_Size"].ToString();
                strPattern_Pos = drMTTPHH["Pattern_Pos"].ToString();
                dbTT_Seq = Convert.ToDouble(drMTTPHH["TT_Seq"]) + 1;
				
                strNo_Melt = strMaxMelt.Substring(0, 2) + SQLExec.ExecuteReturnValue("SELECT replace(STR('"+ Convert.ToString(Convert.ToDouble(strMaxMelt.Substring(2, 5)) + 1) +"',5),' ','0')");
				//strNo_Melt = strMaxMelt.Substring(0, 1) + SQLExec.ExecuteReturnValue("SELECT replace(STR('"+ Convert.ToString(Convert.ToDouble(strMaxMelt.Substring(1, 4)) + 1) +"',4),' ','0')");
			}


			frmInherit_MTTPHH frm = new frmInherit_MTTPHH();
           frm.Load(strNo_Melt, strCa, strLoai_Phoi, dbTT_Seq, strPattern_Pos);
           if (frm.Is_Accept)
           {
               DataRow drNew = frm.dtInheritVoucher.Select("Chon = 1")[0];
               if (DataTool.SQLUpdate(enuEdit.New, "R81MTTPHH", ref drNew))
               {
                   FillData();
               }
           }
        }
		#endregion 

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F9)
			{
				this.FillData();
				return;
			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			dgvMTTPHH.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvMTTPHH.Columns.Contains("C"))
				dgvMTTPHH.Columns["C"].HeaderText = "C";

			if (dgvMTTPHH.Columns.Contains("N"))
				dgvMTTPHH.Columns["N"].HeaderText = "N";

			if (dgvMTTPHH.Columns.Contains("Description"))
				dgvMTTPHH.Columns["Description"].HeaderText = "Ghi chú";

			if (dgvMTTPHH.Columns.Contains("Grade_Name"))
				dgvMTTPHH.Columns["Grade_Name"].Frozen = true;			
		}
	}
}