﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ApiResponseConvenrters
{
	public interface IApiResponseConverter
	{
		Weather Convert(string sResponse);
	}
}
