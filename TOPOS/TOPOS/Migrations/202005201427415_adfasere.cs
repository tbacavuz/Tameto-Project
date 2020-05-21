namespace TOPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adfasere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Carts_Id", c => c.Long());
            CreateIndex("dbo.OrderDetails", "Carts_Id");
            AddForeignKey("dbo.OrderDetails", "Carts_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Carts_Id", "dbo.Carts");
            DropIndex("dbo.OrderDetails", new[] { "Carts_Id" });
            DropColumn("dbo.OrderDetails", "Carts_Id");
        }
    }
}
