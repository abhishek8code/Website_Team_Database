using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace GECPATAN_FACULTY_PORTAL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            var department = _context.Departments
            .Where(x => !x.IsDeleted)
            .ToList() ?? new List<Departments>(); ;
            return View(department);
        }
        // GET : CREATE DEPARTMENT
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departments model){
            if (!ModelState.IsValid)
                return View(model);

            _context.Departments.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //GET : EDIT
        public IActionResult Edit(int id)
        {
            var departments = _context.Departments
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (departments == null)
                return NotFound();

            return View(departments);
        }
        //POST : EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departments model)
        {
            if (!ModelState.IsValid)
                return View(model);
             
            _context.Departments.Update(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        // DETAILS
        public IActionResult Details(int id)
        {
            var departments = _context.Departments
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (departments == null)
                return NotFound();

            return View(departments);
        }
        // DELETE (SOFT DELETE)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var d = _context.Departments
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (d == null)
                return NotFound();

            d.IsDeleted = true;
            _context.Update(d);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
