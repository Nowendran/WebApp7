namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beaches",
                c => new
                    {
                        beach_id = c.Int(nullable: false, identity: true),
                        beach_name = c.String(nullable: false),
                        city_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.beach_id)
                .ForeignKey("dbo.Cities", t => t.city_id, cascadeDelete: true)
                .Index(t => t.city_id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        city_id = c.Int(nullable: false, identity: true),
                        city_name = c.String(nullable: false),
                        province = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.city_id);
            
            CreateTable(
                "dbo.Lifeguards",
                c => new
                    {
                        lifeguard_id = c.Int(nullable: false, identity: true),
                        lifeguard_name = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        l_status = c.String(nullable: false),
                        city_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lifeguard_id)
                .ForeignKey("dbo.Cities", t => t.city_id, cascadeDelete: true)
                .Index(t => t.city_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lifeguards", "city_id", "dbo.Cities");
            DropForeignKey("dbo.Beaches", "city_id", "dbo.Cities");
            DropIndex("dbo.Lifeguards", new[] { "city_id" });
            DropIndex("dbo.Beaches", new[] { "city_id" });
            DropTable("dbo.Lifeguards");
            DropTable("dbo.Cities");
            DropTable("dbo.Beaches");
        }
    }
}
