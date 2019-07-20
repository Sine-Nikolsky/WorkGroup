namespace WorkGroup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        Number = c.String(),
                        WorkingHour = c.Double(nullable: false),
                        Applicability = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                        GroupItem_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupItems", t => t.GroupItem_Id)
                .Index(t => t.GroupItem_Id);
            
            CreateTable(
                "dbo.GroupItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                        Group_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProducedDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProducedDate = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                        Detail_Id = c.Guid(),
                        Worker_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.Detail_Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Detail_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 150),
                        PersonalNumber = c.Int(nullable: false),
                        DismissedDate = c.DateTime(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProducedDetails", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.ProducedDetails", "Detail_Id", "dbo.Details");
            DropForeignKey("dbo.Details", "GroupItem_Id", "dbo.GroupItems");
            DropForeignKey("dbo.GroupItems", "Group_Id", "dbo.Groups");
            DropIndex("dbo.ProducedDetails", new[] { "Worker_Id" });
            DropIndex("dbo.ProducedDetails", new[] { "Detail_Id" });
            DropIndex("dbo.GroupItems", new[] { "Group_Id" });
            DropIndex("dbo.Details", new[] { "GroupItem_Id" });
            DropTable("dbo.Workers");
            DropTable("dbo.ProducedDetails");
            DropTable("dbo.Groups");
            DropTable("dbo.GroupItems");
            DropTable("dbo.Details");
        }
    }
}
