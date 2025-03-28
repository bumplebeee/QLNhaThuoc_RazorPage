using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLThuoc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLThuoc.Pages.Pharmacy
{
    public class View_ThuocModel : PageModel
    {
        private readonly QlthuocContext _context;

        public View_ThuocModel(QlthuocContext context)
        {
            _context = context;
        }

        public List<Thuoc> DanhSachThuoc { get; set; }

        public async Task OnGetAsync()
        {
            DanhSachThuoc = await _context.Thuocs
                .Include(t => t.IdDmNavigation)  // Tham chiếu đến bảng DanhMuc
                .Include(t => t.IdXxNavigation)  // Tham chiếu đến bảng XuatXu
                .Include(t => t.IdDvtNavigation) // Tham chiếu đến bảng DonViTinh
                .ToListAsync();
        }
    }
}
