using System.Data.Common;
using System.Linq;
using NUnit.Framework;
using WeatherApp.DataAccess;
using WeatherApp.DataAccess.Contexts;
using WeatherApp.Models;
using WeatherApp.Services.Data;

namespace WeatherApp.Tests
{
	[TestFixture]
	class EntityFrameworkDataRepositoryTestsDb
	{
		private DbConnection connection;
		private EntityFrameworkContext context;
		private EntityFrameworkDataService dataService;

		[SetUp]
		public  void Initialize()
		{
			connection = Effort.DbConnectionFactory.CreateTransient();
			context = new EntityFrameworkContext(connection);
			dataService = new EntityFrameworkDataService(new RepositoriesUnitOfWork(context));
		}

		[TearDown]
		public void TestTearDown()
		{
			context.Dispose();
			connection.Dispose();
		}
		[Test]
		[TestCase(null)]
		[TestCase("")]
		public async void AddCity_When_Invalid_parameters_passed_Then_city_wasnt_Added(string sCityName)
		{
			// Arrange
			// Act
			await dataService.AddCity(sCityName);
			
			//Assert
			Assert.AreEqual(0, (await dataService.GetAllCities()).Count());
		}

		[Test]
		[TestCase("London", "Kiev")]
		[TestCase("Paris, Berlin")]
		[TestCase("Vakanda")]
		public async void AddCity_When_Valid_parameters_passed_Then_cites_was_Added(params string[] cities)
		{
			// Arrange
			// Act
			foreach (var city in cities)
			{
				await dataService.AddCity(city);
			}
			
			//Assert
			Assert.AreEqual(cities.Length, (await dataService.GetAllCities()).Count());
		}

		[Test]
		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(2)]
		public async void DeleteCityById_When_Input_parameters_invalid_Then_do_Nothing(int nId)
		{
			// Arrange
			await dataService.AddCity("Termopil");

			// Act
			await dataService.DeleteCity(nId);
			
			//Assert
			Assert.AreEqual(1, (await dataService.GetAllCities()).Count());

		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public async void DeleteCityById_When_Input_parameters_valid_Then_delete_city(int nId)
		{
			// Arrange
			await dataService.AddCity("Termopil");
			await dataService.AddCity("Lviv");
			await dataService.AddCity("Madrid");

			// Act
			await dataService.DeleteCity(nId);

			//Assert
			Assert.AreEqual(2, (await dataService.GetAllCities()).Count());

		}

		[Test]
		public async void ClearHistory_Test()
		{
			// Arrange
			await dataService.AddResponseToHistory(new Weather());
			await dataService.AddResponseToHistory(new Weather());

			// Act
			await dataService.ClearHistory();

			//Assert
			Assert.AreEqual(0, (await dataService.GetAllCities()).Count());
		}
	}
}
