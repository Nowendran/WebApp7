namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Status = c.String(),
                        Item_Description = c.String(),
                        WarehouseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryID)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.WarehouseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "WarehouseID", "dbo.Warehouses");
            DropIndex("dbo.Inventories", new[] { "WarehouseID" });
            DropTable("dbo.Inventories");
        }
    }
}
