namespace motors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingobjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Mileage = c.Int(nullable: false),
                        Year = c.DateTime(),
                        Transmisson = c.String(),
                        Condition = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        FuelType = c.String(),
                        DateUploaded = c.DateTime(nullable: false),
                        Location = c.String(),
                        Lable = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CarDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        DateUploaded = c.DateTime(nullable: false),
                        Car_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarPictures", "Car_Id", "dbo.Cars");
            DropIndex("dbo.CarPictures", new[] { "Car_Id" });
            DropTable("dbo.CarPictures");
            DropTable("dbo.Cars");
            DropTable("dbo.CarApplications");
        }
    }
}
