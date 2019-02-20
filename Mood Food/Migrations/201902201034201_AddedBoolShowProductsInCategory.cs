namespace Mood_Food.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoolShowProductsInCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "ShowProductsFromTheseCategoryInHomePage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "ShowProductsFromTheseCategoryInHomePage");
        }
    }
}
