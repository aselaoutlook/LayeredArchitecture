namespace Jkcs.Contacts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contacts", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Country", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Country", c => c.String());
            AlterColumn("dbo.Contacts", "City", c => c.String());
            AlterColumn("dbo.Contacts", "Address", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false));
        }
    }
}
