namespace Clay3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpenRecords", "UserName", c => c.String());
            DropColumn("dbo.OpenRecords", "KeyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpenRecords", "KeyId", c => c.Guid(nullable: false));
            DropColumn("dbo.OpenRecords", "UserName");
        }
    }
}
