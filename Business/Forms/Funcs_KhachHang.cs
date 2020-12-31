using Business.Classes;
using Business.Helper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Business.Forms
{
	/// <summary>
	/// Lớp chức năng cho ba forms: nhập, cập nhật và xuất danh sách khách hàng
	/// </summary>
	public class Funcs_KhachHang
	{
		private readonly string SECTION_IMPORT_INSERT_INI = "NhapKhachHang";
		private readonly string KEY_EXCELFILE_INSERT_INI = "DuongDanTapTin";

		/// <summary>
		/// Xuất dữ liệu sang Excel, dữ liệu trả về ở dạng mảng bytes
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Lấy đường dẫn Excel đã lưu trước đó
		/// </summary>
		/// <returns></returns>
		public string GetSavedExcelPathForImporting()
		{
			return Configuration.Instance.Read(KEY_EXCELFILE_INSERT_INI, SECTION_IMPORT_INSERT_INI);
		}

		/// <summary>
		/// Lưu đường dẫn Excel
		/// </summary>
		/// <param name="path"></param>
		public void SaveExcelPathForImporting(string path)
		{
			Configuration.Instance.Write(KEY_EXCELFILE_INSERT_INI, path, SECTION_IMPORT_INSERT_INI);
		}

		/// <summary>
		/// Lấy tên các sheet trong tập tin Excel
		/// </summary>
		/// <param name="excelFilePath"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Đọc tập tin Excel dưới dạng DataTable
		/// </summary>
		/// <param name="excelFilePath"></param>
		/// <param name="sheetname"></param>
		/// <returns></returns>
		public DataTable ReadExcelAsDataTable(string excelFilePath, string sheetname)
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

		/// <summary>
		/// Đổi DataTable sang List dùng cho chức năng thêm khách hàng
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public List<KhachHang> ConvertDataTableToListForInserting(DataTable dt)
		{
			List<KhachHang> list = new List<KhachHang>();
			foreach (DataRow row in dt.Rows)
			{
				KhachHang khachHang = new KhachHang()
				{
					HoVaTen = row["HoVaTen"].ToString(),
					DiaChi = row["DiaChi"].ToString(),
					MaBangGia = row["MaBangGia"].ToString(),
					MaTram = row["MaTram"].ToString(),
					SoHo = byte.Parse(row["SoHo"].ToString()),
					HeSoNhan = byte.Parse(row["HeSoNhan"].ToString()),
					MaSoThue = row["MaSoThue"].ToString(),
					SoDienThoai = row["SoDienThoai"].ToString(),
					Email = row["Email"].ToString(),
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

		/// <summary>
		/// Cập nhật lại thông tin danh sách khách hàng dùng cho chức năng thêm khách hàng
		/// </summary>
		/// <param name="list"></param>
		/// <param name="maQL"></param>
		/// <returns></returns>
		public List<KhachHang> UpdateListForInserting(List<KhachHang> list, string maQL)
		{
			foreach (var khach in list)
			{
				khach.NgayTao = DateTime.Now;
				khach.NguoiTao = maQL;
				khach.NgayCapNhat = DateTime.Now;
				khach.NguoiCapNhat = maQL;
			}
			return list;
		}

		/// <summary>
		/// Đổi DataTable sang List dùng cho chức năng cập nhật khách hàng
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public List<KhachHang> ConvertDataTableToListForUpdating(DataTable dt)
		{
			List<KhachHang> list = new List<KhachHang>();
			foreach (DataRow row in dt.Rows)
			{
				KhachHang khachHang = new KhachHang()
				{
					MaKhachHang = row["MaKhachHang"].ToString(),
					HoVaTen = row["HoVaTen"].ToString(),
					DiaChi = row["DiaChi"].ToString(),
					MaBangGia = row["MaBangGia"].ToString(),
					MaTram = row["MaTram"].ToString(),
					SoHo = byte.Parse(row["SoHo"].ToString()),
					HeSoNhan = byte.Parse(row["HeSoNhan"].ToString()),
					MaSoThue = row["MaSoThue"].ToString(),
					SoDienThoai = row["SoDienThoai"].ToString(),
					Email = row["Email"].ToString(),
					NgayTao = string.IsNullOrWhiteSpace(row["NgayTao"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayTao"].ToString()),
					NguoiTao = row["NguoiTao"].ToString(),
					NgayCapNhat = string.IsNullOrWhiteSpace(row["NgayCapNhat"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayCapNhat"].ToString()),
					NguoiCapNhat = row["NguoiCapNhat"].ToString(),
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

		/// <summary>
		/// Cập nhật lại thông tin danh sách khách hàng dùng cho chức năng cập nhật khách hàng
		/// </summary>
		/// <param name="list"></param>
		/// <param name="maQL"></param>
		/// <returns></returns>
		public List<KhachHang> UpdateListForUpdating(List<KhachHang> list, string maQL)
		{
			foreach (var khach in list)
			{
				khach.NgayCapNhat = DateTime.Now;
				khach.NguoiCapNhat = maQL;
			}
			return list;
		}

		/// <summary>
		/// Đọc Excel và trả về danh sách khách hàng, dùng cho chức năng thêm khách hàng
		/// </summary>
		/// <param name="excelFilePath"></param>
		/// <param name="sheetname"></param>
		/// <returns></returns>
		public List<KhachHang> ReadExcelForInserting(string excelFilePath, string sheetname)
		{
			DataTable dt = ReadExcelAsDataTable(excelFilePath, sheetname);
			return ConvertDataTableToListForInserting(dt);
		}

		/// <summary>
		/// Đọc Excel và trả về danh sách khách hàng, dùng cho chức năng cập nhật khách hàng
		/// </summary>
		/// <param name="excelFilePath"></param>
		/// <param name="sheetname"></param>
		/// <returns></returns>
		public List<KhachHang> ReadExcelForUpdating(string excelFilePath, string sheetname)
		{
			DataTable dt = ReadExcelAsDataTable(excelFilePath, sheetname);
			return ConvertDataTableToListForUpdating(dt);
		}

		/// <summary>
		/// Thử thêm dữ liệu khách hàng vào SQL
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public bool TryInsertingDataTableToSQL(List<KhachHang> list)
		{
			foreach (var khach in list)
			{
				bool ok = KhachHang.TryInserting(khach);
				if (!ok)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Thử cập nhật dữ liệu vào SQL
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public bool TryUpdatingDataTableToSQL(List<KhachHang> list)
		{
			foreach (var khach in list)
			{
				bool ok = KhachHang.TryUpdating(khach);
				if (!ok)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Thêm danh sách khách hàng vào SQL
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public void InsertSQL(List<KhachHang> list)
		{
			try
			{
				foreach (var khach in list)
				{
					KhachHang.Insert(khach);
				}
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// Cập nhật danh sách khách hàng vào SQL
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public void UpdateSQL(List<KhachHang> list)
		{
			try
			{
				foreach (var khach in list)
				{
					KhachHang.Update(khach);
				}
			}
			catch (Exception)
			{
			}
		}
	}
}