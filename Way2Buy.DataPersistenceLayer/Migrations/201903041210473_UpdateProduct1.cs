namespace Way2Buy.DataPersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "OfferPrice", c => c.Double());
            AlterColumn("dbo.Products", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageData", c => c.Binary(nullable: false));
            AlterColumn("dbo.Products", "OfferPrice", c => c.Double(nullable: false));
        }
    }
}
