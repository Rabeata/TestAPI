using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Repositories;
using Contracts.Entities.WeatherForecast;
using Contracts.Helpers;
using Contracts.Mappers;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastRepository weatherForecastRepository
            )
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastResource>> Get([FromQuery] QueryStringParameters queryParameters)
        {
            var columnsMap = new Dictionary<string, Expression<Func<WeatherForecastResource, object>>>()
            {
                ["date"] = v => v.Date,
                ["id"] = v => v.Id,
                ["summary"] = v => v.Summary,
                ["temperatureF"] = v => v.TemperatureF,
                ["temperatureC"] = v => v.TemperatureC
            };
            return await _weatherForecastRepository.ListAsync(queryParameters, columnsMap);
        }

        [HttpPost]
        public WeatherForecastResource Post([FromBody] WeatherForecastModel model)
        {
            var entity = model.MapModelToEntity();
            _weatherForecastRepository.AddAsync(entity);

            return entity.MapEntityToResult();
        }
    }
}
