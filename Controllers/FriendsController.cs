using System.Text;
using Microsoft.AspNetCore.Mvc;
using RAI_MVC_180348.Models;
using static RAI_MVC_180348.Controllers.UserController;

namespace RAI_MVC_180348.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult Add(string login)
        {
            if (LoggedIn == null || !Users.Exists(x => x.UserName == login))
            {
                return Json(false);
            }
            
            Users.Single(x => x.UserName == LoggedIn).Friends.Add(login);
            return Json(true);
        }

        public IActionResult Del(string login)
        {
            if (LoggedIn == null || !Users.Exists(x => x.UserName == login))
            {
                return Json(false);
            }
            
            Users.Single(x => x.UserName == LoggedIn).Friends.Remove(login);
            return Json(true);
        }

        public IActionResult List()
        {
            return LoggedIn == null ? 
                Json(new List<UserViewModel>()) : 
                Json(Users.Single(x => x.UserName == LoggedIn).Friends);
        }

        public IActionResult Export()
        {
            const string filename = "Friends.txt";

            return LoggedIn == null
                ? File(new UTF8Encoding().GetBytes("The user was not logged in!"), "text/csv", filename)
                : File(new UTF8Encoding().GetBytes(Users.Single(x => x.UserName == LoggedIn).Friends.ToString() ?? string.Empty), "text/csv", filename);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import(IFormFile upload)
        {
            return Json(true);
        }
    }
}
