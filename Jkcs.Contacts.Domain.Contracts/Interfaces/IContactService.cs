using Jkcs.Contacts.Data.Contracts;
using Jkcs.Contacts.Data.Uow;
using Jkcs.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Domain.Contracts.Interfaces
{
    public interface IContactService
    {
        Task<Contact> CreateContact(Contact _contact, IUnitOfWork _dataRepositoryFactory);
        Task<Contact> UpdateContact(Contact _contact, IUnitOfWork _dataRepositoryFactory);
        Task<Contact> UpdateContact(Contact _contact, long _contactId, IUnitOfWork _dataRepositoryFactory);
        Task<Contact> GetContactByContactId(long _contactId, IUnitOfWork _dataRepositoryFactory);
        Task<ICollection<Contact>> GetAllContacts(IUnitOfWork _dataRepositoryFactory);
        Task<IEnumerable<Contact>> GetContactList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory);
        Task<int> DeleteContact(int contactId, IUnitOfWork _dataRepositoryFactory);
        Task<int> GetContactCount(IUnitOfWork _dataRepositoryFactory);
    }
}
