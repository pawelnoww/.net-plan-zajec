using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Plan_zajec.Models;

namespace Plan_zajec.Controllers;

public class AdminPanelController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AdminPanelController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}