using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto.WeatherDtos;

namespace TARge21Shop.ApplicationServices.Services
{
    public class WeatherForecastsServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apikey = "8c1HnCrK7N7Sz2aN5rmgZs93j88fk464";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize <WeatherRootDto>(json);

                weatherInfo.Headline.EffectiveDate = dto.EffectiveDate;
                weatherInfo.Headline.EffectiveEpochDate = dto.EffectiveEpochDate;
                weatherInfo.Headline.Severity = dto.Severity;
                weatherInfo.Headline.Text = dto.Text;
                weatherInfo.Headline.Category = dto.Category;
                weatherInfo.Headline.EndDate = dto.EndDate;
                weatherInfo.Headline.EndEpochDate = dto.EndEpochDate;
                weatherInfo.Headline.MobileLink = dto.HeadlineMobileLink;
                weatherInfo.Headline.Link = dto.HeadlineLink;

                weatherInfo.DailyForecasts[0].Date = dto.Date;
                weatherInfo.DailyForecasts[0].EpochDate = dto.EpochDate;
                weatherInfo.DailyForecasts[0].Temperature = dto.Temperature;
                weatherInfo.DailyForecasts[0].Day = dto.Day;
                weatherInfo.DailyForecasts[0].Night = dto.Night;
                weatherInfo.DailyForecasts[0].Sources = dto.Sources;
                weatherInfo.DailyForecasts[0].MobileLink = dto.MobileLink;
                weatherInfo.DailyForecasts[0].Link = dto.Link;


                weatherInfo.DailyForecasts[0].Day.Icon = dto.DayIcon;
                weatherInfo.DailyForecasts[0].Day.IconPhrase = dto.DayIconPhrase;
                weatherInfo.DailyForecasts[0].Day.HasPrecipitation = dto.DayHasPrecipitation;
                weatherInfo.DailyForecasts[0].Day.PrecipitationType = dto.DayPrecipitationType;
                weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;

                weatherInfo.DailyForecasts[0].Night.Icon = dto.NightIcon;
                weatherInfo.DailyForecasts[0].Night.IconPhrase = dto.NightIconPhrase;
                weatherInfo.DailyForecasts[0].Night.HasPrecipitation = dto.NightHasPrecipitation;
                weatherInfo.DailyForecasts[0].Night.PrecipitationType = dto.NightPrecipitationType;
                weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity = dto.NightPrecipitationIntensity;


                weatherInfo.DailyForecasts[0].Temperature.Maximum.Value = dto.TemperatureMaximumValue;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit = dto.TemperatureMaximumUnit;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType = dto.TemperatureMaximumUnitType;

                weatherInfo.DailyForecasts[0].Temperature.Minimum.Value = dto.TemperatureMinimummValue;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit = dto.TemperatureMinimumUnit;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType = dto.TemperatureMinimumUnitType;







            }
            return dto;





        }
    }
}
