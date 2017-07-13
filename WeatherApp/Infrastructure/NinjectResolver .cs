using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using WeatherApp.ApiResponseConvenrters;
using WeatherApp.DataAccess;
using WeatherApp.Services;

namespace WeatherApp.Infrastructure
{
	public class NinjectResolver : IDependencyResolver
	{
		private readonly IKernel kernel;

		public NinjectResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			AddBindings();
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}

		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}

		private void AddBindings()
		{
			kernel.Bind<IWeatherService>().To<OpenWeatherService>();
			kernel.Bind<IApiResponseConverter>().To<JsonResponseConverter>();
			kernel.Bind<IDataRepository>().To<EntityFrameworkDataRepository>().InThreadScope();
		}
	}
}