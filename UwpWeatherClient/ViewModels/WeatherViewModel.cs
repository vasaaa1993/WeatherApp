using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpWeatherClient.Models;
using UwpWeatherClient.Services;
/*
private Academy _academy;
private INavigationService _navigationService;

public AcademyViewModel(INavigationService navigationService)
{
_academy = new Academy();
_navigationService = navigationService;

Title = "Academy";
SearchCommand = new RelayCommand(search);
SearchFilter = "";
Students = new ObservableCollection<Student>();
search();
}

private string _searchFilter;
public string SearchFilter
{
get { return _searchFilter; }
set
{
_searchFilter = value;
RaisePropertyChanged(() => SearchFilter);
}
}

public ObservableCollection<Student> Students { get; private set; }

private Student _selectedStudent;
public Student SelectedStudent
{
get { return _selectedStudent; }
set
{
_selectedStudent = value;
if (_selectedStudent != null)
{
MessengerInstance.Send(_selectedStudent);
_navigationService.NavigateTo(nameof(StudentViewModel));
}

RaisePropertyChanged(() => SelectedStudent);
}
}

public ICommand SearchCommand { get; set; }

private void search()
{
Students.Clear();
if (string.IsNullOrWhiteSpace(SearchFilter))
{
foreach (var student in _academy.GetAllStudents())
{
Students.Add(student);
}
}
else
{
foreach (var student in _academy.GetByStudentName(SearchFilter))
{
Students.Add(student);
}
foreach (var student in _academy.GetByStudentCity(SearchFilter))
{
Students.Add(student);
}
}
}
}
*/
namespace UwpWeatherClient.ViewModels
{
	public class WeatherViewModel : BaseViewModel
	{
		private INavigationService _navigationService;
		private IWeatherService _weatherService;
		private ICitiesService _citiesService;

		public Weather Weather { get; private set; }
		public ObservableCollection<City> Cities { get; private set; }

		public WeatherViewModel(INavigationService navigationService, 
			IWeatherService weatherService, 
			ICitiesService citiesService)
		{
			_navigationService = navigationService;
			_citiesService = citiesService;
			_weatherService = weatherService;

			Cities = new ObservableCollection<City>();
			//GetWeather();
		}

		//private async void GetWeather()
		//{
		//	var ser = new CitiesService();
		//	var rez = await ser.AddCity(new City() { Name = "Pop" });
		//	var w = await _weatherService.GetWeather("London", 7);
		//	if(w != null)
		//	{
		//		Weather = w;
		//		RaisePropertyChanged(() => Weather);
		//	}
		//}
	}
}
