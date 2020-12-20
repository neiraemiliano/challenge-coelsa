
using Coelsa.Domain.Interfaces;
using Coelsa.Domain.Interfaces.Repositories;
using Coelsa.Infra.Data.DbContexts;
using System.Threading.Tasks;

namespace Coelsa.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoelsaChallengeContext _context;
        private readonly IContactsRepository _ContactsRepository;

        public UnitOfWork(CoelsaChallengeContext context)
        {
            _context = context;
        }

        public IContactsRepository ContactsRepository => _ContactsRepository ?? new ContactsRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
