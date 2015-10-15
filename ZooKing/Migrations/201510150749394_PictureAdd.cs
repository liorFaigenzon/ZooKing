namespace ZooKing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animal", new[] { "Area_ZooID", "Area_ID" }, "dbo.Area");
            DropIndex("dbo.Animal", new[] { "Area_ZooID", "Area_ID" });
            DropColumn("dbo.Animal", "AreaID");
            RenameColumn(table: "dbo.Animal", name: "Area_ZooID", newName: "AreaID");
            DropPrimaryKey("dbo.Animal");
            DropPrimaryKey("dbo.Area");
            AlterColumn("dbo.Animal", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Area", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Animal", "ID");
            AddPrimaryKey("dbo.Area", "ID");
            CreateIndex("dbo.Animal", "AreaID");
            AddForeignKey("dbo.Animal", "AreaID", "dbo.Area", "ID", cascadeDelete: true);
            DropColumn("dbo.Animal", "Area_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animal", "Area_ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Animal", "AreaID", "dbo.Area");
            DropIndex("dbo.Animal", new[] { "AreaID" });
            DropPrimaryKey("dbo.Area");
            DropPrimaryKey("dbo.Animal");
            AlterColumn("dbo.Area", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Animal", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Area", new[] { "ZooID", "ID" });
            AddPrimaryKey("dbo.Animal", new[] { "AreaID", "ID" });
            RenameColumn(table: "dbo.Animal", name: "AreaID", newName: "Area_ZooID");
            AddColumn("dbo.Animal", "AreaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Animal", new[] { "Area_ZooID", "Area_ID" });
            AddForeignKey("dbo.Animal", new[] { "Area_ZooID", "Area_ID" }, "dbo.Area", new[] { "ZooID", "ID" }, cascadeDelete: true);
        }
    }
}
