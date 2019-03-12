using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NoteStorage.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            ViewData["123"] = "Неверная комбинация логин пароль, попробуйте снова";
            return View();
        }

        public IActionResult Login(string login, string password)
        {
            if(login == "123" && password == "456")
            {
                var option = new CookieOptions();
                Response.Cookies.Append("Auth", "1", option);
                return RedirectToAction("Index", "Notes");
            }
            return RedirectToAction("Index", "Auth");
        }

        public IActionResult CheckAuth()
        {
            var s = Request.Cookies["Auth"];
            return (s == "1")?
                RedirectToAction("Index", "Notes"):
            RedirectToAction("Index", "Auth");
        }

        public IActionResult Quit()
        {
            var option = new CookieOptions();
            Response.Cookies.Append("Auth", "0", option);
            return RedirectToAction("Index", "Auth");
        }
    }
}