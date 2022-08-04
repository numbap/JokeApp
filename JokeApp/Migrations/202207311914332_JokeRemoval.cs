namespace JokeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JokeRemoval : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "JokeQuestion");
            DropColumn("dbo.Images", "JokeAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "JokeAnswer", c => c.String());
            AddColumn("dbo.Images", "JokeQuestion", c => c.String());
        }
    }
}
