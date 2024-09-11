using FinalProject1.Context;
using FinalProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject1.Controllers
{
    public class UserController : Controller
    {
        MyContect db = new MyContect();
        [HttpGet]
        public IActionResult Index()
        {
            var _Users = db.Users;
            return View(_Users);
        }
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _User = db.Users.Find(id);
            if (_User == null)
            {
                return RedirectToAction("Index");
            }
            return View(_User);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var _User = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (_User != null)
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View(user);
                }
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return RedirectToAction("Index", "Product");
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View();
        }
    }
}

