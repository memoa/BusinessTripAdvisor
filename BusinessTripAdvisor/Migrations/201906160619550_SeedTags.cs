namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTags : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Tags VALUES ('Food', 'fa-hamburger')");
            Sql("INSERT INTO Tags VALUES ('Safety', 'fa-user-shield')");
            Sql("INSERT INTO Tags VALUES ('Local Culture', 'fa-university')");
            Sql("INSERT INTO Tags VALUES ('Local Transportation', 'fa-bus')");
            Sql("INSERT INTO Tags VALUES ('Sightseeing', 'fa-eye')");
            Sql("INSERT INTO Tags VALUES ('Other', 'fa-map-signs')");
        }

        public override void Down()
        {
        }
    }
}
