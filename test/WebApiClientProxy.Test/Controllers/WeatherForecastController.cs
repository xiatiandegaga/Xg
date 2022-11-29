using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClientProxy.Test.Controllers
{

    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase, ITest
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(WeatherForecast x)
        {
            var rng = new Random(); 
            return Enumerable.Range(1, 2).Select(index =>x)
            .ToArray();
        }
        //[HttpGet]
        //public WeatherForecast Get1()
        //{
        //    var rng = new Random();
        //    return  new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(1),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    };
        //}

    }
}
