using ExcelDataReader;
using QuanLyDienNang.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_NhapKhachHang : Form
	{
		private DataTableCollection table;

		public FormKH_NhapKhachHang()
		{
			InitializeComponent();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog open = new OpenFileDialog() { Filter = "Excel 97-2003 workbook|*.xls|Excel workbook|*.xlsx" })
			{
				if (open.ShowDialog() == DialogResult.OK)
				{
					tbxDuongDan.Text = open.FileName;
					using (var ex = File.Open(open.FileName, FileMode.Open, FileAccess.Read))
					{
						using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(ex))
						{
							DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
							{
								ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
							});
							table = result.Tables;
							cbxSheet.Items.Clear();
							foreach (DataTable table in table)
								cbxSheet.Items.Add(table.TableName);
							cbxSheet.SelectedIndex = 0;
						}

					}
				}
			}
		}

		private void FormKH_NhapKhachHang_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (true)
			{

			}
		}

	}
}
