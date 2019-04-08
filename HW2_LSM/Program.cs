using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2_LSM
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if(args.Length == 0)
				Application.Run(new Form1());
			else if (args.Length == 1)
				Application.Run(new Form1(new Loader(args[0])));
			else
			{
				Console.WriteLine("Argument Error");
			}
		}
	}
}
