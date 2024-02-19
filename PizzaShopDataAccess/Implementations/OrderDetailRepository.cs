using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDataAccess.Implementations
{
    public class OrderDetailRepository: GenericRepository<OrderDetail>, IOrderDetailReposotory
    {
        public OrderDetailRepository(PizzaStoreContext context): base(context) { }
    }
}
