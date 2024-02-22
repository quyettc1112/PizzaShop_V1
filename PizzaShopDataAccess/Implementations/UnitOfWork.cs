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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaStoreContext _context = new PizzaStoreContext();

        private IGenerticRepository<Account> accountRepository;

        public UnitOfWork(PizzaStoreContext context)
        {
            _context = context;

            AccountRepository = new AccountRepository(_context);
            ProductRepository = new ProductRepository(_context);
            SupplierRepository = new SupplierRepository(_context);
            OrderRepository = new OrderRepository(_context);
            orderDetailReposotory = new OrderDetailRepository(_context);
            CategoryRepository = new CategoryRepository(_context);

        }

        /*public IGenerticRepository<Account> AccountRepository {
            get {   if (accountRepository == null) { accountRepository = new GenericRepository<Account>(_context); }
                return accountRepository;
            }
        }*/

        public IAccountRepository AccountRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public ICustomerRepository CustomerRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }

        public IOrderDetailReposotory orderDetailReposotory { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public ISupplierRepository SupplierRepository { get; private set; }

  

        public void Dispose()
        {
            _context.Dispose();
         
        }

        public int Save()
        {
           return _context.SaveChanges();
        }
    }
}
