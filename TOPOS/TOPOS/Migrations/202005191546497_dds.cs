namespace TOPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ProductsId", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "ProductsId" });
            RenameColumn(table: "dbo.Carts", name: "ProductsId", newName: "Products_Id");
            AddColumn("dbo.Carts", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "CustomerId", c => c.Long());
            AddColumn("dbo.Carts", "ProductId", c => c.Long());
            AddColumn("dbo.Carts", "Customers_Id", c => c.Long());
            AlterColumn("dbo.Carts", "Products_Id", c => c.Long());
            CreateIndex("dbo.Carts", "Customers_Id");
            CreateIndex("dbo.Carts", "Products_Id");
            AddForeignKey("dbo.Carts", "Customers_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Carts", "Products_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.Carts", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "Products_Id" });
            DropIndex("dbo.Carts", new[] { "Customers_Id" });
            AlterColumn("dbo.Carts", "Products_Id", c => c.Long(nullable: false));
            DropColumn("dbo.Carts", "Customers_Id");
            DropColumn("dbo.Carts", "ProductId");
            DropColumn("dbo.Carts", "CustomerId");
            DropColumn("dbo.Carts", "Quantity");
            RenameColumn(table: "dbo.Carts", name: "Products_Id", newName: "ProductsId");
            CreateIndex("dbo.Carts", "ProductsId");
            AddForeignKey("dbo.Carts", "ProductsId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
