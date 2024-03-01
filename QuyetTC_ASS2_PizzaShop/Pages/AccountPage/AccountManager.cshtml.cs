using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuyetTC_ASS2_Repository.Implementations;
using QuyetTC_ASS2_Repository.Models;

namespace QuyetTC_ASS2_PizzaShop.Pages.AccountPage
{
    public class AccountManagerModel : PageModel
    {

        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public List<QuyetTC_ASS2_Repository.Models.Account> Accounts { get; set; }
        public IActionResult OnGet()
        {
            Accounts = _unitOfWork.AccountRepository.GetPagination().ToList(); // Giả sử Accounts là một repository trong UnitOfWork

            // Truyền danh sách accounts đến View để hiển thị trong UI
            return Page();
        }
    }
}
