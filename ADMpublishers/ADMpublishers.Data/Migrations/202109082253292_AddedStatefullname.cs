namespace ADMpublishers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatefullname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.State", "fullname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.State", "fullname");
        }
    }
}
