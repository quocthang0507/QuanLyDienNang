using Business.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Business.Forms
{
	/// <summary>
	/// Lớp chức năng cho form DienNangTieuThu
	/// </summary>
	public class Funcs_DienNangTieuThu
	{
		/// <summary>
		/// Lấy danh sách khách hàng qua bảng DienNangTieuThu
		/// </summary>
		/// <param name="MaQuanLy">Mã của người quản lý</param>
		/// <param name="NgayBD">Ngày bắt đầu</param>
		/// <param name="NgayKT">Ngày kết thúc</param>
		/// <returns>Danh sách DienNangTieuThu</returns>
		public List<DienNangTieuThu> AddNewDNTTFromKH(string MaQuanLy, DateTime NgayBD, DateTime NgayKT)
		{
			List<KhachHang> listKH = KhachHang.GetAll();
			List<DienNangTieuThu> listDNTT = new List<DienNangTieuThu>();
			foreach (KhachHang khach in listKH)
			{
				DienNangTieuThu dienNangTieuThu = new DienNangTieuThu()
				{
					MaKhachHang = khach.MaKhachHang,
					HoVaTen = khach.HoVaTen,
					DiaChi = khach.DiaChi,
					MaTram = khach.MaTram,
					MaChiTietBangGia = khach.MaChiTietBangGia,
					NgayGhi = DateTime.Now,
					NguoiGhi = MaQuanLy,
					NgayBatDau = NgayBD,
					NgayKetThuc = NgayKT,
					NgayCapNhat = DateTime.Now,
					NguoiCapNhat = MaQuanLy,
					NgayHoaDon = null,
					NgayTraTien = null,
					ChiSoMoi = 0,
					ChiSoCu = 0,
					TongTienTruocVAT = 0,
					TongTienSauVAT = 0,
					DaTra = 0,
					ConLai = 0
				};
				listDNTT.Add(dienNangTieuThu);
			}
			return listDNTT;
		}

		/// <summary>
		/// Chuyển DataTable sang danh sách, dùng cho chức năng cập nhật. Nếu ngày trong DataTable trống thì sẽ lấy ngày hiện tại
		/// </summary>
		/// <param name="dt">DataTable</param>
		/// <returns>Null hoặc Danh sách DienNangTieuThu</returns>
		public List<DienNangTieuThu> ConvertDataTableToListForUpdating(DataTable dt)
		{
			List<DienNangTieuThu> list = new List<DienNangTieuThu>();
			try
			{
				foreach (DataRow row in dt.Rows)
				{
					DienNangTieuThu dienNangTieuThu = new DienNangTieuThu()
					{
						ID = int.Parse(row["ID"].ToString()),
						MaKhachHang = row["MaKhachHang"].ToString(),
						HoVaTen = row["HoVaTen"].ToString(),
						DiaChi = row["DiaChi"].ToString(),
						MaChiTietBangGia = row["MaChiTietBangGia"].ToString(),
						MaTram = row["MaTram"].ToString(),
						NgayGhi = string.IsNullOrWhiteSpace(row["NgayGhi"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayGhi"].ToString()),
						NguoiGhi = row["NguoiGhi"].ToString(),
						NgayBatDau = string.IsNullOrWhiteSpace(row["NgayBatDau"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayBatDau"].ToString()),
						NgayKetThuc = string.IsNullOrWhiteSpace(row["NgayKetThuc"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayKetThuc"].ToString()),
						NgayCapNhat = string.IsNullOrWhiteSpace(row["NgayCapNhat"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayCapNhat"].ToString()),
						NguoiCapNhat = row["NguoiCapNhat"].ToString(),
						NgayHoaDon = string.IsNullOrWhiteSpace(row["NgayHoaDon"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayHoaDon"].ToString()),
						NgayTraTien = string.IsNullOrWhiteSpace(row["NgayTraTien"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayTraTien"].ToString()),
						ChiSoMoi = int.Parse(row["ChiSoMoi"].ToString()),
						ChiSoCu = int.Parse(row["ChiSoCu"].ToString()),
						TongTienTruocVAT = int.Parse(row["TongTienTruocVAT"].ToString()),
						TongTienSauVAT = int.Parse(row["TongTienSauVAT"].ToString()),
						DaTra = int.Parse(row["DaTra"].ToString()),
						ConLai = int.Parse(row["ConLai"].ToString())
					};
					list.Add(dienNangTieuThu);
				}
			}
			catch (Exception)
			{
				return null;
			}
			return list;
		}

		/// <summary>
		/// Đưa danh sách DienNangTieuThu sang DataTable vì CrystalReport đọc dữ liệu bằng DataSet
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public DataTable ConvertListToDataTableForReporting(List<DienNangTieuThu> list)
		{
			DataTable dt = new DataTable();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(DienNangTieuThu));
			foreach (PropertyDescriptor property in properties)
			{
				dt.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
			}
			foreach (DienNangTieuThu dienNangTieuThu in list)
			{
				object[] values = new object[properties.Count];
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = properties[i].GetValue(dienNangTieuThu);
				}
				dt.Rows.Add(values);
			}
			return dt;
		}

		/// <summary>
		/// Thử chèn danh sách DienNangTieuThu vào CSDL
		/// </summary>
		/// <param name="list">Danh sách DienNangTieuThu</param>
		/// <returns>Thành công hay không</returns>
		public bool TryInsertingListToSQL(List<DienNangTieuThu> list)
		{
			foreach (DienNangTieuThu dienNangTieuThu in list)
			{
				if (!DienNangTieuThu.TryInserting(dienNangTieuThu))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Thử cập nhật danh sách DienNangTieuThu vào CSDL
		/// </summary>
		/// <param name="list">Danh sách DienNangTieuThu</param>
		/// <returns>Thành công hay không</returns>
		public bool TryUpdatingListToSQL(List<DienNangTieuThu> list)
		{
			foreach (DienNangTieuThu dienNangTieuThu in list)
			{
				if (!DienNangTieuThu.TryUpdating(dienNangTieuThu))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Chèn danh sách vào bảng DienNangTieuThu
		/// </summary>
		/// <param name="list">Danh sách DienNangTieuThu</param>
		public void InsertSQL(List<DienNangTieuThu> list)
		{
			foreach (DienNangTieuThu dienNangTieuThu in list)
			{
				DienNangTieuThu.Insert(dienNangTieuThu);
			}
		}

		/// <summary>
		/// Cập nhật danh sách vào bảng DienNangTieuThu
		/// </summary>
		/// <param name="list">Danh sách DienNangTieuThu</param>
		public void UpdateSQL(List<DienNangTieuThu> list)
		{
			foreach (DienNangTieuThu dienNangTieuThu in list)
			{
				DienNangTieuThu.Update(dienNangTieuThu);
			}
		}

		/// <summary>
		/// Cập nhật lại danh sách một số trường liên quan
		/// </summary>
		/// <param name="list">Danh sách DienNangTieuThu</param>
		/// <param name="maQL">Mã của người quản lý</param>
		/// <returns>Danh sách DienNangTieuThu</returns>
		public List<DienNangTieuThu> UpdateListForUpdating(List<DienNangTieuThu> list, string maQL)
		{
			foreach (DienNangTieuThu dienNangTieuThu in list)
			{
				dienNangTieuThu.NgayCapNhat = DateTime.Now;
				dienNangTieuThu.NguoiCapNhat = maQL;
			}
			return list;
		}
	}
}
