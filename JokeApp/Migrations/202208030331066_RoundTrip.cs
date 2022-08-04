namespace JokeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoundTrip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisionLabels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "vl_Id", c => c.Int());
            CreateIndex("dbo.Images", "vl_Id");
            AddForeignKey("dbo.Images", "vl_Id", "dbo.VisionLabels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "vl_Id", "dbo.VisionLabels");
            DropIndex("dbo.Images", new[] { "vl_Id" });
            DropColumn("dbo.Images", "vl_Id");
            DropTable("dbo.VisionLabels");
        }
    }
}
