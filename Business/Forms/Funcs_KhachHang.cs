using Business.Classes;
using Business.Helper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

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
		/// Lấy đường dẫn Excel đã lưu trước đó
		/// </summary>
		/// <returns>Đường dẫn tập tin</returns>
		public string GetSavedExcelPathForImporting()
		{
			return Configuration.Instance.Read(KEY_EXCELFILE_INSERT_INI, SECTION_IMPORT_INSERT_INI);
		}

		/// <summary>
		/// Lưu đường dẫn Excel
		/// </summary>
		/// <param name="path">Đường dẫn tập tin</param>
		public void SaveExcelPathForImporting(string path)
		{
			Configuration.Instance.Write(KEY_EXCELFILE_INSERT_INI, path, SECTION_IMPORT_INSERT_INI);
		}

		/// <summary>
		/// Lấy tên các sheet trong tập tin Excel
		/// </summary>
		/// <param name="excelFilePath">Đường dẫn tập tin Excel</param>
		/// <returns>Null hoặc danh sách tên</returns>
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
		/// Đổi DataTable sang List dùng cho chức năng thêm khách hàng
		/// </summary>
		/// <param name="dt">Dữ liệu trong DataTable</param>
		/// <returns>Null hoặc Danh sách khách hàng</returns>
		public List<KhachHang> ConvertDataTableToListForInserting(DataTable dt)
		{
			List<KhachHang> list = new List<KhachHang>();
			try
			{
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
			}
			catch (Exception)
			{
				return null;
			}
			return list;
		}

		/// <summary>
		/// Cập nhật lại thông tin danh sách khách hàng dùng cho chức năng thêm khách hàng
		/// </summary>
		/// <param name="list">Danh sách khách hàng</param>
		/// <param name="maQL">Mã của người quản lý</param>
		/// <returns>Danh sách khách hàng</returns>
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
		/// <param name="dt">Dữ liệu trong DataTable</param>
		/// <returns>Null hoặc Danh sách khách hàng</returns>
		public List<KhachHang> ConvertDataTableToListForUpdating(DataTable dt)
		{
			List<KhachHang> list = new List<KhachHang>();
			try
			{
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
			}
			catch (Exception)
			{
				return null;
			}
			return list;
		}

		/// <summary>
		/// Cập nhật lại thông tin danh sách khách hàng dùng cho chức năng cập nhật khách hàng
		/// </summary>
		/// <param name="list">Danh sách khách hàng</param>
		/// <param name="maQL">Mã của người quản lý</param>
		/// <returns>Danh sách khách hàng</returns>
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
		/// <param name="excelFilePath">Đường dẫn đến tập tin Excel</param>
		/// <param name="sheetname">Tên sheet chứa dữ liệu</param>
		/// <returns>Null hoặc Danh sách khách hàng</returns>
		public List<KhachHang> ReadExcelForInserting(string excelFilePath, string sheetname)
		{
			DataTable dt = Excel.ReadExcelAsDataTable(excelFilePath, sheetname);
			if (dt == null)
				return null;
			else
				return ConvertDataTableToListForInserting(dt);
		}

		/// <summary>
		/// Đọc Excel và trả về danh sách khách hàng, dùng cho chức năng cập nhật khách hàng
		/// </summary>
		/// <param name="excelFilePath">Đường dẫn đến tập tin Excel</param>
		/// <param name="sheetname">Tên sheet chứa dữ liệu</param>
		/// <returns>Null hoặc Danh sách khách hàng</returns>
		public List<KhachHang> ReadExcelForUpdating(string excelFilePath, string sheetname)
		{
			DataTable dt = Excel.ReadExcelAsDataTable(excelFilePath, sheetname);
			if (dt == null)
				return null;
			else
				return ConvertDataTableToListForUpdating(dt);
		}

		/// <summary>
		/// Thử thêm dữ liệu khách hàng vào SQL
		/// </summary>
		/// <param name="list">Danh sách khách hàng</param>
		/// <returns>Thành công hay không</returns>
		public bool TryInsertingDataTableToSQL(List<KhachHang> list)
		{
			foreach (var khach in list)
			{
				if (KhachHang.TryInserting(khach))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Thử cập nhật dữ liệu vào SQL
		/// </summary>
		/// <param name="list">Danh sách khách hàng</param>
		/// <returns>Thành công hay không</returns>
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
		/// <param name="list">Danh sách khách hàng</param>
		public void InsertSQL(List<KhachHang> list)
		{
			foreach (var khach in list)
			{
				KhachHang.Insert(khach);
			}
		}

		/// <summary>
		/// Cập nhật danh sách khách hàng vào SQL
		/// </summary>
		/// <param name="list">Danh sách khách hàng</param>
		public void UpdateSQL(List<KhachHang> list)
		{
			foreach (var khach in list)
			{
				KhachHang.Update(khach);
			}
		}
	}
}