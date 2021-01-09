using Business.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_ChiTietBangGia : Form
	{
		private BangGia bangGia;

		public Form_ChiTietBangGia()
		{
			InitializeComponent();
		}

		public Form_ChiTietBangGia(BangGia bangGia)
		{
			InitializeComponent();
			this.bangGia = bangGia;
		}
	}
}
