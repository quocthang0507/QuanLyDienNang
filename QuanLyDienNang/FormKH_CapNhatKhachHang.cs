using Business.Classes;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_CapNhatKhachHang : Form
	{
		private Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public FormKH_CapNhatKhachHang()
		{
			InitializeComponent();
		}
	}
}
