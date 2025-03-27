using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class TaiKhoan
{
    public string IdTk { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string IdNv { get; set; } = null!;

    public string IdVt { get; set; } = null!;

    public virtual NhanVien IdNvNavigation { get; set; } = null!;

    public virtual VaiTro IdVtNavigation { get; set; } = null!;
}
