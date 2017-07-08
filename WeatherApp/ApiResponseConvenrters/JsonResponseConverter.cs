using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models;

namespace WeatherApp.ApiResponseConvenrters
{
	public class JsonResponseConverter : IApiResponseConverter
	{
		public Weather Convert(string sResponse)
		{
			return JsonConvert.DeserializeObject<Weather>(sResponse);
		}
	}
}