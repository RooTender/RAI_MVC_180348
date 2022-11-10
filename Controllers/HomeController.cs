using Microsoft.AspNetCore.Mvc;
using RAI_MVC_180348.Models;
using System.Diagnostics;

namespace RAI_MVC_180348.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Init()
        {
            if (UserController.Users.Any())
            {
                return RedirectToAction("List", "User");
            }

            const int maxUsers = 6;
            for (var i = 0; i < maxUsers; ++i)
            {
                UserController.Users.Add(new($"User{i}", new List<string>
                {
                    $"User{(i + 1) % maxUsers}",
                    $"User{(i + 2) % maxUsers}",
                }));
            }

            return RedirectToAction("List", "User");
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
}