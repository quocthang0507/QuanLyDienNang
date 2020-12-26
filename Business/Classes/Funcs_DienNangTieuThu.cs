using Business.Helper;
using DataAccess;
using System;
using System.Data;
using System.Windows.Forms;

namespace Business.Classes
{
	public class Funcs_DienNangTieuThu
	{
		private readonly string SECTION_OCR_INI = "DocChiSoDien";
		private readonly string KEY_IMAGEFOLDER_INI = "DuongDanThuMuc";
		private readonly string SECTION_IMPORT_INI = "NhapDienNangTieuThu";
		private readonly string KEY_EXCELFILE_INI = "DuongDanTapTin";


		public DataTable LoadTable_DienNangTieuThu()
		{
			try
			{
				var dt = new DataTable();
				var reader = DataProvider.Instance.ExecuteReader("proc_GetAll_DienNangTieuThu");
				dt.Load(reader);
				return dt;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

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
	}
}
