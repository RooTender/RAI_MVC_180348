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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(string login)
        {
            if (UserController.Users.Exists(x => x.UserName == login))
            {
                UserController.LoggedIn = login;
            }

            return RedirectToAction("Index", "Friends");
        }
    }
}