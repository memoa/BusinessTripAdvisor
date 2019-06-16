namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFaIconNameToTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "FaIconName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "FaIconName");
        }
    }
}
