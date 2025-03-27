using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class Thuoc
{
    public string IdThuoc { get; set; } = null!;

    public string TenThuoc { get; set; } = null!;

    public byte[]? HinhAnh { get; set; }

    public string? ThanhPhan { get; set; }

    public string IdDvt { get; set; } = null!;

    public string IdDm { get; set; } = null!;

    public string IdXx { get; set; } = null!;

    public int SoLuongTon { get; set; }

    public double GiaNhap { get; set; }

    public double DonGia { get; set; }

    public DateOnly HanSuDung { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ICollection<ChiTietPhieuDatHang> ChiTietPhieuDatHangs { get; set; } = new List<ChiTietPhieuDatHang>();

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual DanhMuc IdDmNavigation { get; set; } = null!;

    public virtual DonViTinh IdDvtNavigation { get; set; } = null!;

    public virtual XuatXu IdXxNavigation { get; set; } = null!;
}
