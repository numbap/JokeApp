namespace JokeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "url");
        }
    }
}
