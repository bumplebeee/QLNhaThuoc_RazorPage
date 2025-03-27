using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class VaiTro
{
    public string IdVt { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
