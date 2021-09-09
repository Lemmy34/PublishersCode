namespace ADMpublishers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "timestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Author", "timestamp");
        }
    }
}
