using System;
using System.Collections.Generic;

namespace QLThuoc.Models;

public partial class DonViTinh
{
    public string IdDvt { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public virtual ICollection<Thuoc> Thuocs { get; set; } = new List<Thuoc>();
}
