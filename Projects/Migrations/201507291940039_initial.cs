namespace Projects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ReporedAt = c.DateTime(nullable: false),
                        EditedAt = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        EditedBy_Id = c.String(maxLength: 128),
                        Project_Id = c.Int(nullable: false),
                        ReportedBy_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EditedBy_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ReportedBy_Id, cascadeDelete: true)
                .Index(t => t.EditedBy_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.ReportedBy_Id);
            
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        WikiName = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        AdmininstratorId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeLogs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Published = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.FileReleases", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.FileReleases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Version = c.String(nullable: false),
                        Published = c.DateTime(nullable: false),
                        content = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.ProjectFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleaseId = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        FileName = c.String(nullable: false),
                        Path = c.String(nullable: false),
                        FileType_Id = c.Int(),
                        Owner_Id = c.String(maxLength: 128),
                        Project_Id = c.Int(nullable: false),
                        FileReleases_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileTypes", t => t.FileType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.FileReleases", t => t.FileReleases_Id)
                .Index(t => t.FileType_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.FileReleases_Id);
            
           
            
            CreateTable(
                "dbo.ProjectNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Title = c.String(),
                        Published = c.DateTime(nullable: false),
                        content = c.String(),
                        Author_Id = c.String(maxLength: 128),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Project_Id);
            
          
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Bugs", "ReportedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bugs", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Tags", "ProjectNews_Id", "dbo.ProjectNews");
            DropForeignKey("dbo.ProjectNews", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Categories", "ProjectNews_Id", "dbo.ProjectNews");
            DropForeignKey("dbo.ProjectNews", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ChangeLogs", "Id", "dbo.FileReleases");
            DropForeignKey("dbo.AspNetUsers", "FileReleases_Id", "dbo.FileReleases");
            DropForeignKey("dbo.FileReleases", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectFiles", "FileReleases_Id", "dbo.FileReleases");
            DropForeignKey("dbo.ProjectFiles", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectFiles", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectFiles", "FileType_Id", "dbo.FileTypes");
            DropForeignKey("dbo.ChangeLogs", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Bugs", "EditedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tags", new[] { "ProjectNews_Id" });
            DropIndex("dbo.Categories", new[] { "ProjectNews_Id" });
            DropIndex("dbo.ProjectNews", new[] { "Project_Id" });
            DropIndex("dbo.ProjectNews", new[] { "Author_Id" });
            DropIndex("dbo.ProjectFiles", new[] { "FileReleases_Id" });
            DropIndex("dbo.ProjectFiles", new[] { "Project_Id" });
            DropIndex("dbo.ProjectFiles", new[] { "Owner_Id" });
            DropIndex("dbo.ProjectFiles", new[] { "FileType_Id" });
            DropIndex("dbo.FileReleases", new[] { "Project_Id" });
            DropIndex("dbo.ChangeLogs", new[] { "Project_Id" });
            DropIndex("dbo.ChangeLogs", new[] { "Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "FileReleases_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Bugs", new[] { "ReportedBy_Id" });
            DropIndex("dbo.Bugs", new[] { "Project_Id" });
            DropIndex("dbo.Bugs", new[] { "EditedBy_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Plugins");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.ProjectNews");
            DropTable("dbo.FileTypes");
            DropTable("dbo.ProjectFiles");
            DropTable("dbo.FileReleases");
            DropTable("dbo.ChangeLogs");
            DropTable("dbo.Projects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Bugs");
        }
    }
}
