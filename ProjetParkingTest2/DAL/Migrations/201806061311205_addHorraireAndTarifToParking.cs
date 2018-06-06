namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHorraireAndTarifToParking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parkings", "Horraire", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parkings", "Horraire");
        }
    }
}
