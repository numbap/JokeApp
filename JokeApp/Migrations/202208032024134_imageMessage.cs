namespace JokeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Message");
        }
    }
}
