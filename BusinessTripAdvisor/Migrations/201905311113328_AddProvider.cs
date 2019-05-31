namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProvider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TransportationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransportationTypes", t => t.TransportationTypeId, cascadeDelete: true)
                .Index(t => t.TransportationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Providers", "TransportationTypeId", "dbo.TransportationTypes");
            DropIndex("dbo.Providers", new[] { "TransportationTypeId" });
            DropTable("dbo.Providers");
        }
    }
}
