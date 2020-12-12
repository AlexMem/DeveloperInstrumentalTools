using System;

namespace RazorWebApplication.Models
{
    public class StatisticsForecast
    {
        public decimal AvgTemperatureC { get; set; }
        
        public DateTime From { get; set; }
        
        public DateTime To { get; set; }
        
        public string AvgTemperatureCText => FormatTemperature(this.AvgTemperatureC, "C");
        
        private static string FormatTemperature(decimal temperature, string postfix)
        {
            return $"{temperature:0.##}°{postfix}";
        }

        public override string ToString()
        {
            return "Average temperature in celsius from " + From + " to " + To + ": " + AvgTemperatureCText;
        }
    }
}