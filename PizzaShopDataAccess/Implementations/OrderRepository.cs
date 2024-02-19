using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDataAccess.Implementations
{
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(PizzaStoreContext context):base(context) { }
    }
}
