using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Entities;
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
        private readonly DatabaseContext _databaseContext;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            DatabaseContext databaseContext
            )
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _databaseContext.WeatherForecast.ToList();
        }

        [HttpPost]
        public WeatherForecast Post([FromBody] WeatherForecast model)
        {
            _databaseContext.WeatherForecast.Add(model);
            _databaseContext.SaveChanges();
            return model;
        }
    }
}
