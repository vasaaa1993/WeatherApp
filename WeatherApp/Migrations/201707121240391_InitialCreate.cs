using System.Data.Entity.Migrations;

namespace WeatherApp.Migrations
{
	public partial class InitialCreate : DbMigration
	{
		public override void Up()
		{
			CreateTable(
					"dbo.Cities",
					c => new
					{
						Id = c.Int(false, true),
						Name = c.String(maxLength: 50)
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
					"dbo.History",
					c => new
					{
						Id = c.Int(false, true),
						Time = c.DateTime(false, 7, storeType: "datetime2")
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
					"dbo.Weather",
					c => new
					{
						Id = c.Int(false),
						Time = c.DateTime(false),
						MinTemp = c.Double(false),
						MaxTemp = c.Double(false),
						DayTemp = c.Double(false),
						City = c.String(maxLength: 30),
						Country = c.String(maxLength: 10),
						Description = c.String(maxLength: 30),
						Humidity = c.Double(false),
						Pressure = c.Double(false),
						Clouds = c.Int(false),
						WindSpeed = c.Double(false),
						Icon = c.String(maxLength: 20),
						StudentId = c.Int(false)
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.History", t => t.Id)
				.Index(t => t.Id);
		}

		public override void Down()
		{
			DropForeignKey("dbo.Weather", "Id", "dbo.History");
			DropIndex("dbo.Weather", new[] {"Id"});
			DropTable("dbo.Weather");
			DropTable("dbo.History");
			DropTable("dbo.Cities");
		}
	}
}