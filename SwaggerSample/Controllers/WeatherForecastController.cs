using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SwaggerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// test summary for Get WeatherForecast
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(WeatherForecast[]), (int)HttpStatusCode.OK)]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Update Summaries
        /// </summary>
        /// <param name="summary">string item to add to the Summaries</param>
        /// <remarks>more details about api</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(string[]), (int)HttpStatusCode.OK)]
        public String[] Edit(string summary)
        {
            Array.Resize(ref Summaries, Summaries.Length + 1);
            Summaries[Summaries.Length - 1] = summary;
            var rng = new Random();

            return Summaries;
        }

    }
}
