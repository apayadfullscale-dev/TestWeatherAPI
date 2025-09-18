using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace WeatherAPI.Controllers
{
    /// <summary>
    /// Provides endpoints to access WeatherAPI.com data.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherApiService _weatherApiService;

        public WeatherController(IWeatherApiService weatherApiService)
        {
            _weatherApiService = weatherApiService;
        }

        /// <summary>
        /// Get current weather for a location.
        /// </summary>
        /// <param name="q">Location query (city name, lat/lon, zip, etc.)</param>
        /// <returns>Current weather data in JSON format.</returns>
        [HttpGet("current")]
        [SwaggerOperation(Summary = "Get current weather", Description = "Returns current weather for a given location.")]
        [SwaggerResponse(200, "Current weather data", typeof(string))]
        public async Task<IActionResult> GetCurrent([FromQuery, SwaggerParameter("Location query (city name, lat/lon, zip, etc.)", Required = true)] string q)
        {
            var content = await _weatherApiService.GetCurrentAsync(q);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get weather forecast for a location.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <param name="days">Number of forecast days (1-14)</param>
        /// <returns>Forecast weather data in JSON format.</returns>
        [HttpGet("forecast")]
        [SwaggerOperation(Summary = "Get weather forecast", Description = "Returns weather forecast for a given location and number of days.")]
        [SwaggerResponse(200, "Forecast weather data", typeof(string))]
        public async Task<IActionResult> GetForecast(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q,
            [FromQuery, SwaggerParameter("Number of forecast days (1-14)", Required = false)] int days = 1)
        {
            var content = await _weatherApiService.GetForecastAsync(q, days);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get historical weather for a location and date.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <param name="dt">Date (yyyy-MM-dd)</param>
        /// <returns>Historical weather data in JSON format.</returns>
        [HttpGet("history")]
        [SwaggerOperation(Summary = "Get historical weather", Description = "Returns historical weather for a given location and date.")]
        [SwaggerResponse(200, "Historical weather data", typeof(string))]
        public async Task<IActionResult> GetHistory(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q,
            [FromQuery, SwaggerParameter("Date (yyyy-MM-dd)", Required = true)] string dt)
        {
            var content = await _weatherApiService.GetHistoryAsync(q, dt);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get weather alerts for a location.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <returns>Weather alerts data in JSON format.</returns>
        [HttpGet("alerts")]
        [SwaggerOperation(Summary = "Get weather alerts", Description = "Returns weather alerts for a given location.")]
        [SwaggerResponse(200, "Weather alerts data", typeof(string))]
        public async Task<IActionResult> GetAlerts(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q)
        {
            var content = await _weatherApiService.GetAlertsAsync(q);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get marine weather for a location.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <returns>Marine weather data in JSON format.</returns>
        [HttpGet("marine")]
        [SwaggerOperation(Summary = "Get marine weather", Description = "Returns marine weather for a given location.")]
        [SwaggerResponse(200, "Marine weather data", typeof(string))]
        public async Task<IActionResult> GetMarine(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q)
        {
            var content = await _weatherApiService.GetMarineAsync(q);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get future weather for a location and date.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <param name="dt">Date (yyyy-MM-dd)</param>
        /// <returns>Future weather data in JSON format.</returns>
        [HttpGet("future")]
        [SwaggerOperation(Summary = "Get future weather", Description = "Returns future weather for a given location and date.")]
        [SwaggerResponse(200, "Future weather data", typeof(string))]
        public async Task<IActionResult> GetFuture(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q,
            [FromQuery, SwaggerParameter("Date (yyyy-MM-dd)", Required = true)] string dt)
        {
            var content = await _weatherApiService.GetFutureAsync(q, dt);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Search or autocomplete location.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <returns>Location search results in JSON format.</returns>
        [HttpGet("search")]
        [SwaggerOperation(Summary = "Search location", Description = "Returns location search or autocomplete results.")]
        [SwaggerResponse(200, "Location search results", typeof(string))]
        public async Task<IActionResult> Search(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q)
        {
            var content = await _weatherApiService.SearchAsync(q);
            return Content(content, "application/json");
        }

        /// <summary>
        /// IP lookup for weather and location info.
        /// </summary>
        /// <param name="q">IP address or 'auto:ip'</param>
        /// <returns>IP lookup results in JSON format.</returns>
        [HttpGet("iplookup")]
        [SwaggerOperation(Summary = "IP lookup", Description = "Returns weather and location info for an IP address.")]
        [SwaggerResponse(200, "IP lookup results", typeof(string))]
        public async Task<IActionResult> IpLookup(
            [FromQuery, SwaggerParameter("IP address or 'auto:ip'", Required = true)] string q)
        {
            var content = await _weatherApiService.IpLookupAsync(q);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get astronomy info for a location and date.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <param name="dt">Date (yyyy-MM-dd)</param>
        /// <returns>Astronomy info in JSON format.</returns>
        [HttpGet("astronomy")]
        [SwaggerOperation(Summary = "Get astronomy info", Description = "Returns astronomy info for a given location and date.")]
        [SwaggerResponse(200, "Astronomy info", typeof(string))]
        public async Task<IActionResult> Astronomy(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q,
            [FromQuery, SwaggerParameter("Date (yyyy-MM-dd)", Required = true)] string dt)
        {
            var content = await _weatherApiService.AstronomyAsync(q, dt);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get time zone info for a location.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <returns>Time zone info in JSON format.</returns>
        [HttpGet("timezone")]
        [SwaggerOperation(Summary = "Get time zone info", Description = "Returns time zone info for a given location.")]
        [SwaggerResponse(200, "Time zone info", typeof(string))]
        public async Task<IActionResult> TimeZone(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q)
        {
            var content = await _weatherApiService.TimeZoneAsync(q);
            return Content(content, "application/json");
        }

        /// <summary>
        /// Get sports events for a location.
        /// </summary>
        /// <param name="q">Location query</param>
        /// <returns>Sports events data in JSON format.</returns>
        [HttpGet("sports")]
        [SwaggerOperation(Summary = "Get sports events", Description = "Returns sports events for a given location.")]
        [SwaggerResponse(200, "Sports events data", typeof(string))]
        public async Task<IActionResult> Sports(
            [FromQuery, SwaggerParameter("Location query", Required = true)] string q)
        {
            var content = await _weatherApiService.SportsAsync(q);
            return Content(content, "application/json");
        }
    }
}
