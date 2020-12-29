using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Classes
{
	[Table("DienNangTieuThu")]
	public class DienNangTieuThu
	{
		[Key]
		[DisplayName("ID")]
		public int ID { get; set; }

		[DisplayName("Mã khách hàng")]
		[StringLength(9)]
		[Required]
		public string MaKhachHang { get; set; }

		[DisplayName("Ngày ghi")]
		[Required]
		public DateTime NgayGhi { get; set; }

		[DisplayName("Người ghi")]
		[StringLength(5)]
		[Required]
		public string NguoiGhi { get; set; }

		[DisplayName("Ngày cập nhật")]
		[Required]
		public DateTime NgayCapNhat { get; set; }

		[DisplayName("Người cập nhật")]
		[StringLength(5)]
		[Required]
		public string NguoiCapNhat { get; set; }

		[DisplayName("Chỉ số mới")]
		[Required]
		[DefaultValue(0)]
		public int ChiSoMoi { get; set; }

		[DisplayName("Chỉ số cũ")]
		[Required]
		[DefaultValue(0)]
		public int ChiSoCu { get; set; }

		[DisplayName("Đã thanh toán")]
		[Required]
		[DefaultValue(0)]
		public bool DaThanhToan { get; set; }

		public DienNangTieuThu()
		{

		}

		public DienNangTieuThu(int iD, string maKhachHang, DateTime ngayGhi, string nguoiGhi, DateTime ngayCapNhat, string nguoiCapNhat, int chiSoMoi, int chiSoCu, bool daThanhToan)
		{
			ID = iD;
			MaKhachHang = maKhachHang;
			NgayGhi = ngayGhi;
			NguoiGhi = nguoiGhi;
			NgayCapNhat = ngayCapNhat;
			NguoiCapNhat = nguoiCapNhat;
			ChiSoMoi = chiSoMoi;
			ChiSoCu = chiSoCu;
			DaThanhToan = daThanhToan;
		}

		public static List<DienNangTieuThu> All()
			=> CBO.FillCollection<DienNangTieuThu>(DataProvider.Instance.ExecuteReader("proc_GetAll_DienNangTieuThu"));

		public static bool Add(DienNangTieuThu dienNangTieuThu)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_DienNangTieuThu", dienNangTieuThu.ID, dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.DaThanhToan);
			return result > 0;
		}

		public static bool Update(DienNangTieuThu dienNangTieuThu)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_DienNangTieuThu", dienNangTieuThu.ID, dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.DaThanhToan);
			return result > 0;
		}

		public static bool Delete(int id)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_DienNangTieuThu", id);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
