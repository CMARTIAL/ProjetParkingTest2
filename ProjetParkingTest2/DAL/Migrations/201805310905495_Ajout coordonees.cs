namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajoutcoordonees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parkings", "Coordonee0", c => c.Double(nullable: false));
            AddColumn("dbo.Parkings", "Coordonee1", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parkings", "Coordonee1");
            DropColumn("dbo.Parkings", "Coordonee0");
        }
    }
}
