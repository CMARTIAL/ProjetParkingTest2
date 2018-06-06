namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBoolToAdresse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adresses", "IsParking", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adresses", "IsParking");
        }
    }
}
