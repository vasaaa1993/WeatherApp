namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.History",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Weather",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        MinTemp = c.Double(nullable: false),
                        MaxTemp = c.Double(nullable: false),
                        DayTemp = c.Double(nullable: false),
                        City = c.String(maxLength: 30),
                        Country = c.String(maxLength: 10),
                        Description = c.String(maxLength: 30),
                        Humidity = c.Double(nullable: false),
                        Pressure = c.Double(nullable: false),
                        Clouds = c.Int(nullable: false),
                        WindSpeed = c.Double(nullable: false),
                        Icon = c.String(maxLength: 20),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.History", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weather", "Id", "dbo.History");
            DropIndex("dbo.Weather", new[] { "Id" });
            DropTable("dbo.Weather");
            DropTable("dbo.History");
            DropTable("dbo.Cities");
        }
    }
}
