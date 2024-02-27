using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuyetTC_ASS2_PizzaShop.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Account/Login");
        }
    }
}
