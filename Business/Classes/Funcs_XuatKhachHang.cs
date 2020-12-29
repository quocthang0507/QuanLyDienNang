using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Business.Classes
{
	public class Funcs_XuatKhachHang
	{
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
				for (int col = 1; col <= properties.Length; col++)
				{
					var prop = properties[col - 1];
					sheet.Cells[1, col].Value = prop.Name;
					for (int row = 1; row <= list.Count; row++)
					{
						var khach = list[row - 1];
						var value = prop.GetValue(khach);
						sheet.Cells[row + 1, col].Value = value;
					}
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
	}
}
