using Jkcs.Contacts.Data.BaseRepo;
using Jkcs.Contacts.Data.Contracts.RepositoryInterfaces;
using Jkcs.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Data.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactDBContext context)
            : base(context)
        {
        }
    }
}
