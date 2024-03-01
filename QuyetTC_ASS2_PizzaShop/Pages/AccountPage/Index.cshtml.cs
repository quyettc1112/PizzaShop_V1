using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuyetTC_ASS2_Repository.Implementations;
using QuyetTC_ASS2_Repository.Models;

namespace QuyetTC_ASS2_PizzaShop.Pages.AccountPage
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        [BindProperty]
 
        public IList<QuyetTC_ASS2_Repository.Models.Account> Account { get;set; } = default!;

        public  IActionResult OnGetAsync()
        {
            if (_unitOfWork.AccountRepository != null)
            {
                Account = _unitOfWork.AccountRepository.GetPagination().ToList();
            }

            return Page();
        }
    }
}
