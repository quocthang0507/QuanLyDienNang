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

		[DisplayName("Chu kỳ tháng")]
		public int ChuKyThang { get; set; }

		[DisplayName("Ngày cập nhật")]
		[Required]
		public DateTime NgayCapNhat { get; set; }

		[DisplayName("Người cập nhật")]
		[StringLength(5)]
		[Required]
		public string NguoiCapNhat { get; set; }

		[DisplayName("Ngày hóa đơn")]
		public DateTime NgayHoaDon { get; set; }

		[DisplayName("Ngày trả tiền")]
		public DateTime NgayTraTien { get; set; }

		[DisplayName("Chỉ số mới")]
		[Required]
		[DefaultValue(0)]
		public int ChiSoMoi { get; set; }

		[DisplayName("Chỉ số cũ")]
		[Required]
		[DefaultValue(0)]
		public int ChiSoCu { get; set; }

		[DisplayName("Tổng tiền trước VAT")]
		public int TongTienTruocVAT { get; set; }

		[DisplayName("Tổng tiền sau VAT")]
		public int TongTienSauVAT { get; set; }

		[DisplayName("Đã trả")]
		[DefaultValue(0)]
		public int DaTra { get; set; }

		[DisplayName("Còn lại")]
		public int ConLai { get; set; }

		public DienNangTieuThu()
		{

		}

		public static List<DienNangTieuThu> GetAll()
			=> CBO.FillCollection<DienNangTieuThu>(DataProvider.Instance.ExecuteReader("proc_GetAll_DienNangTieuThu"));

		public static bool Insert(DienNangTieuThu dienNangTieuThu)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_DienNangTieuThu", dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.ChuKyThang, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.NgayHoaDon, dienNangTieuThu.NgayTraTien, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.TongTienTruocVAT, dienNangTieuThu.TongTienSauVAT, dienNangTieuThu.DaTra, dienNangTieuThu.ConLai);
			return result > 0;
		}

		public static bool Update(DienNangTieuThu dienNangTieuThu)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_DienNangTieuThu", dienNangTieuThu.ID, dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.ChuKyThang, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.NgayHoaDon, dienNangTieuThu.NgayTraTien, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.TongTienTruocVAT, dienNangTieuThu.TongTienSauVAT, dienNangTieuThu.DaTra, dienNangTieuThu.ConLai);
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

		public static List<DienNangTieuThu> Filter()
		{
			List<DienNangTieuThu> list = GetAll();

			return list;
		}
	}
}
