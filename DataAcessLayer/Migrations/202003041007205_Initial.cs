namespace DataAcessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        FatherName = c.String(),
                        Address = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.DetailId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        CompanyId = c.Int(),
                        DepartmentId = c.Int(),
                        DetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.EmployeeDetails", t => t.DetailId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DetailId", "dbo.EmployeeDetails");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "DetailId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeDetails");
            DropTable("dbo.Departments");
            DropTable("dbo.Companies");
        }
    }
}
