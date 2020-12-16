using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class formNhapKhachHang : Form
	{
		private DataTableCollection tablecon;
		readonly SqlConnection con = new SqlConnection(@"Data Source=THUANNHU-PC\SQLEXPRESS;Initial Catalog=quanlydien_sql;Integrated Security=True");


		public formNhapKhachHang()
		{
			InitializeComponent();
		}

		private void btn_thoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_import_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog open = new OpenFileDialog() { Filter = "Excel 97-2003 workbook|*.xls|Excel workbook|*.xlsx" })
			{
				if (open.ShowDialog() == DialogResult.OK)
				{
					tb_duongdan.Text = open.FileName;
					using (var ex = File.Open(open.FileName, FileMode.Open, FileAccess.Read))
					{
						using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(ex))
						{
							DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
							{
								ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
							});
							tablecon = result.Tables;
							cb_sheet.Items.Clear();
							foreach (DataTable table in tablecon)
								cb_sheet.Items.Add(table.TableName);
							cb_sheet.SelectedIndex = 0;
						}

					}
				}



			}
		}  // mở File excel

		private void cb_sheet_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataTable dt = tablecon[cb_sheet.SelectedItem.ToString()];
			dtg.DataSource = dt;
			dtg.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
			dtg.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
		}   // chọn Sheet

		private void btn_Save_Click(object sender, EventArgs e)
		{
			con.Open();
			for (int j = 0; j < dtg.Rows.Count; j++)
			{
				SqlCommand cm = new SqlCommand("insert into khachhang(ten_kh,diachi,tentram,so_ho,banggia,masothue,so_dt,so_zalo,email,so_hopdong,socongto,chisodau,chisocuoi,dien_tt,thanhtien,thue,tongtien,no,thang) values (N'" + dtg.Rows[j].Cells[0].Value + "',N'" + dtg.Rows[j].Cells[1].Value + "',N'" + dtg.Rows[j].Cells[2].Value + "',N'" + dtg.Rows[j].Cells[3].Value + "',N'" +
					dtg.Rows[j].Cells[4].Value + "',N'" + dtg.Rows[j].Cells[5].Value + "',N'" + dtg.Rows[j].Cells[6].Value + "',N'" + dtg.Rows[j].Cells[7].Value + "',N'" + dtg.Rows[j].Cells[8].Value + "',N'" + dtg.Rows[j].Cells[9].Value + "',N'" + dtg.Rows[j].Cells[10].Value + "',N'" + dtg.Rows[j].Cells[11].Value + "',N'" + dtg.Rows[j].Cells[12].Value +
					"',N'" + dtg.Rows[j].Cells[13].Value + "',N'" + dtg.Rows[j].Cells[14].Value + "',N'" + dtg.Rows[j].Cells[15].Value + "',N'" + dtg.Rows[j].Cells[16].Value + "',N'" + dtg.Rows[j].Cells[17].Value + "',N'" + dateTimePicker1.Value.ToString("MM/yyyy") + "')", con);
				cm.ExecuteNonQuery();

			}
			SqlCommand cdf = new SqlCommand("INSERT INTO quanlykhachhang(sott,ma_kh,ten_kh,diachi,tentram,so_ho,banggia,masothue,so_dt,so_zalo,email,so_hopdong,socongto,chisodau,chisocuoi,dien_tt,thanhtien,thue,tongtien,no,thang) SELECT sott,ma_kh,ten_kh,diachi,tentram,so_ho,banggia,masothue,so_dt,so_zalo,email,so_hopdong,socongto,chisodau,chisocuoi,dien_tt,thanhtien,thue,tongtien,no,thang FROM khachhang", con);
			cdf.ExecuteNonQuery();
			MessageBox.Show("Thêm Khách Hàng Thành Công");
			con.Close();
		}
	}
}
