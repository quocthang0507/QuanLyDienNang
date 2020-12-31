using Business.Classes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
	public class Excel
	{
		/// <summary>
		/// Xuất dữ liệu sang Excel, dữ liệu trả về ở dạng mảng bytes
		/// </summary>
		/// <param name="list"></param>
		/// <param name="sheetname"></param>
		/// <returns></returns>
		public static byte[] ExportToExcel(object objectList, string sheetname = "Danh sách khách hàng")
		{
			dynamic list = null;
			if (objectList is List<KhachHang>)
				list = objectList as List<KhachHang>;
			else if (objectList is List<DienNangTieuThu>)
				list = objectList as List<DienNangTieuThu>;
			try
			{
				ExcelPackage excel = new ExcelPackage();
				var sheet = excel.Workbook.Worksheets.Add(sheetname);
				Type type = list.GetType().GetGenericArguments()[0];
				PropertyInfo[] properties = type.GetProperties();
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

	}
}
