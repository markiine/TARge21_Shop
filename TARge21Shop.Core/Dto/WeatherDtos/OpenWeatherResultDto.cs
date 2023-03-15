using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class OpenWeatherResultDto
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public double TempFeelsLike { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherCondition { get; set; }
    }
}

