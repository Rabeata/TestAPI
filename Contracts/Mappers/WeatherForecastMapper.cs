using Contracts.Entities.WeatherForecast;

namespace Contracts.Mappers
{
    public static class WeatherForecastMapper
    {
        public static WeatherForecastEntity MapModelToEntity(
            this WeatherForecastModel model,
            int id = 0)
        {
            if (model == null) return null;
            var entity = new WeatherForecastEntity
            {
                Id = id,
                Date = model.Date,
                Summary = model.Summary,
                TemperatureC = model.TemperatureC
            };

            return entity;
        }

        public static WeatherForecastResource MapEntityToResult(
            this WeatherForecastEntity entity)
        {
            if (entity == null) return null;
            var result = new WeatherForecastResource
            {
                Id = entity.Id,
                Date = entity.Date,
                Summary = entity.Summary,
                TemperatureC = entity.TemperatureC,
                TemperatureF = entity.TemperatureF
            };

            return result;
        }

    }
}
