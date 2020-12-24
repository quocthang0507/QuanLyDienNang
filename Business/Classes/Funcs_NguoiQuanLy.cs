using DataAccess;
using System;
using System.Data;
using System.Windows.Forms;

namespace Business.Classes
{
	public class Funcs_NguoiQuanLy
	{
		public DataTable LoadTable()
		{
			try
			{
				var dt = new DataTable();
				var reader = DataProvider.Instance.ExecuteReader("SELECT * FROM NguoiQuanLy");
				dt.Load(reader);
				return dt;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

	}
}
