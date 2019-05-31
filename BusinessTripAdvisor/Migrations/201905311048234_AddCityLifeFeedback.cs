namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityLifeFeedback : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CityLIfeFeedbacks", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CityLIfeFeedbacks", "UserId", c => c.Int(nullable: false));
        }
    }
}
