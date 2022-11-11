using Microsoft.AspNetCore.Mvc;

namespace RAI_MVC_180348.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            UserController.LoggedIn = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
