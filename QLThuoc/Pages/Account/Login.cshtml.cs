using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using QLThuoc.Models;

namespace QLThuoc.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly QlthuocContext _context;

        public LoginModel(QlthuocContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra tài khoản trong database
            var user = await _context.TaiKhoans
                .FirstOrDefaultAsync(u => u.Username == Input.Username && u.Password == Input.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                return Page();
            }

            // Lưu session
            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToPage("/Index"); // Chuyển hướng về trang chủ hoặc trang dashboard
        }
    }
}
