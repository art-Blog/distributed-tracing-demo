using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace frontendApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastProxyController : ControllerBase
{
    private readonly ILogger<WeatherForecastProxyController> _logger;
    private readonly HttpClient _httpClient;

    public WeatherForecastProxyController(ILogger<WeatherForecastProxyController> logger,IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
    }
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var jsonStream = await _httpClient.GetStreamAsync("https://localhost:7250/WeatherForecast");
        var weatherForecast = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(jsonStream);
        return weatherForecast;
    }
}