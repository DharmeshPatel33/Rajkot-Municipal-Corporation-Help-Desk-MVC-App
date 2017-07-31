namespace RMCHelpDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aftercomplain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Complains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Complaintext = c.String(),
                        ComplainRegistratationID = c.Int(nullable: false),
                        DepartmentID = c.Int(),
                        OfficerID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ComplainRegistrationModels", t => t.ComplainRegistratationID, cascadeDelete: true)
                .ForeignKey("dbo.DepartmentModels", t => t.DepartmentID)
                .ForeignKey("dbo.Officers", t => t.OfficerID, cascadeDelete: true)
                .Index(t => t.ComplainRegistratationID)
                .Index(t => t.DepartmentID)
                .Index(t => t.OfficerID);
            
            CreateTable(
                "dbo.Officers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DepartmentModels", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complains", "OfficerID", "dbo.Officers");
            DropForeignKey("dbo.Officers", "DepartmentID", "dbo.DepartmentModels");
            DropForeignKey("dbo.Complains", "DepartmentID", "dbo.DepartmentModels");
            DropForeignKey("dbo.Complains", "ComplainRegistratationID", "dbo.ComplainRegistrationModels");
            DropIndex("dbo.Officers", new[] { "DepartmentID" });
            DropIndex("dbo.Complains", new[] { "OfficerID" });
            DropIndex("dbo.Complains", new[] { "DepartmentID" });
            DropIndex("dbo.Complains", new[] { "ComplainRegistratationID" });
            DropTable("dbo.Officers");
            DropTable("dbo.Complains");
        }
    }
}
