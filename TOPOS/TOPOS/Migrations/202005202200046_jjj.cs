namespace TOPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "StatusId", c => c.Long(nullable: false));
            DropColumn("dbo.Orders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Status", c => c.Long(nullable: false));
            DropColumn("dbo.Orders", "StatusId");
        }
    }
}
