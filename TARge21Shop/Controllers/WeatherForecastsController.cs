using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto.WeatherDtos;
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

        [HttpPost]
        public IActionResult ShowWeather(WeatherViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }

            return View(vm);
        }        
        
        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new();
            WeatherViewModel vm = new();

            _weatherForecastsServices.WeatherDetail(dto);

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.Category = dto.Category;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;


            vm.Temperature.Maximum.Value = dto.MaximumValue;
            vm.Temperature.Maximum.Unit = dto.MaximumUnit;
            vm.Temperature.Maximum.UnitType = dto.MaximumUnitType;

            vm.Temperature.Minimum.Value = dto.MinimumValue;
            vm.Temperature.Minimum.Unit = dto.MinimumUnit;
            vm.Temperature.Minimum.UnitType = dto.MinimumUnitType;

            return View();
        }

    }
}
