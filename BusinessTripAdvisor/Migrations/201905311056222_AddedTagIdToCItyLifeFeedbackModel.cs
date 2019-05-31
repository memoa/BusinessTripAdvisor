namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTagIdToCItyLifeFeedbackModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CityLIfeFeedbacks", "TagId", c => c.Int(nullable: false));
            CreateIndex("dbo.CityLIfeFeedbacks", "TagId");
            AddForeignKey("dbo.CityLIfeFeedbacks", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityLIfeFeedbacks", "TagId", "dbo.Tags");
            DropIndex("dbo.CityLIfeFeedbacks", new[] { "TagId" });
            DropColumn("dbo.CityLIfeFeedbacks", "TagId");
        }
    }
}
