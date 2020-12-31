using Business.Classes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Business.Forms
{
	public class Funcs_DienNangTieuThu
	{
		public List<DienNangTieuThu> AddDienNangTieuThuFromKhachHang(string MaQuanLy, DateTime NgayBD, DateTime NgayKT)
		{
			List<KhachHang> listKH = KhachHang.GetAll();
			List<DienNangTieuThu> listDNTT = new List<DienNangTieuThu>();
			foreach (var khach in listKH)
			{
				DienNangTieuThu dienNangTieuThu = new DienNangTieuThu()
				{
					MaKhachHang = khach.MaKhachHang,
					TenKhachHang = khach.HoVaTen,
					DiaChi = khach.DiaChi,
					MaTram = khach.MaTram,
					MaBangGia = khach.MaBangGia,
					NgayGhi = DateTime.Now,
					NguoiGhi = MaQuanLy,
					NgayBatDau = NgayBD,
					NgayKetThuc = NgayKT,
					NgayCapNhat = DateTime.Now,
					NguoiCapNhat = MaQuanLy,
					NgayHoaDon = null,
					NgayTraTien = null,
					ChiSoMoi = 0,
					ChiSoCu = 0,
					TongTienTruocVAT = 0,
					TongTienSauVAT = 0,
					DaTra = 0,
					ConLai = 0
				};
				listDNTT.Add(dienNangTieuThu);
			}
			return listDNTT;
		}

		public bool TryInsertingListToSQL(List<DienNangTieuThu> list)
		{
			foreach (var dienNangTieuThu in list)
			{
				bool ok = DienNangTieuThu.TryInserting(dienNangTieuThu);
				if (!ok)
					return false;
			}
			return true;
		}

		public bool TryUpdatingListToSQL(List<DienNangTieuThu> list)
		{
			foreach (var dienNangTieuThu in list)
			{
				bool ok = DienNangTieuThu.TryUpdating(dienNangTieuThu);
				if (!ok)
					return false;
			}
			return true;
		}

		public void InsertSQL(List<DienNangTieuThu> list)
		{
			try
			{
				foreach (var dienNangTieuThu in list)
				{
					DienNangTieuThu.Insert(dienNangTieuThu);
				}
			}
			catch (Exception)
			{
			}
		}

		public void UpdateSQL(List<DienNangTieuThu> list)
		{
			try
			{
				foreach (var dienNangTieuThu in list)
				{
					DienNangTieuThu.Update(dienNangTieuThu);
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
