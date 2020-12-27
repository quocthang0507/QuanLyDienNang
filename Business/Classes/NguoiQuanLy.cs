using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Business.Classes
{
	public class NguoiQuanLy
	{

		public string MaQuanLy { get; set; }
		public string TenQuanLy { get; set; }
		public string SoDienThoai { get; set; }
		public string DiaChi { get; set; }
		public string Email { get; set; }

		public NguoiQuanLy()
		{

		}

		public NguoiQuanLy(string tenQuanLy, string soDienThoai, string diaChi, string email)
		{
			TenQuanLy = tenQuanLy;
			SoDienThoai = soDienThoai;
			DiaChi = diaChi;
			Email = email;
		}

		public NguoiQuanLy(string maQuanLy, string tenQuanLy, string soDienThoai, string diaChi, string email)
		{
			MaQuanLy = maQuanLy;
			TenQuanLy = tenQuanLy;
			SoDienThoai = soDienThoai;
			DiaChi = diaChi;
			Email = email;
		}

		public static List<NguoiQuanLy> All()
			=> CBO.FillCollection<NguoiQuanLy>(DataProvider.Instance.ExecuteReader("proc_GetAll_NguoiQuanLy"));

		public static bool Add(NguoiQuanLy nguoiQuanLy)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_NguoiQuanLy", nguoiQuanLy.TenQuanLy, nguoiQuanLy.SoDienThoai, nguoiQuanLy.DiaChi, nguoiQuanLy.Email);
			return result > 0;
		}

		public static bool Update(NguoiQuanLy nguoiQuanLy)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_NguoiQuanLy", nguoiQuanLy.MaQuanLy, nguoiQuanLy.TenQuanLy, nguoiQuanLy.SoDienThoai, nguoiQuanLy.DiaChi, nguoiQuanLy.Email);
			return result > 0;
		}

		public static bool Delete(string id)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_NguoiQuanLy", id);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static BindingSource LoadTable()
		{
			try
			{
				var binding = new BindingSource();
				var list = All();
				binding.DataSource = list;
				return binding;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
