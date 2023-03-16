using System.Text.Json.Serialization;

namespace TARge21Shop.Models.Weather
{
    public class OpenWeatherViewModel
    {
        public string Base { get; set; }
        public int Visibility { get; set; }
        public int Dt { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
        public Coords Coord { get; set; }
        public Weathers Weather { get; set; }
        public Mains Main { get; set; }
        public Winds Wind { get; set; }
        public Cloud Clouds { get; set; }
        public Syss Sys { get; set; }
    }

    public class Coords
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weathers
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Mains
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GroundLevel { get; set; }
    }

    public class Winds
    {
        public double WindSpeed { get; set; }
        public int Degree { get; set; }
        public double Gust { get; set; }
    }

    public class Cloud
    {
        public int All { get; set; }
    }

    public class Syss
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int SunSet { get; set; }
    }
    
}
