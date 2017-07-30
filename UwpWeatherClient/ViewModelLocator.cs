using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UwpWeatherClient.Services;
using UwpWeatherClient.ViewModels;
using UwpWeatherClient.Views;

namespace UwpWeatherClient
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary> 
	public class ViewModelLocator
	{
		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (ViewModelBase.IsInDesignModeStatic)
			{
				// Create design time view services and models
			}
			else
			{
				// Create run time view services and models
			}

			//Register your services used here
			SimpleIoc.Default.Register<INavigationService, NavigationService>();

			// Register services 
			SimpleIoc.Default.Register<IWeatherService, WeatherService>();
			SimpleIoc.Default.Register<IHistoryService, HistoryService>();
			SimpleIoc.Default.Register<ICitiesService, CitiesService>();

			SimpleIoc.Default.Register<WeatherViewModel>();
			SimpleIoc.Default.Register<CitiesViewModel>();
			SimpleIoc.Default.Register<HistoryViewModel>();

		}

		// <summary>
		// Gets the History view model.
		// </summary>
		// <value>
		// The History view model.
		// </value>
		public HistoryViewModel HistoryVMInstance
		{
			get
			{
				return ServiceLocator.Current.GetInstance<HistoryViewModel>();
			}
		}

		// <summary>
		// Gets the Weather view model.
		// </summary>
		// <value>
		// The Weather view model.
		// </value>
		public WeatherViewModel WeatherVMInstance
		{
			get
			{
				return ServiceLocator.Current.GetInstance<WeatherViewModel>();
			}
		}

		// <summary>
		// Gets the Cities view model.
		// </summary>
		// <value>
		// The Cities view model.
		// </value>
		public CitiesViewModel CitiesVWInstance
		{
			get
			{
				return ServiceLocator.Current.GetInstance<CitiesViewModel>();
			}
		}

		// <summary>
		// The cleanup.
		// </summary>
		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}

}