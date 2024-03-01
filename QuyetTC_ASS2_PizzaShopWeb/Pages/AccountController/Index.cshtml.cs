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
    public class IndexModel : PageModel
    {
        protected IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Account> Account { get;set; } = default!;

        public async  Task OnGetAsync()
        {
            Account = _unitOfWork.AccountRepository.GetPagination().ToList();
        }
    }
}
