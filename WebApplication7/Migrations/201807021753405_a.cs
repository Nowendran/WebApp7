namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusCodes",
                c => new
                    {
                        StatusCodeKey = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        availabe = c.String(),
                        OnLoan = c.String(),
                    })
                .PrimaryKey(t => t.StatusCodeKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StatusCodes");
        }
    }
}
