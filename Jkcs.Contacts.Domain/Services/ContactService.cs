using Jkcs.Contacts.Common;
using Jkcs.Contacts.Data.BaseRepo;
using Jkcs.Contacts.Data.Contracts;
using Jkcs.Contacts.Data.Uow;
using Jkcs.Contacts.Domain.Contracts.Interfaces;
using Jkcs.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Domain.Services
{
    [Injectable]
    public class ContactService : IContactService
    {
        public async Task<Contact> CreateContact(Contact _contact, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            Contact _createdContact = await ContactService.AddAsync(_contact);

            return _createdContact;
        }

        public async Task<ICollection<Contact>> GetAllContacts(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            ICollection<Contact> _allContacts = await ContactService.GetAllAsync();

            return _allContacts;
        }

        public async Task<Contact> GetContactByContactId(long _contactId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            Contact _contact = await ContactService.GetSingleAsync(_contactId);

            return _contact;
        }

        public async Task<IEnumerable<Contact>> GetContactList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            IEnumerable<Contact> _allContacts = await ContactService.GetPagedListAsync(pageNo, pageSize, null, q => q.OrderBy(s => s.Name), null);

            return _allContacts;
        }

        public async Task<Contact> UpdateContact(Contact _contact, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            Contact _updatedContact = await ContactService.UpdateAsync(_contact, _contact.ContactId);

            return _updatedContact;
        }

        public async Task<Contact> UpdateContact(Contact _contact, long _contactId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            Contact _updatedContact = await ContactService.UpdateAsync(_contact, _contactId);

            return _updatedContact;
        }

        public async Task<int> DeleteContact(int contactId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            return await ContactService.DeleteAsync(contactId);
        }

        public async Task<int> GetContactCount(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Contact> ContactService = _dataRepositoryFactory.GetRepository<Contact>();
            int _count = await ContactService.CountAsync();

            return _count;
        }
    }
}
