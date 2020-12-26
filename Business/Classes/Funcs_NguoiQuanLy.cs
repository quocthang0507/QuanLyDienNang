using DataAccess;
using System;
using System.Data;

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
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_NguoiQuanLy", TenQuanLy, SoDienThoai, DiaChi, Email);
				if (result > 0)
					return true;
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Update(string MaQuanLy, string TenQuanLy, string SoDienThoai, string DiaChi, string Email)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_NguoiQuanLy", MaQuanLy, TenQuanLy, SoDienThoai, DiaChi, Email);
				if (result > 0)
					return true;
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Delete(string MaQuanLy)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_NguoiQuanLy", MaQuanLy);
				if (result > 0)
					return true;
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
