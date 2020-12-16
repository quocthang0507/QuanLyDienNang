using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyDienNang.Classes
{
	public class Common
	{
		private SqlConnection con;

		private void Connect()
		{
			con = new SqlConnection
			{
				ConnectionString = Properties.Settings.Default.connectionString
			};
			con.Open();
		}

		public Common()
		{
			Connect();
		}

		public DataTable ExecuteQuery(string sql)
		{
			DataTable table = new DataTable();
			try
			{
				SqlDataAdapter dap = new SqlDataAdapter(sql, con);
				dap.Fill(table);
			}
			catch (Exception ex)
			{
				return null;
			}
			return table;
		}

		public int ExecuteNonQuery(string sql)
		{
			int rows = 0;
			SqlCommand cmd = new SqlCommand
			{
				Connection = con,
				CommandText = sql
			};
			try
			{
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				return 0;
			}
			return rows;
		}
	}
}
