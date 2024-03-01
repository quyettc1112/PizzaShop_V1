using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuyetTC_ASS2_Repository.Models;
using QuyetTC_ASS2_Repository.Repository;

namespace QuyetTC_ASS2_PizzaShopWeb.Pages.AccountController
{
    public class EditModel : PageModel
    {
        protected IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {


            var account = _unitOfWork.AccountRepository.GetByID(id);
            if (account == null)
            {
                return NotFound();
            }
            Account = account;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _unitOfWork.AccountRepository.Update(Account);
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }

       
    }
}
