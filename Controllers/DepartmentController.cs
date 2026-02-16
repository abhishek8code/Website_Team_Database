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
        // ======================
        // MANAGE VISION (GET)
        // ======================

        public async Task<IActionResult> ManageVision(int departmentId)
        {
            var vision = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.Dept_ID == departmentId);

            // If not exists → create empty model for add
            vision ??= new DepartmentVision
            {
                Dept_ID = departmentId
            };

            return View("ManageVision", vision);
        }


        // ======================
        // VIEW VISION DETAILS
        // ======================

        public async Task<IActionResult> Vision(int id)
        {
            var vision = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.Dept_ID == id);

            // If no vision exists → redirect to manage page
            if (vision == null)
            {
                return RedirectToAction(nameof(ManageVision),
                    new { departmentId = id });
            }

            return View("VisionDetails", vision);
        }


        // ======================
        // ADD / UPDATE VISION (POST)
        // ======================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageVision(DepartmentVision model)
        {
            if (!ModelState.IsValid)
            {
                return View("ManageVision", model);
            }

            var visionInDb = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.Dept_ID == model.Dept_ID);

            if (visionInDb == null)
            {
                // ADD NEW
                _context.DepartmentVisions.Add(model);
            }
            else
            {
                // UPDATE EXISTING
                visionInDb.VisionText = model.VisionText;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Vision),
                new { id = model.Dept_ID });
        }


        // ======================
        // MANAGE MISSION (GET)
        // ======================

        public async Task<IActionResult> ManageMission(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;

            var missions = await _context.DepartmentMissions
                .Where(m => m.Dept_ID == departmentId &&!m.IsDeleted)
                .OrderBy(m => m.Id)
                .ToListAsync();

            return View(missions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMission(DepartmentMission model)
        {
            if (ModelState.IsValid)
            {
                model.IsDeleted = false;

                model.CreatedDate = DateTime.Now;
                model.CreatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

                _context.DepartmentMissions.Add(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManageMission),
                new { Id = model.Dept_ID });
        }
        public async Task<IActionResult> EditMission(int id)
        {
            var mission = await _context.DepartmentMissions.FindAsync(id);
            if (mission == null)
                return NotFound();

            return View(mission);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMission(DepartmentMission model)
        {
            var missionInDb = await _context.DepartmentMissions
                .FirstOrDefaultAsync(m => m.Id == model.Id);

            if (missionInDb == null)
                return NotFound();

            missionInDb.MissionText = model.MissionText;

            missionInDb.UpdatedDate = DateTime.Now;
            missionInDb.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageMission),
                new { deptId = missionInDb.Dept_ID });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var mission = await _context.DepartmentMissions.FindAsync(id);
            if (mission == null)
                return NotFound();

            int deptId = mission.Dept_ID;
            // SOFT DELETE
            mission.IsDeleted = true;

            mission.UpdatedDate = DateTime.Now;
            mission.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();
            _context.DepartmentMissions.Remove(mission);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageMission),
                new { deptId });
        }
    }
}
