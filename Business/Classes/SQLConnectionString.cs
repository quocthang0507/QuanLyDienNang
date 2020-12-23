﻿using System.Data.SqlClient;
using ThuVien.Helper;

namespace ThuVien.Classes
{
	public class SQLConnectionString
	{
		private string ServerName;
		private string Database;
		private string Username;
		private string Password;
		private int IndexFunction;
		private readonly string cnn1 = @"Server={0};Database=;Integrated Security=True;";
		private readonly string cnn2 = @"Server={0};Database={1};Integrated Security=True;";
		private readonly string cnn3 = @"Server={0};Database={1};User Id={2};Password={3};Integrated Security=True;";
		private readonly string SECTION_INI = "ChuoiKetNoiSQLServer";
		private readonly string KEY_CONNSTR_INI = "ConnectionString";

		/// <summary>
		/// Khởi tạo chuỗi kết nối rỗng
		/// </summary>
		public SQLConnectionString()
		{
			this.IndexFunction = 0;
		}

		/// <summary>
		/// Khởi tạo chuỗi kết nối chỉ có tên server
		/// </summary>
		/// <param name="serverName">Tên server</param>
		public SQLConnectionString(string serverName)
		{
			this.ServerName = serverName;
			this.IndexFunction = 1;
		}

		/// <summary>
		/// Khởi tạo chuỗi kết nối với tên server và tên cơ sở dữ liệu
		/// </summary>
		/// <param name="serverName">Tên server</param>
		/// <param name="database">Tên cơ sở dữ liệu</param>
		public SQLConnectionString(string serverName, string database)
		{
			this.ServerName = serverName;
			this.Database = database;
			this.IndexFunction = 2;
		}

		/// <summary>
		/// Khởi tạo chuỗi kết nối với tên server, thông tin đăng nhập
		/// </summary>
		/// <param name="serverName">Tên server</param>
		/// <param name="username">Tên đăng nhập</param>
		/// <param name="password">Mật khẩu</param>
		public SQLConnectionString(string serverName, string username, string password)
		{
			this.ServerName = serverName;
			this.Database = "master";
			this.Username = username;
			this.Password = password;
			this.IndexFunction = 3;
		}

		/// <summary>
		/// Khởi tạo chuỗi kết nối với tên server, tên cơ sở dữ liệu và thông tin đăng nhập
		/// </summary>
		/// <param name="serverName">Tên server</param>
		/// <param name="database">Tên cơ sở dữ liệu</param>
		/// <param name="username">Tên đăng nhập</param>
		/// <param name="password">Mật khẩu</param>
		public SQLConnectionString(string serverName, string database, string username, string password)
		{
			this.ServerName = serverName;
			this.Database = database;
			this.Username = username;
			this.Password = password;
			this.IndexFunction = 3;
		}

		/// <summary>
		/// Trả về chuỗi kết nối đến cơ sở dữ liệu tương ứng
		/// </summary>
		public string ConnectionString
		{
			get
			{
				switch (IndexFunction)
				{
					case 0:
						return "";
					case 1:
						return string.Format(cnn1, ServerName);
					case 2:
						return string.Format(cnn2, ServerName, Database);
					case 3:
						return string.Format(cnn3, ServerName, Database, Username, Password);
					default:
						return "";
				}
			}
		}

		/// <summary>
		/// Kiểm tra kết nối đến một server
		/// Sử dụng Windows Authentication
		/// </summary>
		/// <returns>Kết nối thành công</returns>
		public bool TestConnection()
		{
			try
			{
				SqlConnection connection = new SqlConnection(ConnectionString);
				connection.Open();
				connection.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void SaveConnectionString()
		{
			Configuration.Instance.Write(KEY_CONNSTR_INI, ConnectionString, SECTION_INI);
		}

		public string GetSavedConnectionString()
		{
			return Configuration.Instance.Read(KEY_CONNSTR_INI, SECTION_INI);
		}
	}
}
