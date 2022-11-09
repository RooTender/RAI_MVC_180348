using Microsoft.AspNetCore.Mvc;
using RAI_MVC_180348.Models;

namespace RAI_MVC_180348.Controllers
{
    public class UserController : Controller
    {
        private static List<UserViewModel> _users = new();

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
            var userToDelete = _users.Single(x => x.UserName == username);
            _users.Remove(userToDelete);

            return RedirectToAction("List");
        }
    }
}
