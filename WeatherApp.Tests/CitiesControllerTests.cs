using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
		[Test]
		public void IndexMethod_Return_ViewResult_With_ListOfCiriesModel_When_RepoReturnValidData()
		{
			//Arrange
			var _repoMock = new Mock<IDataRepository>();
			_repoMock.Setup(m => m.GetAllCities()).Returns(new List<City>()
			{
				new City(){Id = 1,Name = "London"},
				new City(){Id = 2, Name = "Paris"},
				new City(){Id = 3, Name = "Lviv"},
				new City(){Id = 4, Name = "Odessa"},
			});
			var cityController = new CitiesController(_repoMock.Object);
			
			//Act
			var result = cityController.Index();

			//Asserts
			Assert.IsInstanceOf<ViewResult>(result);
			Assert.IsInstanceOf<IEnumerable<City>>(((ViewResult) result).ViewData.Model);
		}

		//Intigration tests
		private DbConnection connection;
		private EntityFrameworkContext context;
		private EntityFrameworkDataRepository repo;
		private CitiesController controller;

		[SetUp]
		public void InitTests()
		{
			connection = Effort.DbConnectionFactory.CreateTransient();
			context = new EntityFrameworkContext(connection);
			repo = new EntityFrameworkDataRepository(context);
			controller = new CitiesController(repo);
		}
		
		[TearDown]
		public void TearDownTests()
		{
			controller.Dispose();
			context.Dispose();
			connection.Dispose();

		}

		[Test]
		public void Index_Return_view_Model_with_List_of_3_items()
		{
			//Arrage
			repo.AddCity("London");
			repo.AddCity("Lviv");
			repo.AddCity("Kiev");

			//Act
			var result = controller.Index();
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
			repo.AddCity("London");
			repo.AddCity("Lviv");
			repo.AddCity("Kiev");

			//Act
			var result = controller.Delete(nId);
			
			//Assert
			Assert.AreEqual(2, repo.GetAllCities().Count());

		}

		[Test]
		[TestCase(0)]
		[TestCase(5)]
		[TestCase(12)]
		public void Delete_When_Input_param_Invalid_Then_dont_delete_any_item(int nId)
		{
			//Arrage
			repo.AddCity("London");
			repo.AddCity("Lviv");
			repo.AddCity("Kiev");

			//Act
			var result = controller.Delete(nId);
			
			//Assert
			Assert.AreEqual(3,repo.GetAllCities().Count());
		}

		[Test]
		[TestCase("London")]
		[TestCase("Paris")]
		[TestCase("Odessa")]
		public void Add_When_Input_param_valid_Then_add_new_item(string name)
		{
			//Arrage
			//Act
			var result = controller.Add(name);
			
			//Assert
			Assert.AreEqual(1, repo.GetAllCities().Count());

		}

		[Test]
		[TestCase("")]
		[TestCase(null)]
		public void Add_When_Input_param_invalid_Then_dont_add_new_item(string name)
		{
			//Arrage
			//Act
			var result = controller.Add(name);

			//Assert
			Assert.AreEqual(0, repo.GetAllCities().Count());

		}
	}
}
