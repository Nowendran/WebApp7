namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseID = c.Int(nullable: false, identity: true),
                        beach_id = c.Int(nullable: false),
                        WarehouseName = c.String(),
                    })
                .PrimaryKey(t => t.WarehouseID)
                .ForeignKey("dbo.Beaches", t => t.beach_id, cascadeDelete: true)
                .Index(t => t.beach_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Warehouses", "beach_id", "dbo.Beaches");
            DropIndex("dbo.Warehouses", new[] { "beach_id" });
            DropTable("dbo.Warehouses");
        }
    }
}
