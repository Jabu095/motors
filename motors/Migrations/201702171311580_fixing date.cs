namespace motors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "DateUploaded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "DateUploaded", c => c.DateTime(nullable: false));
        }
    }
}
