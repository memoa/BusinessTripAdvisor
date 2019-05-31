namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityLifeFeedback : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CityLifeFeedbacks", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CityLifeFeedbacks", "UserId", c => c.Int(nullable: false));
        }
    }
}
