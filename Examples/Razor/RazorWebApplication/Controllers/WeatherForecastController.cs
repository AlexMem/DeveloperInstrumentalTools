using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class WeatherForecastController : Controller
    {
        private IWeatherForecastService WeatherForecastService { get; }
        
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            WeatherForecastService = weatherForecastService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.WeatherForecastService.GetWeatherForecasts());
        }

        public IActionResult Details(WeatherForecast model)
        {
            return this.View(model);
        }

        public async Task<IActionResult> Statistics()
        {
            return this.View(await this.WeatherForecastService.GetWeatherForecastStatistics());
        }
    }
}