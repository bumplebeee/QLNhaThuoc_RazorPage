using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class ChiTietPhieuDatHang
{
    public string IdPdh { get; set; } = null!;

    public string IdThuoc { get; set; } = null!;

    public int SoLuong { get; set; }

    public double DonGia { get; set; }

    public virtual PhieuDatHang IdPdhNavigation { get; set; } = null!;

    public virtual Thuoc IdThuocNavigation { get; set; } = null!;
}
