using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RosyModule
{
	public class txtTime : MaskedTextBox
	{

		private bool bSelectOnFocus = false;
		private string strPreviousText;
		private bool bDeleteKey = false;
		private int iPotition = 0;

		public txtTime()
		{
			this.Mask = "00:00:00";
			this.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			this.InsertKeyMode = InsertKeyMode.Overwrite;
			this.ResetOnPrompt = true;
			this.AllowPromptAsInput = true;
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(txtTime_KeyDown);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// txtTime
			// 
			this.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
			this.ResumeLayout(false);
		}

		public bool SelectOnFocus
		{
			get { return bSelectOnFocus; }
			set { bSelectOnFocus = value; }
		}

		public bool IsNull
		{
			get
			{
				if (this.Text.Replace(" ", "") == "::")
					return true;
				else
					return false;
			}
		}

		void txtTime_KeyDown(object sender, KeyEventArgs e)
		{
			this.strPreviousText = this.Text;
			this.iPotition = this.SelectionStart;

			if (e.KeyCode == Keys.Back)
			{
				this.bDeleteKey = true;
				this.iPotition = this.SelectionStart;
			}
			if (e.KeyCode == Keys.Delete)
			{
				this.bDeleteKey = true;
				this.iPotition = this.SelectionStart + 1;
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);

			if (this.bSelectOnFocus)
				this.SelectAll();
			else
			{
				this.SelectionStart = 0;
				this.SelectionLength = 0;
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Enter:
				case Keys.Down:
					return this.ProcessDialogKey(Keys.Tab);

				case Keys.Up:
					return this.ProcessDialogKey(Keys.Shift | Keys.Tab);
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
