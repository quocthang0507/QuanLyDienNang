using Business.Helper;
using DataAccess;
using System;
using System.Data;
using System.Windows.Forms;

namespace Business.Classes
{
	public class Funcs_DienNangTieuThu
	{
		private readonly string SECTION_INI = "DocChiSoDien";
		private readonly string KEY_IMAGEFOLDER_INI = "DuongDanThuMuc";

		public DataTable LoadTable()
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

		public string GetSavedLocation()
		{
			return Configuration.Instance.Read(KEY_IMAGEFOLDER_INI, SECTION_INI);
		}

		public void WriteLocation(string path)
		{
			Configuration.Instance.Write(KEY_IMAGEFOLDER_INI, path, SECTION_INI);
		}
	}
}
