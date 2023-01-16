using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;

            return View(objCategoryList);
        }

        [HttpGet]
        public IActionResult Form(int? Id)
        {
            var category = new Category();
            if(Id != null) {
                var categoryFromDb = _db.Categories.Find(Id);
                if (categoryFromDb == null)
                {
                    return NotFound();
                }
                category = categoryFromDb;
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Category category)
        {
            if(category.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    category.CreatedDateTime = DateTime.Now;

                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _db.Categories.Update(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);
            }
         
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
