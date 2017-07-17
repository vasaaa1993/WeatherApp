using NUnit.Framework;
using WeatherApp.DataAccess.Entities;
using WeatherApp.Models;
using WeatherApp.Services.Data;

namespace WeatherApp.Tests
{
	[TestFixture]
	class EntityFrameworkDataRepositoryTestsConvertion
	{
		[Test]
		public void CityDb2City_When_Invalid_parameters_passed_Then_return_null()
		{
			// Act
			var result = EntityFrameworkDataService.CityDb2City(null);

			//Assert
			Assert.AreEqual(null, result);
		}


		[Test]
		[TestCase(1, "Paris")]
		[TestCase(0, "")]
		public void CityDb2City_When_Valid_parameters_passed_Then_return_City(int id, string name)
		{
			// Act
			var result = EntityFrameworkDataService.CityDb2City(new CityDb(){Id = id, Name = name });

			//Assert
			Assert.IsInstanceOf<City>(result);
		}

		[Test]
		public void WeatherDb2Weather_When_Valid_parameters_passed_Then_return_Weather()
		{
			// Act
			var result1 = EntityFrameworkDataService.WeatherDb2Wearter(new WeatherDb());
			
			//Assert
			Assert.IsInstanceOf<Weather>(result1);
		}

		[Test]
		public void WeatherDb2Weather_When_Invalid_parameters_passed_Then_return_null()
		{
			// Act
			var result = EntityFrameworkDataService.WeatherDb2Wearter(null);

			//Assert
			Assert.AreEqual(null, result);
		}
	}
}
