using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Guest_Book.Models;
using Guest_Book.Repository;

namespace Guest_Book.Controllers
{
    public class UserController : Controller
    {
        IRepository repo;

        public UserController(IRepository r)
        {
            repo = r;
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegisterModel reg)
        {
            if(ModelState.IsValid)
            {
                User user = new User();
                user.Name = reg.Name;
                user.Password = reg.Password;
                repo.AddUser(user);
                repo.Save();
            }
            return RedirectToAction("Login", "User");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                //var user = repo.UsersToList();
               
                if(db.Users.ToList().Count == 0)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(login);
                }
                var users = db.Users.Where(a => a.Name == login.Name);
                if(users.ToList().Count == 0)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(login);
                }
                var user = users.First();
                HttpContext.Session.SetString("Login", user.Name);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
