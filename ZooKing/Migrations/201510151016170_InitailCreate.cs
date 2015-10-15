using System;
using System.Data.Entity.Migrations;

public partial class InitailCreate : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Animal",
            c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Age = c.Int(nullable: false),
                    Type = c.Int(nullable: false),
                    Picture = c.String(),
                    AreaID = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.ID)
            .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
            .Index(t => t.AreaID);
        
        CreateTable(
            "dbo.Area",
            c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Size = c.Int(nullable: false),
                    Picture = c.String(),
                    ZooID = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.ID)
            .ForeignKey("dbo.Zoo", t => t.ZooID, cascadeDelete: true)
            .Index(t => t.ZooID);
        
        CreateTable(
            "dbo.Zoo",
            c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    ShortInfo = c.String(nullable: false),
                    YearOfEstablishment = c.DateTime(nullable: false),
                    Addres = c.String(nullable: false),
                })
            .PrimaryKey(t => t.ID);
        
        CreateTable(
            "dbo.IdentityRole",
            c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(),
                })
            .PrimaryKey(t => t.Id);
        
        CreateTable(
            "dbo.IdentityUserRole",
            c => new
                {
                    RoleId = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                    IdentityRole_Id = c.String(maxLength: 128),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
            .PrimaryKey(t => new { t.RoleId, t.UserId })
            .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
            .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            .Index(t => t.IdentityRole_Id)
            .Index(t => t.ApplicationUser_Id);
        
        CreateTable(
            "dbo.ApplicationUser",
            c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(),
                })
            .PrimaryKey(t => t.Id);
        
        CreateTable(
            "dbo.IdentityUserClaim",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            .Index(t => t.ApplicationUser_Id);
        
        CreateTable(
            "dbo.IdentityUserLogin",
            c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    LoginProvider = c.String(),
                    ProviderKey = c.String(),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
            .PrimaryKey(t => t.UserId)
            .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            .Index(t => t.ApplicationUser_Id);
        
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
        DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
        DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
        DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
        DropForeignKey("dbo.Area", "ZooID", "dbo.Zoo");
        DropForeignKey("dbo.Animal", "AreaID", "dbo.Area");
        DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
        DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
        DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
        DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
        DropIndex("dbo.Area", new[] { "ZooID" });
        DropIndex("dbo.Animal", new[] { "AreaID" });
        DropTable("dbo.IdentityUserLogin");
        DropTable("dbo.IdentityUserClaim");
        DropTable("dbo.ApplicationUser");
        DropTable("dbo.IdentityUserRole");
        DropTable("dbo.IdentityRole");
        DropTable("dbo.Zoo");
        DropTable("dbo.Area");
        DropTable("dbo.Animal");
    }
}
