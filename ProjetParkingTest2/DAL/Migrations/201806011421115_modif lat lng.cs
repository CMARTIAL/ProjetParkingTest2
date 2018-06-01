namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modiflatlng : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adresses", "lat", c => c.Double());
            AlterColumn("dbo.Adresses", "lng", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adresses", "lng", c => c.Double(nullable: false));
            AlterColumn("dbo.Adresses", "lat", c => c.Double(nullable: false));
        }
    }
}
