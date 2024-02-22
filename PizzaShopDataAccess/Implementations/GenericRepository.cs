using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopDataAccess.Implementations
{
    public class GenericRepository<T> : IGenerticRepository<T> where T : class
    {
        public PizzaStoreContext _context = new PizzaStoreContext();


        public GenericRepository(PizzaStoreContext context)
        {
            _context = context;
        }   

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
           _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
           return  _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            var entities = _context.Set<T>().ToList();
            foreach (var entity in entities)
            {
                // Example: Check if any property of the entity is NULL and handle it appropriately
                // Note: You might need reflection or some other mechanism to dynamically check properties

                // For demonstration purposes, let's assume there's a property named 'Name' in the entity
                // Replace 'Name' with the actual property name in your entity
                var propertyInfo = typeof(T).GetProperty("ProductImage");
                if (propertyInfo != null)
                {
                    var value = propertyInfo.GetValue(entity);
                    if (value == null)
                    {
                        // Handle the NULL value here, such as setting a default value or logging the issue
                        // For demonstration, let's just set it to an empty string
                        propertyInfo.SetValue(entity, "");
                    }
                }
            }

            return entities;
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
