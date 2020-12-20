using Coelsa.Domain.CustomEntitites;
using Coelsa.Domain.Entities;
using Coelsa.Domain.Interfaces;
using Coelsa.Domain.Interfaces.Repositories;
using Coelsa.Domain.Interfaces.Services;
using Coelsa.Domain.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coelsa.Domain.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public ContactsService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Contacts> GetContacts(int id)
        {
            return await _unitOfWork.ContactsRepository.GetById(id);
        }

        public PagedList<Contacts> GetAllContacts(ContactsQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var Contacts = _unitOfWork.ContactsRepository.GetAll();

            if (filters.FirstName != null) Contacts = Contacts.Where(x => x.FirstName.ToLower().Contains(filters.FirstName.ToLower()));

            if (filters.LastName != null) Contacts = Contacts.Where(x => x.LastName.ToLower().Contains(filters.LastName.ToLower()));

            if (filters.Company != null) Contacts = Contacts.Where(x => x.Company.ToLower().Contains(filters.Company.ToLower()));

            if (filters.Email != null) Contacts = Contacts.Where(x => x.Email.ToLower().Contains(filters.Email.ToLower()));

            if (filters.PhoneNumber != null) Contacts = Contacts.Where(x => x.PhoneNumber.ToLower().Contains(filters.PhoneNumber.ToLower()));

            var pagedContactss = PagedList<Contacts>.Create(Contacts, filters.PageNumber, filters.PageSize);
            return pagedContactss;
        }

        public async Task InsertContacts(Contacts Contacts)
        {
            await _unitOfWork.ContactsRepository.Add(Contacts);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateContacts(Contacts Contacts)
        {
            _unitOfWork.ContactsRepository.Update(Contacts);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContacts(int id)
        {
            await _unitOfWork.ContactsRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
