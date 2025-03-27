using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class NhaCungCap
{
    public string IdNcc { get; set; } = null!;

    public string TenNcc { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
