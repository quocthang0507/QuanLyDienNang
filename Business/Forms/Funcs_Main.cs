﻿using DataAccess;

namespace Business.Forms
{
	/// <summary>
	/// Lớp chức năng cho form chính
	/// </summary>
	public class Funcs_Main
	{
		/// <summary>
		/// Kiểm tra chuỗi kết nối có lấy được từ tập tin INI hay không
		/// </summary>
		/// <returns></returns>
		public bool CheckConnectionString()
		{
			if (string.IsNullOrWhiteSpace(DataProvider.ConnectionString))
			{
				Funcs_ConnectionString funcs = new Funcs_ConnectionString();
				if (funcs.SqlConnectionString != null)
				{
					DataProvider.ConnectionString = funcs.SqlConnectionString.ConnectionString;
					return true;
				}
				return false;
			}
			return true;
		}

		/// <summary>
		/// Lấy tên server từ chuỗi kết nối
		/// </summary>
		/// <returns></returns>
		public string GetSQLServerName()
		{
			Funcs_ConnectionString funcs = new Funcs_ConnectionString();
			if (funcs.SqlConnectionString != null)
				return funcs.SqlConnectionString.ServerName;
			return null;
		}

		/// <summary>
		/// Lấy tên cơ sở dữ liệu từ chuỗi kết nối
		/// </summary>
		/// <returns></returns>
		public string GetDatabase()
		{
			Funcs_ConnectionString funcs = new Funcs_ConnectionString();
			if (funcs.SqlConnectionString != null)
				return funcs.SqlConnectionString.Database;
			return null;
		}
	}
}