namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sec_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.Users", "LastUpdate");
            DropColumn("dbo.Users", "CreatedDate");
        }
    }
}
