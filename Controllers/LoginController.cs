using Microsoft.AspNetCore.Mvc;

namespace RAI_MVC_180348.Controllers
{
    public class LoginController : Controller
    {
        [Route("Login/{login}")]
        public ActionResult Index([FromRoute (Name = "login")] string login)
        {
            if (UserController.Users.Exists(x => x.UserName == login))
            {
                UserController.LoggedIn = login;
            }

            return RedirectToAction("Index", "Friends");
        }
    }
}
