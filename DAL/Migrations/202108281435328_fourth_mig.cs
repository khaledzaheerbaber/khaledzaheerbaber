namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "DateOfBirts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DateOfBirts", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employees", "DateOfBirth");
        }
    }
}
