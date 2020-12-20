
using Coelsa.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Coelsa.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContactsRepository ContactsRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
