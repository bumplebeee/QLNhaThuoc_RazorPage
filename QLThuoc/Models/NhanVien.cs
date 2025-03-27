using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class NhanVien
{
    public string IdNv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public int NamSinh { get; set; }

    public DateOnly NgayVaoLam { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
