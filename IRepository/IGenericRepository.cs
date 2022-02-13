using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAPIProject.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);
        Task<T> Get(Expression<Func<T, bool>> expression,
                string includeProperties = null
        );
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);

        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);

        //insert range
        Task<bool> SaveAll();
        // Task<PagedList<T>> GetPaged<T>(PaginationParams paginationParams) where T : class;
    }
}
