using Business.Classes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Business.Forms
{
	public class Funcs_DienNangTieuThu
	{
		public List<DienNangTieuThu> AddDienNangTieuThuFromKhachHang(string MaQuanLy, DateTime NgayBD, DateTime NgayKT)
		{
			List<KhachHang> listKH = KhachHang.GetAll();
			List<DienNangTieuThu> listDNTT = new List<DienNangTieuThu>();
			foreach (var khach in listKH)
			{
				DienNangTieuThu dienNangTieuThu = new DienNangTieuThu()
				{
					MaKhachHang = khach.MaKhachHang,
					TenKhachHang = khach.HoVaTen,
					DiaChi = khach.DiaChi,
					MaTram = khach.MaTram,
					MaBangGia = khach.MaBangGia,
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

		public bool TryInsertingListToSQL(List<DienNangTieuThu> list)
		{
			foreach (var dienNangTieuThu in list)
			{
				bool ok = DienNangTieuThu.TryInserting(dienNangTieuThu);
				if (!ok)
					return false;
			}
			return true;
		}

		public bool TryUpdatingListToSQL(List<DienNangTieuThu> list)
		{
			foreach (var dienNangTieuThu in list)
			{
				bool ok = DienNangTieuThu.TryUpdating(dienNangTieuThu);
				if (!ok)
					return false;
			}
			return true;
		}


		public byte[] ExportToExcel(List<DienNangTieuThu> list)
		{
			try
			{
				ExcelPackage excel = new ExcelPackage();
				var sheet = excel.Workbook.Worksheets.Add("Danh sach khach hang");
				PropertyInfo[] properties = typeof(KhachHang).GetProperties();
				// Thêm dữ liệu theo từng cột, tương ứng với tên từng thuộc tính
				for (int col = 1; col <= properties.Length; col++)
				{
					// Thêm tên cột
					var prop = properties[col - 1];
					sheet.Cells[1, col].Value = prop.Name;
					sheet.Cells[1, col].Style.Font.Bold = true;
					// Sửa lại định dạng ngày cho cột bắt đầu bằng chữ "Ngay"
					if (prop.Name.StartsWith("Ngay"))
						sheet.Column(col).Style.Numberformat.Format = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
					// Thêm dữ liệu cho các ô thuộc cột đó
					for (int row = 1; row <= list.Count; row++)
					{
						var khach = list[row - 1];
						var value = prop.GetValue(khach);
						sheet.Cells[row + 1, col].Value = value;
					}
					// Chỉnh lại độ rộng cột
					sheet.Column(col).AutoFit();
				}
				var bytes = excel.GetAsByteArray();
				excel.Dispose();
				return bytes;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public void InsertSQL(List<DienNangTieuThu> list)
		{
			try
			{
				foreach (var dienNangTieuThu in list)
				{
					DienNangTieuThu.Insert(dienNangTieuThu);
				}
			}
			catch (Exception)
			{
			}
		}

		public void UpdateSQL(List<DienNangTieuThu> list)
		{
			try
			{
				foreach (var dienNangTieuThu in list)
				{
					DienNangTieuThu.Update(dienNangTieuThu);
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
