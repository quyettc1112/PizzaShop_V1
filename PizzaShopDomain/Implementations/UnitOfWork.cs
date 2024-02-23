using Microsoft.EntityFrameworkCore;
using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDomain.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaStoreContext _context = new PizzaStoreContext();

        private IGenerticRepository<Account> accountRepository;
        private IGenerticRepository<Category> categoryRepository;
        private IGenerticRepository<Customer> customerRepository;
        private IGenerticRepository<Order> orderRepository;
        private IGenerticRepository<OrderDetail> orderDetailRepository;
        private IGenerticRepository<Product> productRepository;
        private IGenerticRepository<Supplier> supplierRepository;

  

        public IGenerticRepository<Account> AccountRepository {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new GenericRepository<Account>(_context);
                }
                return accountRepository;
            }
        }

        public IGenerticRepository<Category> CategoryRepository { 
            get
            {
                if (categoryRepository == null) {
                    categoryRepository = new GenericRepository<Category>(_context);
                }
                return categoryRepository;
            }
      
        }
        public IGenerticRepository<Customer> CustomerRepository {
            get {

                if (customerRepository == null) { 
                    customerRepository = new  GenericRepository<Customer>(_context);                              
                }
                return customerRepository;
            }     
        }

        public IGenerticRepository<Order> OrderRepository {
            get
            {

                if (orderRepository == null)
                {
                    orderRepository = new GenericRepository<Order>(_context);
                }
                return orderRepository;
            }
        }

        public IGenerticRepository<OrderDetail> OrderDetailRepository {
            get
            {

                if (orderDetailRepository == null)
                {
                    orderDetailRepository = new GenericRepository<OrderDetail>(_context);
                }
                return orderDetailRepository;
            }

        }

        public IGenerticRepository<Product> ProductRepository {

            get
            {

                if (productRepository == null)
                {
                    productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }

        }

        public IGenerticRepository<Supplier> SupplierRepository {
            get
            {

                if (supplierRepository == null)
                {
                    supplierRepository = new GenericRepository<Supplier>(_context);
                }
                return supplierRepository;
            }

        }

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
