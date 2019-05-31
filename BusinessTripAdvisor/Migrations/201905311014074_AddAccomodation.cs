namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccomodation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AccommodationTypeId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        StarRating = c.Int(),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Description = c.String(),
                        WebAddress = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccommodationTypes", t => t.AccommodationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.AccommodationTypeId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accommodations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Accommodations", "AccommodationTypeId", "dbo.AccommodationTypes");
            DropIndex("dbo.Accommodations", new[] { "CityId" });
            DropIndex("dbo.Accommodations", new[] { "AccommodationTypeId" });
            DropTable("dbo.Accommodations");
        }
    }
}
