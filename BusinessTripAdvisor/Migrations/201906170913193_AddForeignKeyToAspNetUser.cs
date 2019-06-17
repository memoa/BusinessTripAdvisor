namespace BusinessTripAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToAspNetUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CityLIfeFeedbacks", name: "User_Id", newName: "AspNetUserId");
            RenameIndex(table: "dbo.CityLIfeFeedbacks", name: "IX_User_Id", newName: "IX_AspNetUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CityLIfeFeedbacks", name: "IX_AspNetUserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.CityLIfeFeedbacks", name: "AspNetUserId", newName: "User_Id");
        }
    }
}
