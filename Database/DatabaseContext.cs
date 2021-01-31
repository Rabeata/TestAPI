using System;
using System.Collections.Generic;
using System.Text;
using Contracts.Entities;
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
        public DbSet<WeatherForecast> WeatherForecast { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseSettings.GetConnectionString());

        }

    }
}
