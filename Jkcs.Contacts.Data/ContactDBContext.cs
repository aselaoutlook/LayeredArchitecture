using Jkcs.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Data
{
    public partial class ContactDBContext : DbContext
    {
        #region Initialize DbSets
        public DbSet<Contact> Contacts { get; set; }
        #endregion

        public ContactDBContext()
            :base("ContactDBContext")
        {
            //Usefull migration commands
            //Enable-Migrations
            //Add-Migration InitialMigration
            //Update-Database -Verbose
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
