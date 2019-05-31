namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserTypeAndProviderType : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ProviderTypes");
            DropTable("dbo.UserTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
