namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01_02_20191 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "TransactionLog_Id", "dbo.TransactionLogs");
            DropIndex("dbo.Transactions", new[] { "TransactionLog_Id" });
            RenameColumn(table: "dbo.Transactions", name: "TransactionLog_Id", newName: "TransactionLogId");
            AlterColumn("dbo.Transactions", "TransactionLogId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "TransactionLogId");
            AddForeignKey("dbo.Transactions", "TransactionLogId", "dbo.TransactionLogs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionLogId", "dbo.TransactionLogs");
            DropIndex("dbo.Transactions", new[] { "TransactionLogId" });
            AlterColumn("dbo.Transactions", "TransactionLogId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "TransactionLogId", newName: "TransactionLog_Id");
            CreateIndex("dbo.Transactions", "TransactionLog_Id");
            AddForeignKey("dbo.Transactions", "TransactionLog_Id", "dbo.TransactionLogs", "Id");
        }
    }
}
