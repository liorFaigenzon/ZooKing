using System;
using System.Data.Entity.Migrations;

public partial class workingGreat : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Report",
            c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    ShortInfo = c.String(nullable: false),
                    UpdateForDate = c.DateTime(nullable: false),
                })
            .PrimaryKey(t => t.ID);
        
    }
    
    public override void Down()
    {
        DropTable("dbo.Report");
    }
}
