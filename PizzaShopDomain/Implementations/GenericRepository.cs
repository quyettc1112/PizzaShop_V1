using Microsoft.EntityFrameworkCore;
using QuyetTC_ASS2_Repository.Models;
using QuyetTC_ASS2_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuyetTC_ASS2_Repository.Implementations
{
    public class GenericRepository<T> : IGenerticRepository<T> where T : class
    {
        public DbContext _context;
        private readonly DbSet<T> dbSet;


        public GenericRepository(DbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetPagination(
            Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, 
                IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", 
            int? pageIndex = null, int? 
            pageSize = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Implementing pagination
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                // Ensure the pageIndex and pageSize are valid
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            return query.ToList();
        }


        // Updated Get method with pagination
       



        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
           dbSet.AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
           return  dbSet.Where(predicate);
        }

      
        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

     
    }
}
