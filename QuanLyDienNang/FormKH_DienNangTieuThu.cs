using System.Windows.Forms;
using ThuVien.Classes;

namespace QuanLyDienNang
{
	public partial class FormKH_DienNangTieuThu : Form
	{
		public FormKH_DienNangTieuThu()
		{
			InitializeComponent();
		}

		private void FormKH_DienNangTieuThu_Load(object sender, System.EventArgs e)
		{
			dgvDienNangTieuThu.DataSource = DienNangTieuThu.LoadTable();
		}
	}
}
