using Baitapolop.Data;
using Baitapolop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitapolop.Controllers
{
    public class CoursesController: Controller
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db) => _db = db;

        public IActionResult Index() => View(_db.Courses.ToList());
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Course c)
        {
            _db.Courses.Add(c); _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) => View(_db.Courses.Find(id));

        [HttpPost]
        public IActionResult Edit(Course c)
        {
            _db.Courses.Update(c); _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _db.Courses.Remove(_db.Courses.Find(id)); _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
