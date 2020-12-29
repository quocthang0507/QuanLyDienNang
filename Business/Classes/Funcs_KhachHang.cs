using Business.Helper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Business.Classes
{
	public class Funcs_KhachHang
	{
		private readonly string SECTION_IMPORT_INI = "NhapDienNangTieuThu";
		private readonly string KEY_EXCELFILE_INI = "DuongDanTapTin";

		public List<KhachHang> FilterTable(string diaChi, string maBangGia, string maTram, string tenNganHang)
		{
			List<KhachHang> list = KhachHang.All();
			if (!string.IsNullOrWhiteSpace(diaChi))
				list = list.Where(khach => khach.DiaChi.Contains(diaChi)).ToList();
			if (!string.IsNullOrWhiteSpace(maBangGia))
				list = list.Where(khach => khach.MaBangGia.Equals(maBangGia)).ToList();
			if (!string.IsNullOrWhiteSpace(maTram))
				list = list.Where(khach => khach.MaTram.Equals(maTram)).ToList();
			if (!string.IsNullOrWhiteSpace(tenNganHang))
				list = list.Where(khach => khach.TenNganHang.Contains(tenNganHang)).ToList();
			return list;
		}

		public byte[] ExportToExcel(List<KhachHang> list)
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

		public string GetSavedExcelPath()
		{
			return Configuration.Instance.Read(KEY_EXCELFILE_INI, SECTION_IMPORT_INI);
		}

		public void Save_ExcelFilePath(string path)
		{
			Configuration.Instance.Write(KEY_EXCELFILE_INI, path, SECTION_IMPORT_INI);
		}

		public List<string> GetSheetNamesOnExcel(string excelFilePath)
		{
			try
			{
				ExcelPackage excel = new ExcelPackage(new FileInfo(excelFilePath));
				List<string> sheets = new List<string>();
				foreach (var sheet in excel.Workbook.Worksheets)
				{
					sheets.Add(sheet.Name);
				}
				excel.Dispose();
				return sheets;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDataTableFromExcel(string excelFilePath, string sheetname)
		{
			try
			{
				ExcelPackage excel = new ExcelPackage(new FileInfo(excelFilePath));
				foreach (var sheet in excel.Workbook.Worksheets)
				{
					// Chọn đúng sheet
					if (sheet.Name.Equals(sheetname, StringComparison.OrdinalIgnoreCase))
					{
						DataTable dt = new DataTable();
						// Lấy tiêu đề cột
						foreach (var firstRowCell in sheet.Cells[1, 1, 1, sheet.Dimension.End.Column])
						{
							dt.Columns.Add(firstRowCell.Text);
						}
						// Lấy nội dung từ dòng thứ hai
						for (int rowNum = 2; rowNum <= sheet.Dimension.End.Row; rowNum++)
						{
							var row = sheet.Cells[rowNum, 1, rowNum, sheet.Dimension.End.Column];
							DataRow dr = dt.Rows.Add();
							foreach (var cell in row)
							{
								dr[cell.Start.Column - 1] = cell.Text;
							}
						}
						excel.Dispose();
						return dt;
					}
				}
				excel.Dispose();
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<KhachHang> ConvertDataTableToListKhachHang(DataTable dt, string MaQuanLy)
		{
			List<KhachHang> list = new List<KhachHang>();
			foreach (DataRow row in dt.Rows)
			{
				KhachHang khachHang = new KhachHang()
				{
					MaKhachHang = null,
					HoVaTen = row["HoVaTen"].ToString(),
					DiaChi = row["DiaChi"].ToString(),
					MaBangGia = row["MaBangGia"].ToString(),
					MaTram = row["MaTram"].ToString(),
					SoHo = byte.Parse(row["SoHo"].ToString()),
					HeSoNhan = byte.Parse(row["HeSoNhan"].ToString()),
					MaSoThue = row["MaSoThue"].ToString(),
					SoDienThoai = row["SoDienThoai"].ToString(),
					Email = row["Email"].ToString(),
					NgayTao = DateTime.Now,
					NguoiTao = MaQuanLy,
					NgayCapNhat = DateTime.Now,
					NguoiCapNhat = MaQuanLy,
					MaSoHopDong = row["MaSoHopDong"].ToString(),
					NgayHopDong = string.IsNullOrWhiteSpace(row["NgayHopDong"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayHopDong"].ToString()),
					MaCongTo = row["MaCongTo"].ToString(),
					SoNganHang = row["SoNganHang"].ToString(),
					TenNganHang = row["TenNganHang"].ToString()
				};
				list.Add(khachHang);
			}
			return list;
		}

		public List<KhachHang> GetListKhachHangFromExcel(string excelFilePath, string sheetname, string MaQuanLy)
		{
			DataTable dt = GetDataTableFromExcel(excelFilePath, sheetname);
			return ConvertDataTableToListKhachHang(dt, MaQuanLy);
		}

		public bool TryAddingDataTableToSQL(List<KhachHang> list)
		{
			foreach (var khach in list)
			{
				bool ok = KhachHang.TryAdding(khach);
				if (!ok)
					return false;
			}
			return true;
		}

		public bool AddDataTableToSQL(List<KhachHang> list)
		{
			try
			{
				foreach (var khach in list)
				{
					KhachHang.Add(khach);
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

	}
}