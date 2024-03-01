using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuyetTC_ASS2_Repository.Models;
using QuyetTC_ASS2_Repository.Repository;

namespace QuyetTC_ASS2_PizzaShopWeb.Pages.AccountController
{
    public class DetailsModel : PageModel
    {
        protected IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       

      public Account Account { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var account = _unitOfWork.AccountRepository.GetByID(id);
            if (account == null)
            {
                return NotFound();
            }
            else {
                Account = account;
            }

            return Page();
        }
    }
}
