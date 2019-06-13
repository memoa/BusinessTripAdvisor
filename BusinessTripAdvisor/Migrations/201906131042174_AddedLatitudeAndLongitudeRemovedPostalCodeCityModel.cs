namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLatitudeAndLongitudeRemovedPostalCodeCityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Latitude", c => c.Int(nullable: false));
            AddColumn("dbo.Cities", "Longitude", c => c.Int(nullable: false));
            DropColumn("dbo.Cities", "PostalCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "PostalCode", c => c.Int(nullable: false));
            DropColumn("dbo.Cities", "Longitude");
            DropColumn("dbo.Cities", "Latitude");
        }
    }
}
