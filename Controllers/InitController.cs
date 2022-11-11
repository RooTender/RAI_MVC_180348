using Microsoft.AspNetCore.Mvc;

namespace RAI_MVC_180348.Controllers
{
    public class InitController : Controller
    {
        public IActionResult Index()
        {
            if (UserController.Users.Count > 1)
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
    }
}
