using Business.Helper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Business.Classes
{
	public class Funcs_NhapKhachHang
	{
		private readonly string SECTION_IMPORT_INI = "NhapDienNangTieuThu";
		private readonly string KEY_EXCELFILE_INI = "DuongDanTapTin";


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
				return sheets;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi đọc dữ liệu từ tập tin Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
						return dt;
					}
				}
				return null;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi đọc dữ liệu từ tập tin Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public void TryToInsertDataTableToSQL(BindingSource binding)
		{
			var list = binding.DataSource as List<KhachHang>;
			foreach (var khach in list)
			{

			}
		}
	}
}
