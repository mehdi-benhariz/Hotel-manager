using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAPIProject.data;
using MyAPIProject.IRepository;

namespace MyAPIProject.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _dbContext;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        public IGenericRepository<Country> Countries =>
          _countries ??= new GenericRepository<Country>(_dbContext);
        public IGenericRepository<Hotel> Hotels =>
            _hotels ??= new GenericRepository<Hotel>(_dbContext);


        public UnitOfWork(DataBaseContext dbContext)
        {
            _dbContext = dbContext;

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
    }
}