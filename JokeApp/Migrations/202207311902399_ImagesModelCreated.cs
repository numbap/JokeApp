namespace JokeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagesModelCreated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Jokes", newName: "Images");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Images", newName: "Jokes");
        }
    }
}
