using NUnit.Framework;
using WeatherApp.ApiResponseConvenrters;
using WeatherApp.Models;

namespace WeatherApp.Tests
{
	[TestFixture]
	class JsonResponseConverterTest
	{

		[Test]
		[TestCase("", ExpectedResult = null)]
		[TestCase(null, ExpectedResult = null)]
		public Weather Conver_When_Invalid_parameters_passed_Then_return_Null(string sRespone)
		{
			//Arrange
			var converter = new JsonResponseConverter();
			//Act
			return converter.Convert(sRespone);
		}
		[Test]
		[TestCase("{\"city\":{\"id\":702550,\"name\":\"Lviv\",\"coord\":{\"lon\":24.0232,\"lat\":49.8383},\"country\":\"UA\",\"population\":0},\"cod\":\"200\",\"message\":0.4572069,\"cnt\":1,\"list\":[{\"dt\":1499940000,\"temp\":{\"day\":13,\"min\":11.26,\"max\":13,\"night\":12.35,\"eve\":11.26,\"morn\":13},\"pressure\":989.92,\"humidity\":92,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"speed\":11.62,\"deg\":290,\"clouds\":92,\"rain\":1.35}]}")]
		public void Conver_When_Valid_parameters_passed_Then_return_Weather(string sRespone)
		{
			// Arrange
			var converter = new JsonResponseConverter();
			
			// Act
			var result = converter.Convert(sRespone);
			
			//Assert
			Assert.IsInstanceOf<Weather>(result);
		}
	}
}
