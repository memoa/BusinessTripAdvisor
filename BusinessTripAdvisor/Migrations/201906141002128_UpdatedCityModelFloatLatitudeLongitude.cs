namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCityModelFloatLatitudeLongitude : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Latitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Cities", "Longitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "Longitude", c => c.Int(nullable: false));
            AlterColumn("dbo.Cities", "Latitude", c => c.Int(nullable: false));
        }
    }
}
