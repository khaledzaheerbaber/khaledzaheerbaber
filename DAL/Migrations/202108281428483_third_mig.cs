namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third_mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeptName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirts = c.DateTime(nullable: false),
                        PhotoPath = c.String(),
                        DeptId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Depts");
        }
    }
}
