namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccommodationFeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccommodationFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccommodationId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.AccommodationId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccommodationFeedbacks", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccommodationFeedbacks", "AccommodationId", "dbo.Accommodations");
            DropIndex("dbo.AccommodationFeedbacks", new[] { "User_Id" });
            DropIndex("dbo.AccommodationFeedbacks", new[] { "AccommodationId" });
            DropTable("dbo.AccommodationFeedbacks");
        }
    }
}
