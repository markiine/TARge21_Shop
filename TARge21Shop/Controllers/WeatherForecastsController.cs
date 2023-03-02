using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastsServices;

        public WeatherForecastsController
            (
                IWeatherForecastsServices weatherForecastsServices
            )
        {
            _weatherForecastsServices = weatherForecastsServices;
        }
        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();

            return View();
        }
    }
}
