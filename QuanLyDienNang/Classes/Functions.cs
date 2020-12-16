using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyDienNang.Classes
{
	public class Functions
	{
		private static SqlConnection con;

		public static void Connect()
		{
			con = new SqlConnection
			{
				ConnectionString = Properties.Settings.Default.quanlydien_sqlConnectionString
			};
			con.Open();
		}  // tạo kết nối

		public static DataTable GetDataToTable(string sql) // lệnh lấy dữ liệu
		{
			DataTable table = new DataTable();
			SqlDataAdapter dap = new SqlDataAdapter(sql, con);
			dap.Fill(table);
			return table;
		}

		public static void RunSQL(string sql)
		{
			SqlCommand cmd = new SqlCommand
			{
				Connection = con, //Gán kết nối
				CommandText = sql //Gán lệnh SQL
			};
			try
			{
				cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			cmd.Dispose();//Giải phóng bộ nhớ
		}

		public static bool CheckKey(string sql) // hàm kiểm tra khóa trùng
		{
			SqlDataAdapter dap = new SqlDataAdapter(sql, con);
			DataTable table = new DataTable();
			dap.Fill(table);
			if (table.Rows.Count > 0)
				return true;
			else
				return false;
		}
	}
}
