using Microsoft.EntityFrameworkCore;
using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDataAccess.Implementations
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
   
        public CategoryRepository(PizzaStoreContext context): base(context) {
            _context = context;
        }

       
      
    }
}
