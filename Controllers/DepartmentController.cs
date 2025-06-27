using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GECPATAN_FACULTY_PORTAL.Models.Department;
using GECPATAN_FACULTY_PORTAL.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GECPATAN_FACULTY_PORTAL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            return View(await _context.Department.ToListAsync());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null) return NotFound();

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Slogan,Tagline,TitleImage,About,ShowIntake,IsDeleted,CreatedDate,CreatedDateInt,UpdatedDate,UpdatedDateInt,CreatedBy,UpdatedBy")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var department = await _context.Department.FindAsync(id);
            if (department == null) return NotFound();

            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Slogan,Tagline,TitleImage,About,ShowIntake,IsDeleted,CreatedDate,CreatedDateInt,UpdatedDate,UpdatedDateInt,CreatedBy,UpdatedBy")] Department department)
        {
            if (id != department.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null) return NotFound();

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.Id == id);
        }
    }
}



//using Microsoft.AspNetCore.Mvc;
//using GECPATAN_FACULTY_PORTAL.Models.Department;
//using GECPATAN_FACULTY_PORTAL.Data;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;

//namespace GECPATAN_FACULTY_PORTAL.Controllers
//{
//    public class DepartmentController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public DepartmentController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: /Department
//        public async Task<IActionResult> Index()
//        {
//            var departments = await _context.Departments.ToListAsync();
//            return View(departments);
//        }

//        // GET: /Department/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null) return NotFound();

//            var department = await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);
//            if (department == null) return NotFound();

//            return View(department);
//        }

//        // GET: /Department/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: /Department/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Image,Slogan,Tagline,TitleImage,About,ShowIntake,IsDeleted,CreatedDate,UpdatedDate")] Department department)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(department);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(department);
//        }

//        // GET: /Department/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null) return NotFound();

//            var department = await _context.Departments.FindAsync(id);
//            if (department == null) return NotFound();

//            return View(department);
//        }

//        // POST: /Department/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Slogan,Tagline,TitleImage,About,ShowIntake,IsDeleted,CreatedDate,UpdatedDate")] Department department)
//        {
//            if (id != department.Id) return NotFound();

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(department);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!DepartmentExists(department.Id)) return NotFound();
//                    else throw;
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(department);
//        }

//        // GET: /Department/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null) return NotFound();

//            var department = await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);
//            if (department == null) return NotFound();

//            return View(department);
//        }

//        // POST: /Department/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var department = await _context.Departments.FindAsync(id);
//            _context.Departments.Remove(department);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool DepartmentExists(int id)
//        {
//            return _context.Departments.Any(e => e.Id == id);
//        }
//    }
//}
