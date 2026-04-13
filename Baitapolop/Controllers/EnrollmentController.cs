using Baitapolop.Data;
using Baitapolop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Baitapolop.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext _db;
        public EnrollmentController(AppDbContext db) => _db = db;

        public IActionResult Index() =>
            View(_db.Enrollments.Include(e => e.Student).Include(e => e.Course).ToList());

        public IActionResult Create()
        {
            ViewBag.Students = _db.Students.ToList();
            ViewBag.Courses = _db.Courses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Enrollment e)
        {
            _db.Enrollments.Add(e); _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _db.Enrollments.Remove(_db.Enrollments.Find(id)); _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
