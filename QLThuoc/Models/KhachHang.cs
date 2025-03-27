using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class KhachHang
{
    public string IdKh { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public DateOnly NgayThamGia { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<PhieuDatHang> PhieuDatHangs { get; set; } = new List<PhieuDatHang>();
}
