using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace ColorOrgan
{
	internal class TranscribeDialog : Form
	{
		private IContainer components = null;
		private ProgressBar progressBar;
		public int Progress
		{
			set
			{
				progressBar.Value = value;
				Refresh();
			}
		}
		public TranscribeDialog(int maximum)
		{
			InitializeComponent();
			progressBar.Maximum = maximum;
			progressBar.Minimum = 0;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			progressBar = new ProgressBar();
			base.SuspendLayout();
			progressBar.Location = new Point(12, 22);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(314, 23);
			progressBar.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(338, 66);
			base.ControlBox = false;
			base.Controls.Add(progressBar);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Name = "TranscribeDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "Transcribing...";
			base.ResumeLayout(false);
		}
	}
}
