using FinalProject1.Context;
using FinalProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject1.Controllers
{
    public class ProductController : Controller
    {
        MyContect db = new MyContect();
        [HttpGet]
        public IActionResult Index()
        {
            var _Products = db.Products.Include(p => p.Category);
            return View(_Products);
        }
        public IActionResult Details(int id)
        {
            var _Product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
                return View();
            }
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Include(e => e.Category).FirstOrDefault(cat => cat.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
                return View();
            }
            db.Products.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var _Product = db.Products.Find(id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            db.Products.Remove(_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
