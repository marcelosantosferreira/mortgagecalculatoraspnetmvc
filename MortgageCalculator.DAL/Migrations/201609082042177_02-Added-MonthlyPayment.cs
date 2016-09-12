namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02AddedMonthlyPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mortgages", "monthlypayment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mortgages", "monthlypayment");
        }
    }
}
