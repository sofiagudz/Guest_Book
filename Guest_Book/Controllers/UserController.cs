using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Guest_Book.Models;

namespace Guest_Book.Controllers
{
    public class UserController : Controller
    {
        Guest_BookContext db;
        public UserController(Guest_BookContext context)
        {
            db = context;
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
                db.Users.Add(user);
                db.SaveChanges();
            }
            return View(reg);
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
            return View(login);
        }
    }
}
