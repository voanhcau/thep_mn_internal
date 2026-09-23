using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using System.Drawing.Printing;

namespace RosyModule
{
    public partial class frmIn_BarcodeKKV : RosySystem.Customize.frmEdit
	{
        private List<string> _files; // gọi file sang
        public frmIn_BarcodeKKV()
		{
			InitializeComponent();

            btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);
            btPrint.Click += BtPrint_Click;
            btOpen.Click += BtOpen_Click;
		}

       

        public void Load(DataRow drViewPh)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);
			
			BindingLanguage();
			LoadDicName();

           
            rdbIn_LXH.Checked = true;
			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}
        private class PdfComboItem
        {
            public string Text { get; set; }   // Hiển thị
            public string FullPath { get; set; } // Giá trị
            public bool IsAll { get; set; }
        }
        public void Load(List<string> files)
        {
            _files = files ?? new List<string>();
            BindCombo();
			rdbInCNXX.Checked = true;
            this.ShowDialog();
        }
		private void BindCombo()
		{
            var items = new List<PdfComboItem>();

            // Giá trị All
            items.Add(new PdfComboItem { Text = "All", FullPath = null, IsAll = true });

            // Các file
            items.AddRange(
                _files
                    .Where(p => !string.IsNullOrEmpty(p))
                    .Distinct()
                    .Select(p => new PdfComboItem
                    {
                        Text = Path.GetFileName(p),   // chỉ hiện tên file
                        FullPath = p,
                        IsAll = false
                    })
                    .OrderBy(x => x.Text)
            );

            cboFiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiles.DisplayMember = "Text";
            cboFiles.ValueMember = "FullPath";
            cboFiles.DataSource = items;

            // chọn mặc định "All"
            cboFiles.SelectedIndex = 0;
        }
        private void BtOpen_Click(object sender, EventArgs e)
        {
            var selected = cboFiles.SelectedItem as PdfComboItem;
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn file trong danh sách.");
                return;
            }

            if (selected.IsAll)
            {
                MessageBox.Show("Vui lòng chọn 1 file cụ thể (không phải All) để mở xem.");
                return;
            }

            string path = selected.FullPath;
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                MessageBox.Show("File không tồn tại:\n" + path);
                return;
            }

            try
            {
                // Mở bằng ứng dụng mặc định
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được file: " + ex.Message);
            }
        }
        private void BtPrint_Click(object sender, EventArgs e)
        {
            var selected = cboFiles.SelectedItem as PdfComboItem;
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn file.");
                return;
            }

            // 1) Hiện hộp thoại chọn máy in của Windows
            string printerName;
            using (var dlg = new PrintDialog())
            {
                dlg.AllowSomePages = false;
                dlg.AllowSelection = false;
                dlg.UseEXDialog = true;

                // gán printer settings mặc định để dialog hiển thị đúng
                dlg.PrinterSettings = new PrinterSettings();

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return; // user bấm Cancel

                printerName = dlg.PrinterSettings.PrinterName;
            }

            try
            {
                var items = (List<PdfComboItem>)cboFiles.DataSource;

                if (selected.IsAll)
                {
                    foreach (var it in items.Where(x => !x.IsAll))
                    {
                        PrintPdfPreferFoxit(it.FullPath, printerName);
                    }
                }
                else
                {
                    PrintPdfPreferFoxit(selected.FullPath, printerName);
                }

                MessageBox.Show("Đã gửi lệnh in đến: " + printerName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in: " + ex.Message);
            }
            finally
            {
               
            }
            //try
            //{
            //    var items = (List<PdfComboItem>)cboFiles.DataSource;

            //    if (selected.IsAll)
            //    {
            //        // In tất cả (bỏ item All)
            //        foreach (var it in items.Where(x => !x.IsAll))
            //        {
            //            PrintPdfByDefaultApp(it.FullPath);
            //        }
            //    }
            //    else
            //    {
            //        // In 1 file
            //        PrintPdfByDefaultApp(selected.FullPath);
            //    }

            //    MessageBox.Show("Đã gửi lệnh in.");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi in: " + ex.Message);
            //}
            //finally
            //{

            //}
        }
        private static string FindFoxitExe()
        {
            // Foxit đời cũ thường là FoxitReader.exe trong "Foxit Reader" :contentReference[oaicite:1]{index=1}
            // Foxit đời mới thường là FoxitPDFReader.exe trong "Foxit PDF Reader" :contentReference[oaicite:2]{index=2}
            string[] candidates =
            {
                // Foxit PDF Reader (mới)
                @"C:\Program Files\Foxit Software\Foxit PDF Reader\FoxitPDFReader.exe",
                @"C:\Program Files (x86)\Foxit Software\Foxit PDF Reader\FoxitPDFReader.exe",

                // Foxit Reader (cũ)
                @"C:\Program Files\Foxit Software\Foxit Reader\FoxitReader.exe",
                @"C:\Program Files (x86)\Foxit Software\Foxit Reader\FoxitReader.exe",
            };


            foreach (var p in candidates)
                if (File.Exists(p)) return p;

            return null;
        }
        private static void PrintWithFoxit(string foxitExe, string pdfPath, string printerName)
        {
            if (string.IsNullOrEmpty(printerName))
                throw new Exception("Chưa có tên máy in. Hãy chọn máy in trước.");

            // Foxit: /t "pdfPath" "printerName" :contentReference[oaicite:3]{index=3}
            var psi = new ProcessStartInfo
            {
                FileName = foxitExe,
                Arguments = string.Format("/t \"{0}\" \"{1}\"", pdfPath, printerName),
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(psi);
        }
        private static void PrintPdfByDefaultApp(string pdfPath)
        {
            if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
                throw new FileNotFoundException("Không tìm thấy file: " + pdfPath);

            var psi = new ProcessStartInfo
            {
                FileName = pdfPath,
                Verb = "print",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            // Nhiều trình đọc PDF sẽ tự xử lý print, có trình sẽ mở lên 1 chút rồi đóng.
            Process.Start(psi);
        }
        public static void PrintPdfPreferFoxit(string pdfPath, string printerName)
        {
            if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
                throw new FileNotFoundException("Không tìm thấy file: " + pdfPath);

            string foxitExe = FindFoxitExe();
            if (!string.IsNullOrEmpty(foxitExe))
            {
                PrintWithFoxit(foxitExe, pdfPath, printerName);
                return;
            }

            // Fallback nếu máy không có Foxit:
            // - nếu bạn có Adobe thì gọi Adobe /t
            // - hoặc in bằng app mặc định (không chọn được printer cụ thể)
            PrintByDefaultApp(pdfPath);
        }
        private static void PrintByDefaultApp(string pdfPath)
        {
            // In theo app mặc định của Windows (thường là máy in mặc định)
            var psi = new ProcessStartInfo
            {
                FileName = pdfPath,
                Verb = "print",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(psi);
        }
        private void btAccept_Click(object sender, EventArgs e)
		{
            
            isAccept = true;
            this.Close();
         }

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
      
	}
}
