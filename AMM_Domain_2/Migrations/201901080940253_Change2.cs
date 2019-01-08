namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sources", "Family_Id", c => c.Int());
            CreateIndex("dbo.Sources", "Family_Id");
            AddForeignKey("dbo.Sources", "Family_Id", "dbo.Families", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sources", "Family_Id", "dbo.Families");
            DropIndex("dbo.Sources", new[] { "Family_Id" });
            DropColumn("dbo.Sources", "Family_Id");
        }
    }
}
