using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using clientApp.Models;

namespace clientApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<IActionResult> Index()
    {
        var proxyResult = await GetWeatherForecast("https://localhost:7036/weatherforecastproxy");
        return View("Index", proxyResult);
    }

    private async Task<string> GetWeatherForecast(string proxyUrl)
    {
        return await _httpClient.GetStringAsync(proxyUrl);
    }
}