
using Contracts.Entities.WeatherForecast;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<WeatherForecastEntity> WeatherForecast { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseSettings.GetConnectionString());

        }

    }
}
