namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sources", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Sources", "Type_Id", "dbo.TypeOfSources");
            DropIndex("dbo.Sources", new[] { "Type_Id" });
            DropIndex("dbo.Sources", new[] { "User_Id" });
            AddColumn("dbo.Sources", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Sources", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Sources", "Type_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Sources", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Sources", "Type_Id");
            CreateIndex("dbo.Sources", "User_Id");
            AddForeignKey("dbo.Sources", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sources", "Type_Id", "dbo.TypeOfSources", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sources", "Type_Id", "dbo.TypeOfSources");
            DropForeignKey("dbo.Sources", "User_Id", "dbo.Users");
            DropIndex("dbo.Sources", new[] { "User_Id" });
            DropIndex("dbo.Sources", new[] { "Type_Id" });
            AlterColumn("dbo.Sources", "User_Id", c => c.Int());
            AlterColumn("dbo.Sources", "Type_Id", c => c.Int());
            AlterColumn("dbo.Sources", "Name", c => c.String());
            DropColumn("dbo.Sources", "IsDeleted");
            CreateIndex("dbo.Sources", "User_Id");
            CreateIndex("dbo.Sources", "Type_Id");
            AddForeignKey("dbo.Sources", "Type_Id", "dbo.TypeOfSources", "Id");
            AddForeignKey("dbo.Sources", "User_Id", "dbo.Users", "Id");
        }
    }
}
