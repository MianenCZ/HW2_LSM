using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2_LSM
{
	public partial class Form1 : Form
	{
		public const string AppName = "LSM Charter";
		public Form1()
		{
			InitializeComponent();
		}

		public Form1(Loader Input)
		{
			InitializeComponent();
			LoadFrom(Input);
		}

		private void FormSizeChange(object sender, EventArgs e)
		{
			this.chart1.Size = new Size(this.Size.Width - 42, this.Size.Height - 89);
		}

		private void LoadFrom(Loader Input)
		{
			this.chart1.Series.Clear();
			for (int i = 0; i < Input.Data.Length; i++)
				this.chart1.Series.Add(Input.Data[i]);
			this.Text = $"{AppName} - {Input.FileName}";
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				LoadFrom(new Loader(openFileDialog1.FileName));
			}
		}
	}
}
