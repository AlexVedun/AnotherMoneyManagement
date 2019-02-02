namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_TransactionLog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionLogs", "From_Id", "dbo.Sources");
            DropForeignKey("dbo.TransactionLogs", "To_Id", "dbo.Sources");
            DropForeignKey("dbo.TransactionLogs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Transactions", "TransactionLog_Id", "dbo.TransactionLogs");
            DropIndex("dbo.TransactionLogs", new[] { "From_Id" });
            DropIndex("dbo.TransactionLogs", new[] { "To_Id" });
            DropIndex("dbo.TransactionLogs", new[] { "User_Id" });
            DropIndex("dbo.Transactions", new[] { "TransactionLog_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Source_Id", newName: "From_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Source_Id", newName: "IX_From_Id");
            AddColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "Comment", c => c.String());
            AddColumn("dbo.Transactions", "To_Id", c => c.Int());
            AddColumn("dbo.Transactions", "User_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "To_Id");
            CreateIndex("dbo.Transactions", "User_Id");
            AddForeignKey("dbo.Transactions", "To_Id", "dbo.Sources", "Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Transactions", "TransactionLog_Id");
            DropTable("dbo.TransactionLogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TransactionLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ErrorDetail = c.String(),
                        Comment = c.String(),
                        From_Id = c.Int(),
                        To_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "TransactionLog_Id", c => c.Int());
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Transactions", "To_Id", "dbo.Sources");
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            DropIndex("dbo.Transactions", new[] { "To_Id" });
            DropColumn("dbo.Transactions", "User_Id");
            DropColumn("dbo.Transactions", "To_Id");
            DropColumn("dbo.Transactions", "Comment");
            DropColumn("dbo.Transactions", "Date");
            RenameIndex(table: "dbo.Transactions", name: "IX_From_Id", newName: "IX_Source_Id");
            RenameColumn(table: "dbo.Transactions", name: "From_Id", newName: "Source_Id");
            CreateIndex("dbo.Transactions", "TransactionLog_Id");
            CreateIndex("dbo.TransactionLogs", "User_Id");
            CreateIndex("dbo.TransactionLogs", "To_Id");
            CreateIndex("dbo.TransactionLogs", "From_Id");
            AddForeignKey("dbo.Transactions", "TransactionLog_Id", "dbo.TransactionLogs", "Id");
            AddForeignKey("dbo.TransactionLogs", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.TransactionLogs", "To_Id", "dbo.Sources", "Id");
            AddForeignKey("dbo.TransactionLogs", "From_Id", "dbo.Sources", "Id");
        }
    }
}
