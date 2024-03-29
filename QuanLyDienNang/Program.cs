﻿using QuanLyDienNang.Forms;
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
			Mutex singleton = new Mutex(false, "SingleInstanceMutex");
			if (singleton.WaitOne(0, false))
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(Form_Main.Instance);
				singleton.Close();
			}
			else
			{
				MessageBox.Show("Chương trình này đang chạy trong hệ thống. Bạn không thể mở cùng lúc nhiều cửa sổ của chương trình này được.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
