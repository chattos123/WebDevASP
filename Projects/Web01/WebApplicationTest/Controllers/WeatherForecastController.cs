using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<WeatherForecast> Forecasts = new();
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            return Ok(Forecasts);
        }

        [HttpPost]
        public ActionResult<WeatherForecast> Post(WeatherForecast forecast)
        {
            Forecasts.Add(forecast);
            _logger.LogInformation("Added new forecast for {Date}", forecast.Date);
            return CreatedAtAction(nameof(Get), new { }, forecast);
        }

        [HttpPut("{index}")]
        public IActionResult Put(int index, WeatherForecast forecast)
        {
            if (index < 0 || index >= Forecasts.Count)
                return NotFound();

            Forecasts[index] = forecast;
            _logger.LogInformation("Updated forecast at index {Index}", index);
            return NoContent();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Forecasts.Count)
                return NotFound();

            Forecasts.RemoveAt(index);
            _logger.LogInformation("Deleted forecast at index {Index}", index);
            return NoContent();
        }
    }
}
