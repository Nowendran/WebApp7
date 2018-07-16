
namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanPages",
                c => new
                    {
                        LoanKey = c.Int(nullable: false, identity: true),
                       
                        InventoryID = c.Int(nullable: false),
                        DateOfLoan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LoanKey)
                .ForeignKey("dbo.Inventories", t => t.InventoryID, cascadeDelete: true)
                
               
                .Index(t => t.InventoryID);
            
        }
        
        public override void Down()
        {
          
            DropForeignKey("dbo.LoanPages", "InventoryID", "dbo.Inventories");
            DropIndex("dbo.LoanPages", new[] { "InventoryID" });
           
            DropTable("dbo.LoanPages");
        }
    }
}
