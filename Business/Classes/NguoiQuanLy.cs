using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Classes
{
	[Table("NguoiQuanLy")]
	public class NguoiQuanLy
	{
		[Key]
		[DisplayName("Mã quản lý")]
		[StringLength(5)]
		public string MaQuanLy { get; set; }

		[DisplayName("Tên quản lý")]
		[StringLength(150)]
		[Required]
		public string TenQuanLy { get; set; }

		[DisplayName("Số điện thoại")]
		[StringLength(20)]
		public string SoDienThoai { get; set; }

		[DisplayName("Địa chỉ")]
		[StringLength(200)]
		[Required]
		public string DiaChi { get; set; }

		[DisplayName("Email")]
		[StringLength(100)]
		public string Email { get; set; }

		public NguoiQuanLy()
		{

		}

		public static List<NguoiQuanLy> GetAll()
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
	}
}
