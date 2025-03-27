using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class PhieuNhap
{
    public string IdPn { get; set; } = null!;

    public DateTime ThoiGian { get; set; }

    public string IdNv { get; set; } = null!;

    public string IdNcc { get; set; } = null!;

    public double TongTien { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual NhaCungCap IdNccNavigation { get; set; } = null!;

    public virtual NhanVien IdNvNavigation { get; set; } = null!;
}
