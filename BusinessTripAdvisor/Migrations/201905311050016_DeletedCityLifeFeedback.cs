namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedCityLifeFeedback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CityLIfeFeedbacks", "CityId", "dbo.Cities");
            DropForeignKey("dbo.CityLIfeFeedbacks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CityLIfeFeedbacks", new[] { "CityId" });
            DropIndex("dbo.CityLIfeFeedbacks", new[] { "User_Id" });
            DropTable("dbo.CityLIfeFeedbacks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CityLIfeFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CityLIfeFeedbacks", "User_Id");
            CreateIndex("dbo.CityLIfeFeedbacks", "CityId");
            AddForeignKey("dbo.CityLIfeFeedbacks", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CityLIfeFeedbacks", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
