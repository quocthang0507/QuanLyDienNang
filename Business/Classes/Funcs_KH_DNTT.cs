using Business.Helper;
using DataAccess;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Business.Classes
{
	public class Funcs_KH_DNTT
	{
		private readonly string SECTION_OCR_INI = "DocChiSoDien";
		private readonly string KEY_IMAGEFOLDER_INI = "DuongDanThuMuc";
		private readonly string SECTION_IMPORT_INI = "NhapDienNangTieuThu";
		private readonly string KEY_EXCELFILE_INI = "DuongDanTapTin";

		public DataTable LoadTable_NguoiQuanLy()
		{
			try
			{
				var dt = new DataTable();
				var reader = DataProvider.Instance.ExecuteReader("proc_GetAll_NguoiQuanLy");
				dt.Load(reader);
				return dt;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public string GetSavedImageFolderPath()
		{
			return Configuration.Instance.Read(KEY_IMAGEFOLDER_INI, SECTION_OCR_INI);
		}

		public string GetSavedExcelPath()
		{
			return Configuration.Instance.Read(KEY_EXCELFILE_INI, SECTION_IMPORT_INI);
		}

		public void Save_ImageFolderPath(string path)
		{
			Configuration.Instance.Write(KEY_IMAGEFOLDER_INI, path, SECTION_OCR_INI);
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
						int startRow = 2;
						// Lấy nội dung
						for (int rowNum = startRow; rowNum <= sheet.Dimension.End.Row; rowNum++)
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

	}
}
