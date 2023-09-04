using Guest_Book.Models;
using Guest_Book.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Guest_Book.Controllers
{
    public class HomeController : Controller
    {
        //Guest_BookContext db;
        //public HomeController(Guest_BookContext context)
        //{
        //    db = context;
        //}
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }

        public ActionResult Index()
        {
            ViewBag.Messages = repo.MessagesToList();
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMessage(Message message)
        {
            try
            {
                string login = HttpContext.Session.GetString("Login");
                var user = await repo.FindUsersById(login);

                message.User = user;
                message.UserName = HttpContext.Session.GetString("Login");
                message.MessageDate = DateTime.Now;
                repo.AddMessage(message);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}