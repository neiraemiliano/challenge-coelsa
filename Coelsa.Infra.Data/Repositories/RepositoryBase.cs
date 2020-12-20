using Coelsa.Domain.Entities;
using Coelsa.Domain.Interfaces.Repositories;
using Coelsa.Infra.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coelsa.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly CoelsaChallengeContext _context;
        protected readonly DbSet<T> _entities;

        public RepositoryBase(CoelsaChallengeContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
