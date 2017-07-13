using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WeatherApp.Controllers;
using WeatherApp.DataAccess;
using WeatherApp.Models;

namespace WeatherApp.Tests
{
	[TestFixture]
	public class CitiesControllerTests
	{
		Mock<IDataRepository> _repoMock;// = new Mock<IDataRepository>();
		[SetUp]
		public void Init()
		{
			_repoMock = new Mock<IDataRepository>();
			_repoMock.Setup(m => m.GetAllCities()).Returns(new List<City>()
			{
				new City(){Id = 1,Name = "London"},
				new City(){Id = 2, Name = "Paris"},
				new City(){Id = 3, Name = "Lviv"},
				new City(){Id = 4, Name = "Odessa"},
			});
		}

		[Test]
		public void IndexMethod_Return_ViewResult_With_ListOfCiriesModel_When_RepoReturnValidData()
		{
			//Arrange
			var cityController = new CitiesController(_repoMock.Object);
			
			//Act
			var result = cityController.Index();

			//Asserts
			Assert.IsInstanceOf<ViewResult>(result);
			Assert.IsInstanceOf<IEnumerable<City>>(((ViewResult) result).ViewData.Model);

		}
	}
}
