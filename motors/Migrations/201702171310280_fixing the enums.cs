namespace motors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingtheenums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Transmisson", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "FuelType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "FuelType", c => c.String());
            AlterColumn("dbo.Cars", "Transmisson", c => c.String());
        }
    }
}
