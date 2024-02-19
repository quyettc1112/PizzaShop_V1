using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDataAccess.Implementations
{
    public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(PizzaStoreContext context): base(context) { }
    }
}
