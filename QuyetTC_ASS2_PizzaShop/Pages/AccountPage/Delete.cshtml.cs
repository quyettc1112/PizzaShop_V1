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
    public class DeleteModel : PageModel
    {

        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        [BindProperty]
        public QuyetTC_ASS2_Repository.Models.Account Account { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null || _unitOfWork.AccountRepository == null)
            {
                return NotFound();
            }

            var account =  _unitOfWork.AccountRepository.Find(m => m.AccountId == id);

            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = (QuyetTC_ASS2_Repository.Models.Account)account;
            }
            return Page();
        }

        public  IActionResult OnPostAsync(int id)
        {
            if (id == null || _unitOfWork.AccountRepository == null)
            {
                return NotFound();
            }
            var account = _unitOfWork.AccountRepository.GetByID(id);

            if (account != null)
            {
                Account = (QuyetTC_ASS2_Repository.Models.Account)account;
                _unitOfWork.AccountRepository.Remove(Account);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
