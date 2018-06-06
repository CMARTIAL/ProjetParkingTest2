namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTarifsParking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parkings", "Tarif", c => c.String());
            DropColumn("dbo.Parkings", "HeureOuverture");
            DropColumn("dbo.Parkings", "HeureFermeture");
            DropColumn("dbo.Parkings", "Coordonee0");
            DropColumn("dbo.Parkings", "Coordonee1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parkings", "Coordonee1", c => c.Double(nullable: false));
            AddColumn("dbo.Parkings", "Coordonee0", c => c.Double(nullable: false));
            AddColumn("dbo.Parkings", "HeureFermeture", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Parkings", "HeureOuverture", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Parkings", "Tarif", c => c.Int(nullable: false));
        }
    }
}
