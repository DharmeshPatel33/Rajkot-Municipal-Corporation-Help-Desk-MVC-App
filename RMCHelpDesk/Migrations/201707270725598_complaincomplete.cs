namespace RMCHelpDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complaincomplete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComplainRegistrationModels", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ComplainRegistrationModels", "Date");
        }
    }
}
