using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            // 127964 Tallinna kood
            string apikey = "8c1HnCrK7N7Sz2aN5rmgZs93j88fk464";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=8c1HnCrK7N7Sz2aN5rmgZs93j88fk464&metric=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = new JavaScriptSerializer().Deserialize <WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;
                dto.HeadlineMobileLink = weatherInfo.Headline.MobileLink;
                dto.HeadlineLink = weatherInfo.Headline.Link;

                dto.Date = weatherInfo.DailyForecasts[0].Date;
                dto.EpochDate = weatherInfo.DailyForecasts[0].EpochDate;
                dto.Temperature = weatherInfo.DailyForecasts[0].Temperature;
                dto.Day = weatherInfo.DailyForecasts[0].Day;
                dto.Night = weatherInfo.DailyForecasts[0].Night;
                dto.Sources = weatherInfo.DailyForecasts[0].Sources;
                dto.MobileLink = weatherInfo.DailyForecasts[0].MobileLink;
                dto.Link = weatherInfo.DailyForecasts[0].Link;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;

                dto.MaximumValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.MaximumUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.MaximumUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.MinimumValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.MinimumUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.MinimumUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

            }
            return dto;

        }

        public async Task<WeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
        {
            
            string apikey = "cc24d0c9f87c454b55c9ded45a0f135e";
            var url = $"https://api.openweathermap.org/data/2.5/weather?q=Kuusalu&APPID=cc24d0c9f87c454b55c9ded45a0f135e";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OpenWeatherDto openWeatherInfo = new JavaScriptSerializer().Deserialize<OpenWeatherDto>(json);

                dto.Name = openWeatherInfo.Name;
                //dto.Temp = openWeatherInfo.Temperature;
                //dto.FeelsLike = openWeatherInfo.TempFeelsLike;
                //dto.Humidity = openWeatherInfo.Humidity;
                //dto.Pressure = openWeatherInfo.Pressure;
                //dto..WindSpeed = openWeatherInfo.WindSpeed;
                //dto.WeatherCondition = dto.WeatherCondition;


            }
            return null;

        }
    }
}
