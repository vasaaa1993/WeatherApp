using System.Data.Common;
using System.Linq;
using NUnit.Framework;
using WeatherApp.DataAccess;
using WeatherApp.Models;

namespace WeatherApp.Tests
{
	[TestFixture]
	class EntityFrameworkDataRepositoryIntigrationTests
	{
		private DbConnection connection;
		EntityFrameworkContext context;
		private EntityFrameworkDataRepository repo;

		[SetUp]
		public  void Initialize()
		{
			connection = Effort.DbConnectionFactory.CreateTransient();
			context = new EntityFrameworkContext(connection);
			repo = new EntityFrameworkDataRepository(context);
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
		public void AddCity_When_Invalid_parameters_passed_Then_city_wasnt_Added(string sCityName)
		{
			// Arrange
			// Act
			repo.AddCity(sCityName);
			
			//Assert
			Assert.AreEqual(0, repo.GetAllCities().Count());
		}

		[Test]
		[TestCase("London", "Kiev")]
		[TestCase("Paris, Berlin")]
		[TestCase("Vakanda")]
		public void AddCity_When_Valid_parameters_passed_Then_cites_was_Added(params string[] cities)
		{
			// Arrange
			// Act
			foreach (var city in cities)
			{
				repo.AddCity(city);
			}
			
			//Assert
			Assert.AreEqual(cities.Length, repo.GetAllCities().Count());
		}

		[Test]
		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(2)]
		public void DeleteCityById_When_Input_parameters_invalid_Then_do_Nothing(int nId)
		{
			// Arrange
			repo.AddCity("Termopil");
			
			// Act
			repo.DeleteCityById(nId);
			
			//Assert
			Assert.AreEqual(1, repo.GetAllCities().Count());

		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void DeleteCityById_When_Input_parameters_valid_Then_delete_city(int nId)
		{
			// Arrange
			repo.AddCity("Termopil");
			repo.AddCity("Lviv");
			repo.AddCity("Madrid");

			// Act
			repo.DeleteCityById(nId);

			//Assert
			Assert.AreEqual(2, repo.GetAllCities().Count());

		}

		[Test]
		public void ClearHistory_Test()
		{
			// Arrange
			repo.AddResponseToHistory(new Weather());
			repo.AddResponseToHistory(new Weather());

			// Act
			repo.ClearHistory();

			//Assert
			Assert.AreEqual(0, repo.GetAllCities().Count());
		}
	}
}
