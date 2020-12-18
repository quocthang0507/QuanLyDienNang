using System;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			FormWelcome splash = new FormWelcome();
			splash.Show();
			Application.Run(new FormMain(splash));
		}


	}
}
