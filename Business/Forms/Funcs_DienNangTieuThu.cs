using Business.Classes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business.Forms
{
	public class Funcs_DienNangTieuThu
	{
		public List<DienNangTieuThu> AddNewDNTTFromKH(string MaQuanLy, DateTime NgayBD, DateTime NgayKT)
		{
			List<KhachHang> listKH = KhachHang.GetAll();
			List<DienNangTieuThu> listDNTT = new List<DienNangTieuThu>();
			foreach (var khach in listKH)
			{
				DienNangTieuThu dienNangTieuThu = new DienNangTieuThu()
				{
					MaKhachHang = khach.MaKhachHang,
					HoVaTen = khach.HoVaTen,
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

		public List<DienNangTieuThu> ConvertDataTableToListForUpdating(DataTable dt)
		{
			List<DienNangTieuThu> list = new List<DienNangTieuThu>();
			foreach (DataRow row in dt.Rows)
			{
				DienNangTieuThu dienNangTieuThu = new DienNangTieuThu()
				{
					ID = int.Parse(row["ID"].ToString()),
					MaKhachHang = row["MaKhachHang"].ToString(),
					HoVaTen = row["HoVaTen"].ToString(),
					DiaChi = row["DiaChi"].ToString(),
					MaBangGia = row["MaBangGia"].ToString(),
					MaTram = row["MaTram"].ToString(),
					NgayGhi = string.IsNullOrWhiteSpace(row["NgayGhi"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayGhi"].ToString()),
					NguoiGhi = row["NguoiGhi"].ToString(),
					NgayBatDau = string.IsNullOrWhiteSpace(row["NgayBatDau"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayBatDau"].ToString()),
					NgayKetThuc = string.IsNullOrWhiteSpace(row["NgayKetThuc"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayKetThuc"].ToString()),
					NgayCapNhat = string.IsNullOrWhiteSpace(row["NgayCapNhat"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayCapNhat"].ToString()),
					NguoiCapNhat = row["NguoiCapNhat"].ToString(),
					NgayHoaDon = string.IsNullOrWhiteSpace(row["NgayHoaDon"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayHoaDon"].ToString()),
					NgayTraTien = string.IsNullOrWhiteSpace(row["NgayTraTien"].ToString()) ? DateTime.Now : DateTime.Parse(row["NgayTraTien"].ToString()),
					ChiSoMoi = int.Parse(row["ChiSoMoi"].ToString()),
					ChiSoCu = int.Parse(row["ChiSoCu"].ToString()),
					TongTienTruocVAT = int.Parse(row["TongTienTruocVAT"].ToString()),
					TongTienSauVAT = int.Parse(row["TongTienSauVAT"].ToString()),
					DaTra = int.Parse(row["DaTra"].ToString()),
					ConLai = int.Parse(row["ConLai"].ToString())
				};
				list.Add(dienNangTieuThu);
			}
			return list;
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

		public List<DienNangTieuThu> UpdateListForUpdating(List<DienNangTieuThu> list, string maQL)
		{
			foreach (var dienNangTieuThu in list)
			{
				dienNangTieuThu.NgayCapNhat = DateTime.Now;
				dienNangTieuThu.NguoiCapNhat = maQL;
			}
			return list;
		}
	}
}
