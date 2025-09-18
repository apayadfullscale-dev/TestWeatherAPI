using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public interface IWeatherApiService
    {
        Task<string> GetCurrentAsync(string q);
        Task<string> GetForecastAsync(string q, int days);
        Task<string> GetHistoryAsync(string q, string dt);
        Task<string> GetAlertsAsync(string q);
        Task<string> GetMarineAsync(string q);
        Task<string> GetFutureAsync(string q, string dt);
        Task<string> SearchAsync(string q);
        Task<string> IpLookupAsync(string q);
        Task<string> AstronomyAsync(string q, string dt);
        Task<string> TimeZoneAsync(string q);
        Task<string> SportsAsync(string q);
    }

    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "79a7fc99066747179c265852251809";
        private const string BaseUrl = "http://api.weatherapi.com/v1";

        public WeatherApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        private async Task<string> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> GetCurrentAsync(string q) =>
            GetAsync($"{BaseUrl}/current.json?key={ApiKey}&q={q}");
        public Task<string> GetForecastAsync(string q, int days) =>
            GetAsync($"{BaseUrl}/forecast.json?key={ApiKey}&q={q}&days={days}");
        public Task<string> GetHistoryAsync(string q, string dt) =>
            GetAsync($"{BaseUrl}/history.json?key={ApiKey}&q={q}&dt={dt}");
        public Task<string> GetAlertsAsync(string q) =>
            GetAsync($"{BaseUrl}/alerts.json?key={ApiKey}&q={q}");
        public Task<string> GetMarineAsync(string q) =>
            GetAsync($"{BaseUrl}/marine.json?key={ApiKey}&q={q}");
        public Task<string> GetFutureAsync(string q, string dt) =>
            GetAsync($"{BaseUrl}/future.json?key={ApiKey}&q={q}&dt={dt}");
        public Task<string> SearchAsync(string q) =>
            GetAsync($"{BaseUrl}/search.json?key={ApiKey}&q={q}");
        public Task<string> IpLookupAsync(string q) =>
            GetAsync($"{BaseUrl}/ip.json?key={ApiKey}&q={q}");
        public Task<string> AstronomyAsync(string q, string dt) =>
            GetAsync($"{BaseUrl}/astronomy.json?key={ApiKey}&q={q}&dt={dt}");
        public Task<string> TimeZoneAsync(string q) =>
            GetAsync($"{BaseUrl}/timezone.json?key={ApiKey}&q={q}");
        public Task<string> SportsAsync(string q) =>
            GetAsync($"{BaseUrl}/sports.json?key={ApiKey}&q={q}");
    }
}
