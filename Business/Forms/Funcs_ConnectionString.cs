using Business.Helper;
using DataAccess;

namespace Business.Forms
{
	/// <summary>
	/// Lớp chức năng cho chuỗi kết nối
	/// </summary>
	public class Funcs_ConnectionString
	{
		public SQLConnectionString SqlConnectionString { get; set; }

		private readonly string SECTION_INI = "ChuoiKetNoi";
		private readonly string KEY_SERVER_INI = "Server";
		private readonly string KEY_DATABASE_INI = "Database";
		private readonly string KEY_USERNAME_INI = "Username";
		private readonly string KEY_PASSWORD_INI = "Password";

		public Funcs_ConnectionString()
		{
			SqlConnectionString = GetSavedConnectionString();
		}

		public Funcs_ConnectionString(SQLConnectionString sqlConnectionString)
		{
			this.SqlConnectionString = sqlConnectionString;
		}

		/// <summary>
		/// Lưu chuỗi kết nối hiện tại vào tập tin INI
		/// </summary>
		public void SaveConnectionString()
		{
			if (SqlConnectionString != null)
				if (!string.IsNullOrWhiteSpace(SqlConnectionString.ServerName) && !string.IsNullOrWhiteSpace(SqlConnectionString.Database))
				{
					if (!string.IsNullOrWhiteSpace(SqlConnectionString.Username) && !string.IsNullOrWhiteSpace(SqlConnectionString.Password))
					{
						Configuration.Instance.Write(KEY_USERNAME_INI, SqlConnectionString.Username, SECTION_INI);
						Configuration.Instance.Write(KEY_PASSWORD_INI, SqlConnectionString.Password, SECTION_INI);
					}
					Configuration.Instance.Write(KEY_SERVER_INI, SqlConnectionString.ServerName, SECTION_INI);
					Configuration.Instance.Write(KEY_DATABASE_INI, SqlConnectionString.Database, SECTION_INI);
					DataProvider.ConnectionString = SqlConnectionString.ConnectionString;
				}
		}

		/// <summary>
		/// Lấy chuỗi kết nối đã được lưu từ trước
		/// </summary>
		/// <returns>SQLConnectionString</returns>
		public SQLConnectionString GetSavedConnectionString()
		{
			string srv = Configuration.Instance.Read(KEY_SERVER_INI, SECTION_INI);
			string db = Configuration.Instance.Read(KEY_DATABASE_INI, SECTION_INI);
			string name = Configuration.Instance.Read(KEY_USERNAME_INI, SECTION_INI);
			string pass = Configuration.Instance.Read(KEY_PASSWORD_INI, SECTION_INI);
			if (!string.IsNullOrWhiteSpace(srv) && !string.IsNullOrWhiteSpace(db))
			{
				if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(pass))
				{
					return new SQLConnectionString(srv, db, name, pass);
				}
				return new SQLConnectionString(srv, db);
			}
			return null;
		}
	}
}
