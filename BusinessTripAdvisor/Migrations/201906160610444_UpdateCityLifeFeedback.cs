namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCityLifeFeedback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CityLIfeFeedbacks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CityLIfeFeedbacks", new[] { "User_Id" });
            AddColumn("dbo.CityLIfeFeedbacks", "Title", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CityLIfeFeedbacks", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.CityLIfeFeedbacks", "Longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.CityLIfeFeedbacks", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CityLIfeFeedbacks", "User_Id");
            AddForeignKey("dbo.CityLIfeFeedbacks", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityLIfeFeedbacks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CityLIfeFeedbacks", new[] { "User_Id" });
            AlterColumn("dbo.CityLIfeFeedbacks", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.CityLIfeFeedbacks", "Longitude");
            DropColumn("dbo.CityLIfeFeedbacks", "Latitude");
            DropColumn("dbo.CityLIfeFeedbacks", "Title");
            CreateIndex("dbo.CityLIfeFeedbacks", "User_Id");
            AddForeignKey("dbo.CityLIfeFeedbacks", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
