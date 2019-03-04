namespace Way2Buy.DataPersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));            
        }
        
        public override void Down()
        {            
            DropColumn("dbo.Products", "CategoryId");
        }
    }
}
