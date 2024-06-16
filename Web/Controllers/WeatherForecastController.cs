using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Web.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   [Produces(MediaTypeNames.Application.Json)]
   public class WeatherForecastController : ControllerBase
   {
      private static readonly string[] Summaries = new[]
      {
           "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };

      private readonly ILogger<WeatherForecastController> _logger;

      public WeatherForecastController(ILogger<WeatherForecastController> logger)
      {
         _logger = logger;
      }

      [HttpGet(Name = "GetWeatherForecast")]
      [Produces(MediaTypeNames.Application.Json)]
      public IActionResult Get()
      {
         return new JsonResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
         {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
         })
         .ToArray());
      }
   }
}
