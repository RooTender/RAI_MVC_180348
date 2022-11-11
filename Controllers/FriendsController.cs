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
            if (LoggedIn == null) return Json("User is not logged in!");

            return View(Users.Single(x => x.UserName == LoggedIn));
        }

        [HttpPost]
        public IActionResult Add([FromForm(Name="login")]string login)
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
                : File(new UTF8Encoding().GetBytes(Users.Single(x => x.UserName == LoggedIn)
                    .Friends
                    .Aggregate((a, b) => a + '\n' + b)), "text/csv", filename);
        }

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import([FromForm (Name="fileWithData")]IFormFile uploadedFile)
        {
            if (LoggedIn == null) return Json("User is not logged in! I don't know to whom import friends list!");

            var userToAddFriends = Users.Single(x => x.UserName == LoggedIn);

            using var streamReader = new StreamReader(uploadedFile.OpenReadStream());
            while (streamReader.Peek() >= 0)
            {
                var friend = streamReader.ReadLine();
                if (friend == null) continue;

                if (!userToAddFriends.Friends.Contains(friend))
                {
                    userToAddFriends.Friends.Add(friend);
                }
            }

            return RedirectToAction("Index"); 
        }
    }
}
