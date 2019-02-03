namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Id_Properties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sources", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Transactions", "From_Id", "dbo.Sources");
            DropForeignKey("dbo.Transactions", "To_Id", "dbo.Sources");
            DropIndex("dbo.Sources", new[] { "User_Id" });
            DropIndex("dbo.Transactions", new[] { "From_Id" });
            DropIndex("dbo.Transactions", new[] { "To_Id" });
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            RenameColumn(table: "dbo.Transactions", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Transactions", name: "From_Id", newName: "FromId");
            RenameColumn(table: "dbo.Transactions", name: "To_Id", newName: "ToId");
            AlterColumn("dbo.Sources", "User_Id", c => c.Int());
            AlterColumn("dbo.Transactions", "FromId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "ToId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sources", "User_Id");
            CreateIndex("dbo.Transactions", "UserId");
            CreateIndex("dbo.Transactions", "FromId");
            CreateIndex("dbo.Transactions", "ToId");
            AddForeignKey("dbo.Sources", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Transactions", "UserId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Transactions", "FromId", "dbo.Sources", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Transactions", "ToId", "dbo.Sources", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ToId", "dbo.Sources");
            DropForeignKey("dbo.Transactions", "FromId", "dbo.Sources");
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Sources", "User_Id", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "ToId" });
            DropIndex("dbo.Transactions", new[] { "FromId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.Sources", new[] { "User_Id" });
            AlterColumn("dbo.Transactions", "UserId", c => c.Int());
            AlterColumn("dbo.Transactions", "ToId", c => c.Int());
            AlterColumn("dbo.Transactions", "FromId", c => c.Int());
            AlterColumn("dbo.Sources", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Transactions", name: "ToId", newName: "To_Id");
            RenameColumn(table: "dbo.Transactions", name: "FromId", newName: "From_Id");
            RenameColumn(table: "dbo.Transactions", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Transactions", "User_Id");
            CreateIndex("dbo.Transactions", "To_Id");
            CreateIndex("dbo.Transactions", "From_Id");
            CreateIndex("dbo.Sources", "User_Id");
            AddForeignKey("dbo.Transactions", "To_Id", "dbo.Sources", "Id");
            AddForeignKey("dbo.Transactions", "From_Id", "dbo.Sources", "Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Sources", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
