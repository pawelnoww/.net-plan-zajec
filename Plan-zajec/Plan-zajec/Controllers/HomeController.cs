using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plan_zajec.Data;
using Plan_zajec.Models;

namespace Plan_zajec.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {

        var groups = await _context.Group.ToListAsync();
        var group_id = new int();
        if (String.IsNullOrEmpty(HttpContext.Request.Query["group_id"]))
        {
            group_id = groups[0].ID;
        }
        else
        {
            group_id = Int32.Parse(HttpContext.Request.Query["group_id"]);
        }
        
        var items = await _context.Lesson.Where(l => l.GroupID == group_id).ToListAsync();

        ViewData["groups"] = groups;
        return View(items);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}