using System.Data;

namespace DataAccess
{
	/// <summary>
	/// Lớp truy cập chính đến cơ sở dữ liệu
	/// </summary>
	public abstract class DataProvider
	{
		public abstract object ExecuteNonQueryWithOutput(string outputParam, string spName, params object[] parameterValues);
		public abstract int ExecuteNonQuery(string spName, params object[] parameterValues);
		public abstract DataSet ExecuteDataset(string spName, params object[] parameterValues);
		public abstract IDataReader ExecuteReader(string spName, params object[] parameterValues);
		public abstract object ExecuteScalar(string spName, params object[] parameterValues);
		public static string ConnectionString { get; set; }

		private static DataProvider instance;

		public static DataProvider Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new SqlDataProvider(ConnectionString);
				}

				return instance;
			}
		}
	}
}
