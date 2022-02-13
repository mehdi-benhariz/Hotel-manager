using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAPIProject.data;
using MyAPIProject.IRepository;

namespace MyAPIProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(DataBaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();

        }


        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            //check if entity is null
            if (entity == null)
                throw new Exception("Entity not found");

            _db.Remove(entity);

        }

        public void DeleteRange(IEnumerable<T> entities)
        {

            // _db.RemoveRange(entities);
            throw new System.NotImplementedException();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, string includeProperties = null)
        {
            IQueryable<T> query = (IQueryable<T>)_db;
            if (expression != null)
                query = (IQueryable<T>)query.Where(expression);

            if (includeProperties != null)
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);

        }


        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = default, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = default, string includeProperties = null, int? skip = null, int? take = null)
        {
            IQueryable<T> query = (IQueryable<T>)_db;
            if (expression != null)
                query = query.Where(expression);

            if (includeProperties != null)
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);

            if (orderBy != null)
                query = orderBy(query);

            return await query.AsNoTracking().ToListAsync();
        }


        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
            throw new System.NotImplementedException();
        }

        public Task InsertRange(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}