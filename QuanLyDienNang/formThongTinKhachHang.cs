using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLyDienNang
{
	public partial class formThongTinKhachHang : Form
	{
		private readonly int i;
		private readonly string ma_kh;
		readonly SqlConnection con = new SqlConnection(@"Data Source=THUANNHU-PC\SQLEXPRESS;Initial Catalog=quanlydien_sql;Integrated Security=True");

		public formThongTinKhachHang()
		{
			InitializeComponent();

		}
		public formThongTinKhachHang(string makh)
		{
			InitializeComponent();
			this.ma_kh = makh;
			tb_mkh.Text = ma_kh;
			btn_luu.Enabled = false;
			load_texbox();

		}
		private void load_texbox()       // load dữ liệu vào textbox
		{
			con.Open();
			SqlCommand da = new SqlCommand("select * from quanlykhachhang where ma_kh = @ma_kh", con);
			da.Parameters.AddWithValue("@ma_kh", tb_mkh.Text);
			SqlDataReader db = da.ExecuteReader();
			while (db.Read())
			{
				tb_tenkh.Text = db.GetValue(2).ToString();
				tb_dc.Text = db.GetValue(3).ToString();
				cb_tentram.Text = db.GetValue(4).ToString();
				tb_soho.Text = db.GetValue(5).ToString();
				tb_mst.Text = db.GetValue(7).ToString();
				tb_sodt.Text = db.GetValue(8).ToString();
				tb_zalo.Text = db.GetValue(9).ToString();
				tb_email.Text = db.GetValue(10).ToString();
				tb_sohopdong.Text = db.GetValue(11).ToString();
				tb_csd.Text = db.GetValue(13).ToString();
				cb_banggia.Text = db.GetValue(6).ToString();
				tb_socongto.Text = db.GetValue(12).ToString();

			}
			con.Close();


		}
		public formThongTinKhachHang(int i)
		{
			this.i = i;
			InitializeComponent();
			btn_luu.Enabled = true;
			btn_thoat.Enabled = true;
			btn_huy.Enabled = true;
			buttonX1.Enabled = false;

		}

		private void btn_thoat_Click(object sender, EventArgs e)
		{

			this.Close();
		}  // Thoát trang
		private void btn_luu_Click(object sender, EventArgs e)
		{
			if (tb_tenkh.Text == "")
			{
				MessageBox.Show("Hãy Nhập Tên Khách Hàng");
				tb_tenkh.Focus();
			}
			else

			   if (tb_dc.Text == "")
			{
				MessageBox.Show("Hãy nhập địa chỉ khách hàng");
				tb_dc.Focus();
			}
			else
					if (cb_tentram.Text == "")
			{
				MessageBox.Show("Hãy Chọn Tên Trạm");
				cb_tentram.Focus();
			}
			else
					if (tb_soho.Text == "")
			{
				MessageBox.Show("Hãy Nhập Số Hộ");
				tb_soho.Focus();
			}
			else
						 if (cb_banggia.Text == "")
			{
				MessageBox.Show("Hãy Chọn Bảng Giá Sử Dụng");
				cb_banggia.Focus();
			}

			else
			{


				try
				{
					string sql = "insert into khachhang(ten_kh,diachi,tentram,so_ho,banggia,masothue,so_dt,so_zalo,email,so_hopdong,socongto,chisodau) values (N'" + tb_tenkh.Text + "',N'" + tb_dc.Text + "','" + cb_tentram.Text + "','" + tb_soho.Text + "','" + cb_banggia.Text + "','" + tb_mst.Text + "','" + tb_sodt.Text + "','" + tb_zalo.Text + "','" + tb_email.Text + "','" + tb_sohopdong.Text + "','" + tb_socongto.Text + "','" + tb_csd.Text + "') ";
					Functions.RunSQL(sql);
					sql = "SELECT * FROM dbo.khachhang WHERE sott=(SELECT max(sott) FROM dbo.khachhang)";
					Functions.GetDataToTable(sql);
					sql = "INSERT INTO quanlykhachhang(sott,ma_kh,ten_kh,diachi,tentram,so_ho,banggia,masothue,so_dt,so_zalo,email,so_hopdong,socongto,chisodau,chisocuoi,dien_tt,thanhtien,thue,tongtien,no,thang) SELECT sott,ma_kh,ten_kh,diachi,tentram,so_ho,banggia,masothue,so_dt,so_zalo,email,so_hopdong,socongto,chisodau,chisocuoi,dien_tt,thanhtien,thue,tongtien,no,thang FROM khachhang WHERE sott=(SELECT max(sott) FROM dbo.khachhang)";
					Functions.RunSQL(sql);
					MessageBox.Show("thành công");
				}
				catch
				{
					MessageBox.Show("Lỗi Thêm Mới");
				}
			}
		}   // save thêm mới

		private void ThongTinKhachHang_Load(object sender, EventArgs e)
		{
			this.quanlykhachhangTableAdapter.Fill(this.quanlydien_sqlDataSet2.quanlykhachhang);
		}

		private void fillByToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.quanlykhachhangTableAdapter.FillBy(this.quanlydien_sqlDataSet2.quanlykhachhang);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}

		private void btn_huy_Click(object sender, EventArgs e)
		{
			tb_tenkh.Text = "";
			tb_dc.Text = "";
			tb_soho.Text = "";
			tb_email.Text = "";
			tb_mst.Text = "";
			tb_socongto.Text = "";
			tb_sodt.Text = "";
			tb_soho.Text = "";
			tb_sohopdong.Text = "";
			tb_zalo.Text = "";
			cb_banggia.Text = "";
			cb_tentram.Text = "";
			load_texbox();
		}

		private void buttonX1_Click(object sender, EventArgs e)
		{
			string Sql = "update quanlykhachhang set ten_kh =N'" + tb_tenkh.Text + "',diachi= N'" + tb_dc.Text + "',tentram= N'" + cb_tentram.Text + "',so_ho= '" + tb_soho.Text + "',banggia= '" + cb_banggia.Text + "',masothue= '" + tb_mst.Text + "',so_dt= '" + tb_sodt.Text + "',so_zalo = '" + tb_zalo.Text + "',email= '" + tb_email.Text + "',so_hopdong= '" + tb_sohopdong.Text + "',socongto= '" + tb_socongto.Text + "',chisodau= '" + tb_csd.Text + "' where ma_kh = '" + tb_mkh.Text + "'";
			Functions.RunSQL(Sql);
			//     SqlDataAdapter da = new SqlDataAdapter(Sql, con);
			MessageBox.Show("Sửa Thành Công");
			load_texbox();

		}          //  lưu dữ liệu sửa

	}
}
