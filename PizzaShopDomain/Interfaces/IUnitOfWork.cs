using QuyetTC_ASS2_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuyetTC_ASS2_Repository.Repository
{
    public interface IUnitOfWork : IDisposable
    {

        IGenerticRepository<Account> AccountRepository { get; }
        IGenerticRepository<Category> CategoryRepository { get; }
        IGenerticRepository<Customer> CustomerRepository { get; }
        IGenerticRepository<Order> OrderRepository { get; }
        IGenerticRepository<OrderDetail> OrderDetailRepository { get; }
        IGenerticRepository<Product> ProductRepository { get; }
        IGenerticRepository<Supplier> SupplierRepository { get; }

       /* IAccountRepository AccountRepository { get; }   
        ICategoryRepository CategoryRepository { get; } 
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailReposotory orderDetailReposotory {  get; } 
        IProductRepository ProductRepository { get; }
        ISupplierRepository SupplierRepository { get; }*/

        int Save();
    }
}
