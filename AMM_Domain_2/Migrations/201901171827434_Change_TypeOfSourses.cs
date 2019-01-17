namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_TypeOfSourses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sources", "Type_Id", "dbo.TypeOfSources");
            DropIndex("dbo.Sources", new[] { "Type_Id" });
            AddColumn("dbo.Sources", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Sources", "Type_Id");
            DropTable("dbo.TypeOfSources");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypeOfSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sources", "Type_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Sources", "Type");
            CreateIndex("dbo.Sources", "Type_Id");
            AddForeignKey("dbo.Sources", "Type_Id", "dbo.TypeOfSources", "Id", cascadeDelete: true);
        }
    }
}
