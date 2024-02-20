using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDataAccess.Implementations
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository 
    {
        public ProductRepository(PizzaStoreContext context): base(context) { 



        }

        public IEnumerable<Product> GetAll(Func<IQueryable<Product>, IQueryable<Product>> query = null)
        {
            IQueryable<Product> productsQuery = _context.Products;

            // Thực hiện truy vấn tùy chỉnh nếu có
            if (query != null)
            {
                productsQuery = query(productsQuery);
            }

            return productsQuery.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
