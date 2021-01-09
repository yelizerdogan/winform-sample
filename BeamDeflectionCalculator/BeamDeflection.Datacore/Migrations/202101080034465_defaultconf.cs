namespace BeamDeflection.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defaultconf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Main.Beams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Main.Loads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        BeamId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Main.Beams", t => t.BeamId, cascadeDelete: true)
                .Index(t => t.BeamId);
            
            CreateTable(
                "Main.Calculations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Result = c.Double(nullable: false),
                        LoadId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Management.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Main.Loads", t => t.LoadId, cascadeDelete: true)
                .ForeignKey("Main.Units", t => t.UnitId)
                .Index(t => t.LoadId)
                .Index(t => t.UserId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "Management.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20, unicode: false),
                        Password = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        Title = c.String(maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 20, unicode: false),
                        Surname = c.String(maxLength: 30, unicode: false),
                        LastLogin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "Management.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "Main.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Display = c.String(nullable: false, maxLength: 10),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Main.Variables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        Display = c.String(nullable: false, maxLength: 10, unicode: false),
                        Value = c.Double(nullable: false),
                        CalculationId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Main.Calculations", t => t.CalculationId, cascadeDelete: true)
                .ForeignKey("Main.Units", t => t.UnitId)
                .Index(t => t.CalculationId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "Intersections.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("Management.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Management.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Main.Calculations", "UnitId", "Main.Units");
            DropForeignKey("Main.Variables", "UnitId", "Main.Units");
            DropForeignKey("Main.Variables", "CalculationId", "Main.Calculations");
            DropForeignKey("Main.Calculations", "LoadId", "Main.Loads");
            DropForeignKey("Main.Calculations", "UserId", "Management.Users");
            DropForeignKey("Intersections.UserRoles", "UserId", "Management.Users");
            DropForeignKey("Intersections.UserRoles", "RoleId", "Management.Roles");
            DropForeignKey("Main.Loads", "BeamId", "Main.Beams");
            DropIndex("Intersections.UserRoles", new[] { "UserId" });
            DropIndex("Intersections.UserRoles", new[] { "RoleId" });
            DropIndex("Main.Variables", new[] { "UnitId" });
            DropIndex("Main.Variables", new[] { "CalculationId" });
            DropIndex("Management.Roles", new[] { "Name" });
            DropIndex("Management.Users", new[] { "Username" });
            DropIndex("Main.Calculations", new[] { "UnitId" });
            DropIndex("Main.Calculations", new[] { "UserId" });
            DropIndex("Main.Calculations", new[] { "LoadId" });
            DropIndex("Main.Loads", new[] { "BeamId" });
            DropTable("Intersections.UserRoles");
            DropTable("Main.Variables");
            DropTable("Main.Units");
            DropTable("Management.Roles");
            DropTable("Management.Users");
            DropTable("Main.Calculations");
            DropTable("Main.Loads");
            DropTable("Main.Beams");
        }
    }
}
