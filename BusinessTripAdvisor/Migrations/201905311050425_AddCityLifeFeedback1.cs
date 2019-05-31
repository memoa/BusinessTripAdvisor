namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityLifeFeedback1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CityId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityLIfeFeedbacks", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CityLIfeFeedbacks", "CityId", "dbo.Cities");
            DropIndex("dbo.CityLIfeFeedbacks", new[] { "User_Id" });
            DropIndex("dbo.CityLIfeFeedbacks", new[] { "CityId" });
            DropTable("dbo.CityLIfeFeedbacks");
        }
    }
}
