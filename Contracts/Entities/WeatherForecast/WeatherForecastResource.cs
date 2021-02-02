using System;

namespace Contracts.Entities.WeatherForecast
{

    public class WeatherForecastResource
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}
