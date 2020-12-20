using Coelsa.Domain.Entities;
using Coelsa.Domain.Interfaces.Repositories;
using Coelsa.Infra.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Infra.Data.Repositories
{
    public class ContactsRepository : RepositoryBase<Contacts>, IContactsRepository
    {
        public ContactsRepository(CoelsaChallengeContext context) : base(context) { }
    }
}
