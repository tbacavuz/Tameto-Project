namespace TOPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasereefegeermfekn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Carts_Id", "dbo.Carts");
            DropIndex("dbo.OrderDetails", new[] { "Carts_Id" });
            DropColumn("dbo.OrderDetails", "Carts_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Carts_Id", c => c.Long());
            CreateIndex("dbo.OrderDetails", "Carts_Id");
            AddForeignKey("dbo.OrderDetails", "Carts_Id", "dbo.Carts", "Id");
        }
    }
}
