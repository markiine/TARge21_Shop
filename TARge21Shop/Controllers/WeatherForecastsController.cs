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

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }

            return View();
        }        
        
        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new WeatherResultDto();
            WeatherViewModel vm = new WeatherViewModel();

            _weatherForecastsServices.WeatherDetail(dto);

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.Category = dto.Category;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;

            vm.Temperature = new Temperatures();

            vm.Temperature.Maximum = new Models.Weather.Temperature();
            vm.Temperature.Maximum.Value = dto.MaximumValue;
            vm.Temperature.Maximum.Unit = dto.MaximumUnit;
            vm.Temperature.Maximum.UnitType = dto.MaximumUnitType;

            vm.Temperature.Minimum = new Models.Weather.Temperature();
            vm.Temperature.Minimum.Value = dto.MinimumValue;
            vm.Temperature.Minimum.Unit = dto.MinimumUnit;
            vm.Temperature.Minimum.UnitType = dto.MinimumUnitType;

            vm.Day = new DayNightCycles();
            vm.Day.Icon = dto.DayIcon;
            vm.Day.IconPhrase = dto.DayIconPhrase;
            vm.Day.HasPrecipitation = dto.DayHasPrecipitation;
            vm.Day.PrecipitationType = dto.DayPrecipitationType;
            vm.Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.Night = new DayNightCycles();
            vm.Night.Icon = dto.NightIcon;
            vm.Night.IconPhrase = dto.NightIconPhrase;
            vm.Night.HasPrecipitation = dto.NightHasPrecipitation;
            vm.Night.PrecipitationType = dto.NightPrecipitationType;
            vm.Night.PrecipitationIntensity = dto.NightPrecipitationIntensity;

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowOpenWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("OpenCity", "WeatherForecasts");
            }

            return View();
        }

        [HttpGet]
        public IActionResult OpenCity()
        {
            OpenWeatherResultDto dto = new OpenWeatherResultDto();
            OpenWeatherViewModel vm = new OpenWeatherViewModel();

            _weatherForecastsServices.OpenWeatherDetail(dto);

            vm.Name = dto.Name;

            vm.Main = new Mains();
            vm.Main.Temp = dto.Temperature;
            vm.Main.FeelsLike = dto.TempFeelsLike;
            vm.Main.Humidity = dto.Humidity;
            vm.Main.Pressure = dto.Pressure;

            vm.Wind = new Winds();
            vm.Wind.WindSpeed = dto.WindSpeed;

            vm.Weather = new Weathers();
            vm.Weather.Main = dto.WeatherCondition;

            return View(vm);
        }

    }
}
