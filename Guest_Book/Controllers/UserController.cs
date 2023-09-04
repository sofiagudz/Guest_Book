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
        public async Task<ActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                if(repo.UsersCount == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(login);
                }
                var user = await repo.CheckingLogin(login);
                if(repo.CheckingLoginCount(login) == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(login);
                }
                HttpContext.Session.SetString("Login", user.Name);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
