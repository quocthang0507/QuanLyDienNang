using DataAccess;
using System;
using System.Data;
using System.Windows.Forms;

namespace Business.Classes
{
	public class Funcs_NguoiQuanLy
	{
		public DataTable LoadTable()
		{
			try
			{
				var dt = new DataTable();
				var reader = DataProvider.Instance.ExecuteReader("proc_GetAll_NguoiQuanLy");
				dt.Load(reader);
				return dt;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public bool Insert(string TenQuanLy, string SoDienThoai, string DiaChi, string Email)
		{
			try
			{
				DataProvider.Instance.ExecuteNonQuery("proc_Insert_NguoiQuanLy", TenQuanLy, SoDienThoai, DiaChi, Email);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
