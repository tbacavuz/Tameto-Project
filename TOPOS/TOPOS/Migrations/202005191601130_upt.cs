namespace TOPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.Carts", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "Customers_Id" });
            DropIndex("dbo.Carts", new[] { "Products_Id" });
            DropColumn("dbo.Carts", "CustomerId");
            RenameColumn(table: "dbo.Carts", name: "Customers_Id", newName: "CustomerId");
            AlterColumn("dbo.Carts", "CustomerId", c => c.Long(nullable: false));
            AlterColumn("dbo.Carts", "CustomerId", c => c.Long(nullable: false));
            CreateIndex("dbo.Carts", "CustomerId");
            AddForeignKey("dbo.Carts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Carts", "Quantity");
            DropColumn("dbo.Carts", "ProductId");
            DropColumn("dbo.Carts", "Products_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Products_Id", c => c.Long());
            AddColumn("dbo.Carts", "ProductId", c => c.Long());
            AddColumn("dbo.Carts", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            AlterColumn("dbo.Carts", "CustomerId", c => c.Long());
            AlterColumn("dbo.Carts", "CustomerId", c => c.Long());
            RenameColumn(table: "dbo.Carts", name: "CustomerId", newName: "Customers_Id");
            AddColumn("dbo.Carts", "CustomerId", c => c.Long());
            CreateIndex("dbo.Carts", "Products_Id");
            CreateIndex("dbo.Carts", "Customers_Id");
            AddForeignKey("dbo.Carts", "Customers_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Carts", "Products_Id", "dbo.Products", "Id");
        }
    }
}
