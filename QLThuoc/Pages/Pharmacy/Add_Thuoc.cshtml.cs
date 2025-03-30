using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLThuoc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLThuoc.Pages.Pharmacy
{
    public class Add_ThuocModel : PageModel
    {
        private readonly QlthuocContext _context;

        public Add_ThuocModel(QlthuocContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Thuoc NewThuoc { get; set; } = new Thuoc();

        public List<DanhMuc> DanhMucs { get; set; } = new List<DanhMuc>();
        public List<DonViTinh> DonViTinhs { get; set; } = new List<DonViTinh>();
        public List<XuatXu> XuatXus { get; set; } = new List<XuatXu>();

        public async Task OnGetAsync()
        {
            XuatXus = await _context.XuatXus.ToListAsync();
            DanhMucs = await _context.DanhMucs.ToListAsync();
            DonViTinhs = await _context.DonViTinhs.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    DanhMucs = await _context.DanhMucs.ToListAsync();
            //    DonViTinhs = await _context.DonViTinhs.ToListAsync();
            //    return Page();
            //}

            _context.Thuocs.Add(NewThuoc);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Pharmacy/View_Thuoc");
        }
    }
}
