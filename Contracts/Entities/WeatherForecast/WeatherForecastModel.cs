using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Entities.WeatherForecast
{

    public class WeatherForecastModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
