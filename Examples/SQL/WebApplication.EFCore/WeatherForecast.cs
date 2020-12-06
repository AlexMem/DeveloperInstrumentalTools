using System;

namespace WebApplication.EFCore
{
    public class WeatherForecast
    {
        public DateTime TimeStamp { get; set; }

        public decimal TemperatureC { get; set; }

        public decimal TemperatureF => 32 + (TemperatureC / 0.5556m);

        public string Summary { get; set; }
    }
}