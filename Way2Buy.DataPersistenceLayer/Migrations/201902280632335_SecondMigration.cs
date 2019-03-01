namespace Way2Buy.DataPersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "IsOfferItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "OfferPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "ImageData", c => c.Binary(nullable: false));
            AddColumn("dbo.Products", "ImageMimeType", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));            
        }
        
        public override void Down()
        {

        }
    }
}
