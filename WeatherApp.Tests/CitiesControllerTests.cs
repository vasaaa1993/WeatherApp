using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WeatherApp.Controllers;
using WeatherApp.DataAccess;
using WeatherApp.DataAccess.Contexts;
using WeatherApp.Models;
using WeatherApp.Services.Data;

namespace WeatherApp.Tests
{
	[TestFixture]
	public class CitiesControllerTests
	{
		[Test]
		public void IndexMethod_Return_ViewResult_With_ListOfCiriesModel_When_RepoReturnValidData()
		{
			//Arrange
			var repoMock = new Mock<IDataService>();
			repoMock.Setup(m => m.GetAllCities()).Returns(new List<City>()
			{
				new City(){Id = 1,Name = "London"},
				new City(){Id = 2, Name = "Paris"},
				new City(){Id = 3, Name = "Lviv"},
				new City(){Id = 4, Name = "Odessa"},
			});
			var cityController = new CitiesController(repoMock.Object);
			
			//Act
			var result = cityController.Index();

			//Asserts
			Assert.IsInstanceOf<ViewResult>(result);
			Assert.IsInstanceOf<IEnumerable<City>>(((ViewResult) result).ViewData.Model);
		}

		//Intigration tests
		private DbConnection _connection;
		private EntityFrameworkContext _context;
		private EntityFrameworkDataService _service;
		private CitiesController _controller;

		[SetUp]
		public void InitTests()
		{
			_connection = Effort.DbConnectionFactory.CreateTransient();
			_context = new EntityFrameworkContext(_connection);
			_service = new EntityFrameworkDataService(new RepositoriesUnitOfWork(_context));
			_controller = new CitiesController(_service);
		}

		[TearDown]
		public void TearDownTests()
		{
			_controller.Dispose();
			_context.Dispose();
			_connection.Dispose();

		}

		[Test]
		public void Index_Return_view_Model_with_List_of_3_items()
		{
			//Arrage
			_service.AddCity("London");
			_service.AddCity("Lviv");
			_service.AddCity("Kiev");

			//Act
			var result = _controller.Index();
			//Assert

			Assert.IsInstanceOf<ViewResult>(result);
			var vm = (ViewResult) result;
			Assert.IsInstanceOf<IEnumerable<City>>(vm.Model);
			Assert.AreEqual(3, ((IEnumerable<City>)vm.Model).Count());

		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Delete_When_Input_param_valid_Then_delete_item(int nId)
		{
			//Arrage
			_service.AddCity("London");
			_service.AddCity("Lviv");
			_service.AddCity("Kiev");

			//Act
			var result = _controller.Delete(nId);
			
			//Assert
			Assert.AreEqual(2, _service.GetAllCities().Count());

		}

		[Test]
		[TestCase(0)]
		[TestCase(5)]
		[TestCase(12)]
		public void Delete_When_Input_param_Invalid_Then_dont_delete_any_item(int nId)
		{
			//Arrage
			_service.AddCity("London");
			_service.AddCity("Lviv");
			_service.AddCity("Kiev");

			//Act
			var result = _controller.Delete(nId);
			
			//Assert
			Assert.AreEqual(3, _service.GetAllCities().Count());
		}

		[Test]
		[TestCase("London")]
		[TestCase("Paris")]
		[TestCase("Odessa")]
		public void Add_When_Input_param_valid_Then_add_new_item(string name)
		{
			//Arrage
			//Act
			var result = _controller.Add(name);
			
			//Assert
			Assert.AreEqual(1, _service.GetAllCities().Count());

		}

		[Test]
		[TestCase("")]
		[TestCase(null)]
		public void Add_When_Input_param_invalid_Then_dont_add_new_item(string name)
		{
			//Arrage
			//Act
			var result = _controller.Add(name);

			//Assert
			Assert.AreEqual(0, _service.GetAllCities().Count());

		}
	}
}
