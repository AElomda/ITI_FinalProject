using FinalProject1.Context;
using FinalProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject1.Controllers
{
    public class CategoryController : Controller
    {
        MyContect db = new MyContect();
        [HttpGet]
        public IActionResult Index()
        {
            var _Categories = db.Categories;
            return View(_Categories);
        }
        public IActionResult ViewDetails(int id)
        {
            var _Category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (_Category == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Categoty = db.Categories.Include(c => c.Products).FirstOrDefault(cat => cat.Id == id);
            if(_Categoty == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Products = new SelectList(db.Products, "Id", "Name");
            return View(_Categoty);
        }
        [HttpPost]  
        public IActionResult Edit(Category category)
        {
            ModelState.Remove("Product");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Field Required");
                ViewBag._Products = new SelectList(db.Products, "Id", "Name");
                return View();
            }
            db.Categories.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
