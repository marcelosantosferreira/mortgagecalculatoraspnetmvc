namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mortgages",
                c => new
                    {
                        mortgageId = c.Int(nullable: false, identity: true),
                        amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        interest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        period = c.Int(nullable: false),
                        insertedIn = c.DateTime(nullable: false),
                        email = c.String(),
                        sent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.mortgageId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        userlogin = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Mortgages");
        }
    }
}
