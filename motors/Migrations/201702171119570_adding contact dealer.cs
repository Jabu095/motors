namespace motors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingcontactdealer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactdealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Car_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contactdealers", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Contactdealers", new[] { "Car_Id" });
            DropTable("dbo.Contactdealers");
        }
    }
}
