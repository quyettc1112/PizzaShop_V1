using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuyetTC_ASS2_Repository.Repository
{
    public interface IGenerticRepository<T> where T : class
    {
        T GetByID(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        public IEnumerable<T> GetPagination(
         Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         string includeProperties = "",
        int? pageIndex = null, // Optional parameter for pagination (page number)
        int? pageSize = null);
    }
}
