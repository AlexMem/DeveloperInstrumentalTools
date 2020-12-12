using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private HttpClient HttpClient { get; }
        
        public WeatherForecastService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            using var response = await this.HttpClient.GetAsync("weatherforecast");

            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        
        public async Task<StatisticsForecast> GetWeatherForecastStatistics()
        {
            var weatherForecasts = await GetWeatherForecasts();
            return new StatisticsForecast()
            {
                AvgTemperatureC = weatherForecasts.Average(forecast => forecast.TemperatureC),
                From = weatherForecasts.Min(forecast => forecast.TimeStamp),
                To = weatherForecasts.Max(forecast => forecast.TimeStamp),
            };
        }
    }
}