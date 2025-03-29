using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLThuoc.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QLThuoc.Pages.Pharmacy
{
    public class View_ThuocModel : PageModel
    {
        private readonly QlthuocContext _context;

        public View_ThuocModel(QlthuocContext context)
        {
            _context = context;
        }

        // Danh sách thuốc hiển thị trong bảng
        public List<Thuoc> DanhSachThuoc { get; set; } = new List<Thuoc>();

        // Thuộc tính binding cho form cập nhật
        [BindProperty]
        public Thuoc ThuocUpdate { get; set; } = new Thuoc();

        public async Task OnGetAsync()
        {
            DanhSachThuoc = await _context.Thuocs
                .Include(t => t.IdDmNavigation)
                .Include(t => t.IdXxNavigation)
                .Include(t => t.IdDvtNavigation)
                .ToListAsync();
        }

        // Handler cập nhật dữ liệu khi form được submit
        public async Task<IActionResult> OnPostUpdateThuocAsync()
        {
            var existingThuoc = await _context.Thuocs.FindAsync(ThuocUpdate.IdThuoc);
            if (existingThuoc == null)
            {
                return NotFound("Không tìm thấy thuốc");
            }

            // Cập nhật các trường (lưu ý: các giá trị cần phải là ID thay vì tên nếu bạn cập nhật khóa ngoại)
            existingThuoc.TenThuoc = ThuocUpdate.TenThuoc;
            existingThuoc.IdDm = ThuocUpdate.IdDm;
            existingThuoc.IdXx = ThuocUpdate.IdXx;
            existingThuoc.IdDvt = ThuocUpdate.IdDvt;
            existingThuoc.SoLuongTon = ThuocUpdate.SoLuongTon;
            existingThuoc.GiaNhap = ThuocUpdate.GiaNhap;
            existingThuoc.DonGia = ThuocUpdate.DonGia;
            existingThuoc.ThanhPhan = ThuocUpdate.ThanhPhan;

            _context.Thuocs.Update(existingThuoc);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Cập nhật thành công";
            return RedirectToPage();
        }
    }
}
