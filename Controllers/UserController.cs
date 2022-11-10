using Microsoft.AspNetCore.Mvc;
using RAI_MVC_180348.Models;

namespace RAI_MVC_180348.Controllers
{
    public class UserController : Controller
    {
        public static List<UserViewModel> Users = new();

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Del(string username)
        {
            var userToDelete = Users.Single(x => x.UserName == username);
            Users.Remove(userToDelete);

            return RedirectToAction("List");
        }
    }
}
