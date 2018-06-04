namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Evenement_Id", "dbo.Evenements");
            DropIndex("dbo.Images", new[] { "Evenement_Id" });
            AddColumn("dbo.Evenements", "ImageEvenement_Id", c => c.Guid());
            CreateIndex("dbo.Evenements", "ImageEvenement_Id");
            AddForeignKey("dbo.Evenements", "ImageEvenement_Id", "dbo.Images", "Id");
            DropColumn("dbo.Images", "Evenement_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Evenement_Id", c => c.Guid());
            DropForeignKey("dbo.Evenements", "ImageEvenement_Id", "dbo.Images");
            DropIndex("dbo.Evenements", new[] { "ImageEvenement_Id" });
            DropColumn("dbo.Evenements", "ImageEvenement_Id");
            CreateIndex("dbo.Images", "Evenement_Id");
            AddForeignKey("dbo.Images", "Evenement_Id", "dbo.Evenements", "Id");
        }
    }
}
