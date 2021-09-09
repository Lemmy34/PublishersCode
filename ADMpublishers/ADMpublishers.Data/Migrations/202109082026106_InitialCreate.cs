namespace ADMpublishers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        au_id = c.String(nullable: false, maxLength: 128),
                        au_lname = c.String(),
                        au_fname = c.String(),
                        phone = c.String(),
                        address = c.String(),
                        cityID = c.Int(nullable: false),
                        zip = c.String(),
                        contract = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.au_id)
                .ForeignKey("dbo.City", t => t.cityID, cascadeDelete: true)
                .Index(t => t.cityID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        timestamp = c.DateTime(nullable: false),
                        stateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.stateID, cascadeDelete: true)
                .Index(t => t.stateID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Author", "cityID", "dbo.City");
            DropForeignKey("dbo.City", "stateID", "dbo.State");
            DropIndex("dbo.City", new[] { "stateID" });
            DropIndex("dbo.Author", new[] { "cityID" });
            DropTable("dbo.State");
            DropTable("dbo.City");
            DropTable("dbo.Author");
        }
    }
}
