using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class PhieuDatHang
{
    public string IdPdh { get; set; } = null!;

    public DateTime ThoiGian { get; set; }

    public string IdKh { get; set; } = null!;

    public double TongTien { get; set; }

    public string DiaChi { get; set; } = null!;

    public string PhuongThucThanhToan { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<ChiTietPhieuDatHang> ChiTietPhieuDatHangs { get; set; } = new List<ChiTietPhieuDatHang>();

    public virtual KhachHang IdKhNavigation { get; set; } = null!;
}
