namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutlatlng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adresses", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Adresses", "lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adresses", "lng");
            DropColumn("dbo.Adresses", "lat");
        }
    }
}
