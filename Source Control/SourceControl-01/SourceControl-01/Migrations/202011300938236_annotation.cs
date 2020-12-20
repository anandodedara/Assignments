namespace SourceControl_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Password = c.String(maxLength: 15),
                        RePassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
