using Baitapolop.Data;
using Baitapolop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitapolop.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db) => _db = db;

        public IActionResult Index() => View(_db.Students.ToList());
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Student s)
        {
            _db.Students.Add(s); _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) => View(_db.Students.Find(id));

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            _db.Students.Update(s); _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _db.Students.Remove(_db.Students.Find(id)); _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
