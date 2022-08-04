namespace JokeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageAwsUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "AwsUrl", c => c.String());
            DropColumn("dbo.Images", "url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "url", c => c.String());
            DropColumn("dbo.Images", "AwsUrl");
        }
    }
}
