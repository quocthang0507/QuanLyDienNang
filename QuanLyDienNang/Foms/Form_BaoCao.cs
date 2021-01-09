using System.Data;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_BaoCao : Form
	{
		private DataTable dt;

		public Form_BaoCao()
		{
			InitializeComponent();
		}

		public Form_BaoCao(DataTable dt)
		{
			InitializeComponent();
			this.dt = dt;
		}

		private void Form_BaoCao_Load(object sender, System.EventArgs e)
		{
			if (dt != null)
			{
				hoaDonTienDien.SetDataSource(dt);
				crystalViewer.ReportSource = hoaDonTienDien;
				crystalViewer.Refresh();
			}
		}
	}
}
