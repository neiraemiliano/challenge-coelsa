using Coelsa.Domain.CustomEntitites;
using Coelsa.Domain.Entities;
using Coelsa.Domain.Interfaces;
using Coelsa.Domain.QueryFilters;
using Coelsa.Domain.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoelsaTest
{
    [TestClass]
    public class ContactsUnitTest
    {
        [TestMethod]
        public void Test_Endpoint_Contacts_InsertContacts()
        {
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            Mock<IOptions<PaginationOptions>> paginationOptions = new Mock<IOptions<PaginationOptions>>();

            ContactsService contactsService = new ContactsService(unitOfWork.Object, paginationOptions.Object);

            Contacts contacts = new Contacts();
            contacts.Id = 2;
            contacts.FirstName = "Emiliano";
            contacts.LastName = "Neira";
            contacts.Email = "emilianoneira_@hotmail.com";
            contacts.PhoneNumber = "3412149821";
            contacts.Company = "Coelsa";

            unitOfWork.Setup(a => a.ContactsRepository.Add(contacts)).Returns(Task.CompletedTask);

            var insertContacts = contactsService.InsertContacts(contacts);

            Assert.AreEqual(contacts.Id, insertContacts.Id);
        }

        [TestMethod]
        public void Test_Endpoint_Contacts_UpdateContacts()
        {
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            Mock<IOptions<PaginationOptions>> paginationOptions = new Mock<IOptions<PaginationOptions>>();

            ContactsService contactsService = new ContactsService(unitOfWork.Object, paginationOptions.Object);

            Contacts contacts = new Contacts();
            contacts.Id = 1;
            contacts.FirstName = "Emiliano";
            contacts.LastName = "Neira";
            contacts.Email = "emilianoneira_@hotmail.com";
            contacts.PhoneNumber = "3412149821";
            contacts.Company = "Coelsa";

            unitOfWork.Setup(a => a.ContactsRepository.Update(contacts));

            var insertContacts = contactsService.UpdateContacts(contacts);

            Assert.AreEqual(contacts.Id, insertContacts.Id);
        }

        [TestMethod]
        public void Test_Endpoint_Contacts_GetByIdContacts()
        {
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            Mock<IOptions<PaginationOptions>> paginationOptions = new Mock<IOptions<PaginationOptions>>();

            ContactsService contactsService = new ContactsService(unitOfWork.Object, paginationOptions.Object);

            int Id = 1;

            unitOfWork.Setup(a => a.ContactsRepository.GetById(Id)).Returns(Task.FromResult(new Contacts()
            {
                Id = 1,
                FirstName = "Emiliano",
                LastName = "Neira",
                Email = "emilianoneira_@hotmail.com",
                PhoneNumber = "3412149821",
                Company = "Coelsa"
            }));

            var getContacts = contactsService.GetContacts(Id);

            Assert.AreEqual(Id, getContacts.Result.Id);
        }

        [TestMethod]
        public void Test_Endpoint_Contacts_DeleteByIdContacts()
        {
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            Mock<IOptions<PaginationOptions>> paginationOptions = new Mock<IOptions<PaginationOptions>>();

            ContactsService contactsService = new ContactsService(unitOfWork.Object, paginationOptions.Object);

            int Id = 1;

            unitOfWork.Setup(a => a.ContactsRepository.Delete(Id)).Returns(Task.CompletedTask);

            var deleteContacts = contactsService.DeleteContacts(Id);

            Assert.AreEqual(Id, deleteContacts.Id);
        }

        [TestMethod]
        public void Test_Endpoint_Contacts_GellAllContacts()
        {
            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
            Mock<IOptions<PaginationOptions>> paginationOptions = new Mock<IOptions<PaginationOptions>>();

            ContactsService contactsService = new ContactsService(unitOfWork.Object, paginationOptions.Object);

            ContactsQueryFilter contactsQueryFilter = new ContactsQueryFilter();
            contactsQueryFilter.PageNumber = 1;
            contactsQueryFilter.PageSize = 10;

            List<Contacts> contacts = new List<Contacts>();
            contacts.Add(new Contacts()
            {
                Id = 1,
                FirstName = "Emiliano",
                LastName = "Neira",
                Email = "emilianoneira_@hotmail.com",
                PhoneNumber = "3412149821",
                Company = "Coelsa"
            });
            contacts.Add(new Contacts()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test.com",
                PhoneNumber = "3412149821",
                Company = "test"
            });

            unitOfWork.Setup(a => a.ContactsRepository.GetAll()).Returns(contacts);

            var getAllContacts = contactsService.GetAllContacts(contactsQueryFilter);

            Assert.IsTrue(getAllContacts != null);
        }
    }
}

