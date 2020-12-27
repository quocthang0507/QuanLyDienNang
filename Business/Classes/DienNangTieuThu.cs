using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Business.Classes
{
	public class DienNangTieuThu
	{
		public int ID { get; set; }
		public string MaKhachHang { get; set; }
		public DateTime NgayGhi { get; set; }
		public string NguoiGhi { get; set; }
		public DateTime NgayCapNhat { get; set; }
		public string NguoiCapNhat { get; set; }
		public int ChiSoMoi { get; set; }
		public int ChiSoCu { get; set; }
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

		public static BindingSource LoadTable()
		{
			try
			{
				var binding = new BindingSource();
				var list = DienNangTieuThu.All();
				binding.DataSource = list;
				return binding;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}
	}
}
