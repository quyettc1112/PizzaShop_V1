using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuyetTC_ASS2_Repository.Implementations;
using QuyetTC_ASS2_Repository.Models;

namespace QuyetTC_ASS2_PizzaShop.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
    

      
        public IActionResult OnGet()
        {
            return Page();
        }

        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        [BindProperty]
        public QuyetTC_ASS2_Repository.Models.Account Account { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
          if (!ModelState.IsValid || _unitOfWork.AccountRepository == null || Account == null)
            {
                return Page();
            }

            _unitOfWork.AccountRepository.Add(Account);
             _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}
