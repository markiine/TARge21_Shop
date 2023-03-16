using System.Text.Json.Serialization;
using static TARge21Shop.Core.Dto.WeatherDtos.OpenWeatherDto;

namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class OpenWeatherDto
    {
        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("dt")]
        public int Dt { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }

        [JsonPropertyName("coord")]
        public Coords Coord { get; set; }

        [JsonPropertyName("weather")]
        public Weathers Weather { get; set; }

        [JsonPropertyName("main")]
        public Mains Main { get; set; }

        [JsonPropertyName("wind")]
        public Winds Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Cloud Clouds { get; set; }

        [JsonPropertyName("sys")]
        public Syss Sys { get; set; }

        public class Coords
        {
            [JsonPropertyName("lon")]
            public double Lon { get; set; }

            [JsonPropertyName("lat")]
            public double Lat { get; set; }
        }

        public class Weathers
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("icon")]
            public string Icon { get; set; }
        }

        public class Mains
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("feels_like")]
            public double Feels_Like { get; set; }

            [JsonPropertyName("temp_min")]
            public double Temp_Min { get; set; }

            [JsonPropertyName("temp_max")]
            public double Temp_Max { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("sea_level")]
            public int Sea_Level { get; set; }

            [JsonPropertyName("grnd_level")]
            public int Ground_Level { get; set; }
        }

        public class Winds
        {
            [JsonPropertyName("speed")]
            public double Speed { get; set; }

            [JsonPropertyName("deg")]
            public int Deg { get; set; }

            [JsonPropertyName("gust")]
            public double Gust { get; set; }
        }

        public class Cloud
        {
            [JsonPropertyName("all")]
            public int All { get; set; }
        }

        public class Syss
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("sunrise")]
            public int Sunrise { get; set; }

            [JsonPropertyName("sunrise")]
            public int SunSet { get; set; }
        }
    }
}
