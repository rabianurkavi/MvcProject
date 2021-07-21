namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_change2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminMail");
            DropColumn("dbo.Admins", "PasswordSalt");
            DropColumn("dbo.Admins", "PasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            DropColumn("dbo.Admins", "AdminPassword");
        }
    }
}
