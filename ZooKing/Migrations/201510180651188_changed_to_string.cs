using System;
using System.Data.Entity.Migrations;

public partial class changed_to_string : DbMigration
{
    public override void Up()
    {
        AlterColumn("dbo.Animal", "Type", c => c.String());
    }
    
    public override void Down()
    {
        AlterColumn("dbo.Animal", "Type", c => c.Int(nullable: false));
    }
}
