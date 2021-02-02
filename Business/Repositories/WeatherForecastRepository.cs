using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Extensions;
using Contracts.Entities.WeatherForecast;
using Contracts.Helpers;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories
{
    public interface IWeatherForecastRepository : IBaseRepository<WeatherForecastEntity>
    {
        Task<PagedList<WeatherForecastResource>> ListAsync(
            QueryStringParameters queryString,
            Dictionary<string, Expression<Func<WeatherForecastResource, object>>> columnsMap);

        Task<bool> ExistsAsync(
            Expression<Func<WeatherForecastEntity, bool>> filters);

    }
    public class WeatherForecastRepository : BaseRepository<WeatherForecastEntity>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(
            DatabaseContext databaseContext):base(databaseContext)
        {
        }

        public async Task<PagedList<WeatherForecastResource>> ListAsync(QueryStringParameters queryString, Dictionary<string, Expression<Func<WeatherForecastResource, object>>> columnsMap)
        {
            var query = Context.WeatherForecast.Select(x => new WeatherForecastResource
            {
                Id = x.Id,
                Summary = x.Summary,
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                TemperatureF = x.TemperatureF
            }).Sort(queryString.SortBy, columnsMap, queryString.IsSortAscending);

            return await PagedList<WeatherForecastResource>.ToPagedListAsync(query, queryString.PageNumber, queryString.PageSize);
        }


        public async Task<bool> ExistsAsync(Expression<Func<WeatherForecastEntity, bool>> filter)
        {
            return await Context.WeatherForecast.AnyAsync(filter);
        }

    }
}
