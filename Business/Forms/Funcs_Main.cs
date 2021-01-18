using Business.Helper;
using DataAccess;

namespace Business.Forms
{
	/// <summary>
	/// Lớp chức năng cho form chính
	/// </summary>
	public class Funcs_Main
	{
		private readonly string SECTION_INI = "KieuHienThi";
		private readonly string KEY_COL_SIZE_MODE_INI = "ColumnSizeMode";

		/// <summary>
		/// Kiểm tra chuỗi kết nối có lấy được từ tập tin INI hay không
		/// </summary>
		/// <returns>Chuỗi hợp lệ hay không</returns>
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
		/// Lấy tên máy chủ từ chuỗi kết nối
		/// </summary>
		/// <returns>Null hoặc tên máy chủ</returns>
		public string GetSQLServerName()
		{
			Funcs_ConnectionString funcs = new Funcs_ConnectionString();
			if (funcs.SqlConnectionString != null)
			{
				return funcs.SqlConnectionString.ServerName;
			}

			return null;
		}

		/// <summary>
		/// Lấy tên cơ sở dữ liệu từ chuỗi kết nối
		/// </summary>
		/// <returns>Null hoặc tên cơ sở dữ liệu</returns>
		public string GetDatabase()
		{
			Funcs_ConnectionString funcs = new Funcs_ConnectionString();
			if (funcs.SqlConnectionString != null)
			{
				return funcs.SqlConnectionString.Database;
			}

			return null;
		}

		public void SaveColumnSizeMode(string mode)
		{
			Configuration.Instance.Write(KEY_COL_SIZE_MODE_INI, mode, SECTION_INI);
		}

		public string GetSavedColumnSizeMode()
		{
			return Configuration.Instance.Read(KEY_COL_SIZE_MODE_INI, SECTION_INI);
		}
	}
}
