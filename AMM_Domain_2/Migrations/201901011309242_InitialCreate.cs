namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        Family_Id = c.Int(),
                        Family_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .ForeignKey("dbo.Families", t => t.Family_Id1)
                .Index(t => t.Family_Id)
                .Index(t => t.Family_Id1);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Type_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfSources", t => t.Type_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TypeOfSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sources", t => t.From_Id)
                .ForeignKey("dbo.Sources", t => t.To_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.From_Id)
                .Index(t => t.To_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Debet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Source_Id = c.Int(),
                        TransactionLog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sources", t => t.Source_Id)
                .ForeignKey("dbo.TransactionLogs", t => t.TransactionLog_Id)
                .Index(t => t.Source_Id)
                .Index(t => t.TransactionLog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Family_Id1", "dbo.Families");
            DropForeignKey("dbo.Families", "Admin_Id", "dbo.Users");
            DropForeignKey("dbo.TransactionLogs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Transactions", "TransactionLog_Id", "dbo.TransactionLogs");
            DropForeignKey("dbo.Transactions", "Source_Id", "dbo.Sources");
            DropForeignKey("dbo.TransactionLogs", "To_Id", "dbo.Sources");
            DropForeignKey("dbo.TransactionLogs", "From_Id", "dbo.Sources");
            DropForeignKey("dbo.Sources", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Sources", "Type_Id", "dbo.TypeOfSources");
            DropForeignKey("dbo.Users", "Family_Id", "dbo.Families");
            DropIndex("dbo.Transactions", new[] { "TransactionLog_Id" });
            DropIndex("dbo.Transactions", new[] { "Source_Id" });
            DropIndex("dbo.TransactionLogs", new[] { "User_Id" });
            DropIndex("dbo.TransactionLogs", new[] { "To_Id" });
            DropIndex("dbo.TransactionLogs", new[] { "From_Id" });
            DropIndex("dbo.Sources", new[] { "User_Id" });
            DropIndex("dbo.Sources", new[] { "Type_Id" });
            DropIndex("dbo.Users", new[] { "Family_Id1" });
            DropIndex("dbo.Users", new[] { "Family_Id" });
            DropIndex("dbo.Families", new[] { "Admin_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionLogs");
            DropTable("dbo.TypeOfSources");
            DropTable("dbo.Sources");
            DropTable("dbo.Users");
            DropTable("dbo.Families");
        }
    }
}
