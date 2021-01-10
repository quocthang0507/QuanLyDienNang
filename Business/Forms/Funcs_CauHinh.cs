using DataAccess;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace Business.Forms
{
	/// <summary>
	/// Lớp chức năng cho form cấu hình
	/// </summary>
	public class Funcs_CauHinh
	{
		private SQLConnectionString sqlConnection = new SQLConnectionString();
		private Funcs_ConnectionString funcs;

		/// <summary>
		/// Lấy danh sách máy chủ SQL Server trên máy tính
		/// </summary>
		/// <returns>Danh sách máy chủ</returns>
		public static List<string> GetServers()
		{
			List<string> servers = new List<string>();
			// Lấy tên máy tính
			string ComputerName = Environment.MachineName;
			// Phiên bản 32 hay 64 bit
			RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
			// Lấy các tên máy chủ trong máy
			using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
			{
				RegistryKey InstanceName = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
				if (InstanceName != null)
				{
					foreach (string instanceName in InstanceName.GetValueNames())
					{
						servers.Add(ComputerName + "\\" + instanceName);
					}
				}
			}
			return servers;
		}

		/// <summary>
		/// Kiểm tra kết nối
		/// </summary>
		/// <param name="server">Tên máy chủ SQL</param>
		/// <param name="database">Tên cơ sở dữ liệu</param>
		/// <returns></returns>
		public bool TestConnectionString(string server, string database)
		{
			sqlConnection = new SQLConnectionString(server, database);
			return sqlConnection.TestConnection();
		}

		/// <summary>
		/// Kiểm tra kết nối
		/// </summary>
		/// <param name="server">Tên máy chủ SQL</param>
		/// <param name="database">Tên cơ sở dữ liệu</param>
		/// <param name="username">Tên đăng nhập</param>
		/// <param name="password">Mật khẩu</param>
		/// <returns></returns>
		public bool TestConnectionString(string server, string database, string username, string password)
		{
			sqlConnection = new SQLConnectionString(server, database, username, password);
			return sqlConnection.TestConnection();
		}

		/// <summary>
		/// Lưu kết nối vào tập tin INI
		/// </summary>
		public void SaveConnectionString()
		{
			if (sqlConnection != null)
			{
				funcs = new Funcs_ConnectionString(sqlConnection);
				funcs.SaveConnectionString();
			}
		}

		/// <summary>
		/// Lấy các tham số của chuỗi kết nối đã được lưu trước đó
		/// </summary>
		/// <param name="server">Tên máy chủ SQL</param>
		/// <param name="database">Tên cơ sở dữ liệu</param>
		/// <param name="username">Tên đăng nhập</param>
		/// <param name="password">Mật khẩu</param>
		public void GetSavedConnectionString(ref string server, ref string database, ref string username, ref string password)
		{
			funcs = new Funcs_ConnectionString();
			sqlConnection = funcs.GetSavedConnectionString();
			if (sqlConnection != null)
			{
				server = sqlConnection.ServerName;
				database = sqlConnection.Database;
				username = sqlConnection.Username;
				password = sqlConnection.Password;
			}
		}
	}
}
