using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuyetTC_ASS2_PizzaShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
     
        }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                Response.Redirect("/Account/Login");
            }
        }

        public IActionResult Logout()
        {
           
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();

           
            return RedirectToAction("/Account/Login");
        }
    }
}
