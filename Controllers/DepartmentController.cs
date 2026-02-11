using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Vision(int deptId)
        {
            var vision = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.Dept_ID == deptId && !v.IsDeleted);

            if (vision == null)
            {
                // No vision yet → redirect to add/edit page
                return RedirectToAction(nameof(ManageVision), new { deptId });
            }

            return View("VisionDetails", vision);
        }
        public async Task<IActionResult> ManageVision(int deptId)
        {
            var vision = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.Dept_ID == deptId && !v.IsDeleted);

            if (vision == null)
            {
                vision = new DepartmentVision
                {
                    Dept_ID = deptId
                };
            }

            return View(vision);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageVision(DepartmentVision model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var visionInDb = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.Dept_ID == model.Dept_ID && !v.IsDeleted);

            if (visionInDb == null)
            {
                // ADD
                model.IsDeleted = false;
                model.CreatedDate = DateTime.Now;
                model.CreatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

                _context.DepartmentVisions.Add(model);
            }
            else
            {
                // EDIT
                visionInDb.VisionText = model.VisionText;
                visionInDb.UpdatedDate = DateTime.Now;
                visionInDb.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Vision), new { deptId = model.Dept_ID });
        }

    }
}
