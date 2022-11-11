using Microsoft.AspNetCore.Mvc;
using RAI_MVC_180348.Models;

namespace RAI_MVC_180348.Controllers
{
    public class UserController : Controller
    {
        public static List<UserViewModel> Users = new()
        {
            new UserViewModel("admin", new List<string>()),
        };
        public static string? LoggedIn { get; set; }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([FromForm (Name="login")]string login)
        {
            if (!Users.Exists(x => x.UserName == login))
            {
                Users.Add(new UserViewModel(login, new List<string>()));
            }

            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View(Users);
        }

        public IActionResult Del(string username)
        {
            var userToDelete = Users.Single(x => x.UserName == username);
            Users.Remove(userToDelete);

            return RedirectToAction("List");
        }

        public IActionResult Delete(string username)
        {
            var user = Users.SingleOrDefault(x => x.UserName == username);

            if (user == null)
            {
                return RedirectToAction("List");
            }

            ViewBag.username = username;
            return View(user);
        }
    }
}
