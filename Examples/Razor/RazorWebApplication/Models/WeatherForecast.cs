using System;

namespace RazorWebApplication.Models
{
    public class WeatherForecast
    {
        public DateTime TimeStamp { get; set; }

        public decimal TemperatureC { get; set; }

        public decimal TemperatureF { get; set; }

        public string Summary { get; set; }
        
        public string TemperatureCText => FormatTemperature(this.TemperatureC, "C");

        public string TemperatureFText => FormatTemperature(this.TemperatureF, "F");

        private static string FormatTemperature(decimal temperature, string postfix)
        {
            return $"{temperature:0.##}°{postfix}";
        }
    }
}