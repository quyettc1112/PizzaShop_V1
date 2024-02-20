using Microsoft.EntityFrameworkCore;
using PizzaShopDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDomain.Repository
{
    public interface IProductRepository : IGenerticRepository<Product>
    {
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId);

        IEnumerable<Product> GetAll(Func<IQueryable<Product>, IQueryable<Product>> query = null);


    }
}
