using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class ChiTietPhieuNhap
{
    public string IdPn { get; set; } = null!;

    public string IdThuoc { get; set; } = null!;

    public int SoLuong { get; set; }

    public double DonGia { get; set; }

    public virtual PhieuNhap IdPnNavigation { get; set; } = null!;

    public virtual Thuoc IdThuocNavigation { get; set; } = null!;
}
