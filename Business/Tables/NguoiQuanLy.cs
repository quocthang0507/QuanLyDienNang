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
		[StringLength(20)]
		public string MaQuanLy { get; set; }

		[DisplayName("Tên quản lý")]
		[StringLength(100)]
		[Required]
		public string TenQuanLy { get; set; }

		[DisplayName("Số điện thoại")]
		[StringLength(20)]
		public string SoDienThoai { get; set; }

		[DisplayName("Địa chỉ")]
		[StringLength(250)]
		[Required]
		public string DiaChi { get; set; }

		[DisplayName("Email")]
		[StringLength(100)]
		public string Email { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		public bool KichHoat { get; set; }

		public NguoiQuanLy()
		{

		}

		public static List<NguoiQuanLy> GetAll()
		{
			return CBO.FillCollection<NguoiQuanLy>(DataProvider.Instance.ExecuteReader("proc_GetAll_NguoiQuanLy"));
		}

		public static bool IsDuplicatedMaQuanLy(string maQuanLy)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_IsDuplicated_MaQuanLy", maQuanLy);
			return result == 1;
		}

		public static bool Insert(NguoiQuanLy nguoiQuanLy)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_NguoiQuanLy", nguoiQuanLy.MaQuanLy, nguoiQuanLy.TenQuanLy, nguoiQuanLy.SoDienThoai, nguoiQuanLy.DiaChi, nguoiQuanLy.Email);
			return result > 0;
		}

		public static bool Update(NguoiQuanLy nguoiQuanLy)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_NguoiQuanLy", nguoiQuanLy.MaQuanLy, nguoiQuanLy.TenQuanLy, nguoiQuanLy.SoDienThoai, nguoiQuanLy.DiaChi, nguoiQuanLy.Email, nguoiQuanLy.KichHoat);
			return result > 0;
		}

		public static bool Delete(string id)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_NguoiQuanLy", id);
			return result > 0;
		}
	}
}
