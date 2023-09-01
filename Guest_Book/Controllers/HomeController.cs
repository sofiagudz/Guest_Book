using Guest_Book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Guest_Book.Controllers
{
    public class HomeController : Controller
    {
        Guest_BookContext db;
        public HomeController(Guest_BookContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            //if(HttpContext.Session.GetString("Login") != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "User");
            //}
            ViewBag.Messages = db.Messages.ToList();
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

        public IActionResult AddMessage()
        {
            ViewBag.Messages = db.Messages.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMessage(Message message)
        {
            try
            {
                var user = db.Users.Where(a => a.Name == HttpContext.Session.GetString("Login"));
                foreach(var i in user)
                {
                    message.User = i;
                }
                message.UserName = HttpContext.Session.GetString("Login");
                message.MessageDate = DateTime.Now;
                db.Add(message);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}