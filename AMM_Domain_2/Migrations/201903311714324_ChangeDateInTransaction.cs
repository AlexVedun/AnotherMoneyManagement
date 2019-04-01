namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateInTransaction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
        }
    }
}
