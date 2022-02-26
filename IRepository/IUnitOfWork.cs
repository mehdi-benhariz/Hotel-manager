//create Iunitofwork interface
// Language: csharp
// Path: IRepository/IUnitOfWork.cs
// Compare this snippet from Repository/GenericRepository.cs:
using System;
using System.Threading.Tasks;
using MyAPIProject.data;
using MyAPIProject.IRepository;

namespace MyAPIProject.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        Task<bool> SaveAll();
    }

}

