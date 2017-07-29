using System;
using Windows.UI.Xaml.Data;

namespace UwpWeatherClient.Converters
{
	class WeatherIconPathConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return "/Assets/WeatherIcons/" + value.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
