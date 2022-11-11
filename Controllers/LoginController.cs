using Microsoft.AspNetCore.Mvc;

namespace RAI_MVC_180348.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string login)
        {
            if (UserController.Users.Exists(x => x.UserName == login))
            {
                UserController.LoggedIn = login;
            }

            return RedirectToAction("Index", "Friends");
        }
    }
}
