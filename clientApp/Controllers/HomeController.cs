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

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Weather()
    {
        const string url = "https://localhost:7036/weatherforecastproxy";
        var proxyResult = await _httpClient.GetStringAsync(url);
        return View("Weather", proxyResult);
    }
}