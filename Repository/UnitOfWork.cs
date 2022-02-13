using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAPIProject.data;


namespace MyAPIProject.Repository
{

    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _dbContext;
        private GenericRepository<Country> _countryRepository;
        private GenericRepository<Hotel> _hotelRepository;
        public GenericRepository<Country> CountryRepository =>
          _countryRepository ??= new GenericRepository<Country>((DataBaseContext)_dbContext);
        public GenericRepository<Hotel> HotelRepository =>
            _hotelRepository ??= new GenericRepository<Hotel>((DataBaseContext)_dbContext);

        public GenericRepository<T> Repository => throw new NotImplementedException();

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            _countryRepository = new GenericRepository<Country>((DataBaseContext)_dbContext);
            _hotelRepository = new GenericRepository<Hotel>((DataBaseContext)_dbContext);

        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }
        // public void RejectChanges()
        // {
        //     foreach (var entry in _dbContext.ChangeTracker.Entries()
        //           .Where(e => e.State != EntityState.Unchanged))
        //     {
        //         switch (entry.State)
        //         {
        //             case EntityState.Added:
        //                 entry.State = EntityState.Detached;
        //                 break;
        //             case EntityState.Modified:
        //             case EntityState.Deleted:
        //                 entry.Reload();
        //                 break;
        //         }
        //     }
        // }
    }
}