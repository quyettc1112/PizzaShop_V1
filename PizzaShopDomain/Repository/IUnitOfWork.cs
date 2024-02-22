using PizzaShopDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDomain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenerticRepository<Account> AccountRepository { get; }   
        ICategoryRepository CategoryRepository { get; } 
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailReposotory orderDetailReposotory {  get; } 
        IProductRepository ProductRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        int Save();
    }
}
