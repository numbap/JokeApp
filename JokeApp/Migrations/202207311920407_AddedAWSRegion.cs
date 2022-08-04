namespace JokeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAWSRegion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "AwsRegion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "AwsRegion");
        }
    }
}
