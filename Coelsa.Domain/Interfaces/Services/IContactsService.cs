
using Coelsa.Domain.CustomEntitites;
using Coelsa.Domain.Entities;
using Coelsa.Domain.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coelsa.Domain.Interfaces.Services
{
    public interface IContactsService
    {
        PagedList<Contacts> GetAllContacts(ContactsQueryFilter filters);

        Task<Contacts> GetContacts(int id);

        Task InsertContacts(Contacts Contacts);

        Task<bool> UpdateContacts(Contacts Contacts);

        Task<bool> DeleteContacts(int id);
    }
}
