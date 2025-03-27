using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class HoaDon
{
    public string IdHd { get; set; } = null!;

    public DateTime ThoiGian { get; set; }

    public string IdNv { get; set; } = null!;

    public string IdKh { get; set; } = null!;

    public double TongTien { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang IdKhNavigation { get; set; } = null!;

    public virtual NhanVien IdNvNavigation { get; set; } = null!;
}
