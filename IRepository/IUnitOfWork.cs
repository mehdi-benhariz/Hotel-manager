//create Iunitofwork interface
// Language: csharp
// Path: IRepository/IUnitOfWork.cs
// Compare this snippet from Repository/GenericRepository.cs:
using System;
using System.Threading.Tasks;
using MyAPIProject.IRepository;

namespace MyAPIProject.Repository
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        GenericRepository<T> Repository { get; }
        Task<bool> SaveAll();
    }

}

