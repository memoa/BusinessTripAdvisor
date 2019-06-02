namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCommentTypeModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CommentTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CommentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
