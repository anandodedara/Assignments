namespace SourceControl_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotation1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "RePassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "RePassword", c => c.String());
        }
    }
}
