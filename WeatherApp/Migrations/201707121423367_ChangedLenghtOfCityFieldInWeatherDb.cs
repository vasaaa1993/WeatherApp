using System.Data.Entity.Migrations;

namespace WeatherApp.Migrations
{
	public partial class ChangedLenghtOfCityFieldInWeatherDb : DbMigration
	{
		public override void Up()
		{
			AlterColumn("dbo.Weather", "City", c => c.String(maxLength: 50));
		}

		public override void Down()
		{
			AlterColumn("dbo.Weather", "City", c => c.String(maxLength: 30));
		}
	}
}