using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var department = await _context.Departments
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
        public async Task<IActionResult> Create([Bind("Id,Name,Slogan,Tagline,TitleImage,About,ShowIntake")] Department department, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                // System-generated metadata
                var now = DateTime.UtcNow;
                department.CreatedDate = now;
                department.UpdatedDate = now;
                department.CreatedDateInt = new DateTimeOffset(now).ToUnixTimeSeconds();
                department.UpdatedDateInt = new DateTimeOffset(now).ToUnixTimeSeconds();
                //department.Isdeleted = false;

                // Save entity first
                _context.Add(department);
                await _context.SaveChangesAsync();

                // Handle image upload if present
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var folderPath = Path.Combine("wwwroot", "Department", department.Id.ToString());
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    department.Image = $"Department/{department.Id}/{fileName}";
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var department = await _context.Departments.FindAsync(id);
            if (department == null) return NotFound();

            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Slogan,Tagline,TitleImage,About,ShowIntake,CreatedDate,CreatedDateInt,UpdatedDate,UpdatedDateInt,IsDeleted")] Department department, IFormFile ImageFile)
        {
            if (id != department.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Set UpdatedDate and UpdatedDateInt
                    department.UpdatedDate = DateTime.Now;
                    department.UpdatedDateInt = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();

                    // Save new image if uploaded
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var folderPath = Path.Combine("wwwroot", "Department", department.Id.ToString());

                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        var fileName = Path.GetFileName(ImageFile.FileName);
                        var filePath = Path.Combine(folderPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        // Update image path
                        department.Image = $"Department/{department.Id}/{fileName}";
                    }

                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Departments.Any(e => e.Id == department.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null) return NotFound();

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }




        // DepartmentIntake: Index/List for a Department
        public async Task<IActionResult> DepartmentIntakes(int departmentId)
        {
            var intakes = await _context.DepartmentIntakes
                .Where(i => i.DeptId == departmentId)
                .Include(i => i.Dept)
                .ToListAsync();

            ViewBag.DepartmentId = departmentId;
            ViewBag.DepartmentName = intakes.FirstOrDefault()?.Dept?.Name ?? "Unknown Department";

            return View("~/Views/DepartmentIntake/Index.cshtml", intakes);
        }


        // DepartmentIntake: Create
        public IActionResult AddIntake(int departmentId = 0)
        {
            // Load department list for dropdown
            ViewBag.Departments = _context.Departments
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();

            return View("~/Views/DepartmentIntake/Create.cshtml", new DepartmentIntake { DeptId = departmentId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIntake(DepartmentIntake intake)
        {
            ModelState.Remove("Dept"); // avoid validating nav property

            if (ModelState.IsValid)
            {
                intake.CreatedDate = DateTime.Now;
                intake.CreatedDateInt = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
                intake.UpdatedDate = DateTime.Now;
                intake.UpdatedDateInt = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
                intake.IsDeleted = false;

                _context.Add(intake);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentIntakes", new { departmentId = intake.DeptId });
            }

            // If validation fails, reload department list
            ViewBag.Departments = await _context.Departments
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToListAsync();

            return View("~/Views/DepartmentIntake/Create.cshtml", intake);
        }



        // DepartmentIntake: Edit
        public async Task<IActionResult> EditIntake(int id)
        {
            var intake = await _context.DepartmentIntakes.FindAsync(id);
            if (intake == null) return NotFound();

            ViewBag.DepartmentId = intake.DeptId;
            return View("~/Views/DepartmentIntake/Edit.cshtml", intake);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIntake(int id, DepartmentIntake intake)
        {
            if (id != intake.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existing = await _context.DepartmentIntakes.FindAsync(id);
                if (existing == null)
                    return NotFound();

                existing.IntakeYear = intake.IntakeYear;
                existing.IntakeCount = intake.IntakeCount;
                existing.UpdatedDate = DateTime.Now;
                existing.UpdatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("DepartmentIntakes", new { departmentId = existing.DeptId });
                }
                catch (Exception ex)
                {
                    // Log error and show it on the page temporarily
                    ModelState.AddModelError("", $"Save failed: {ex.Message}");
                }
            }

            ViewBag.DepartmentId = intake.DeptId;
            return View("~/Views/DepartmentIntake/Edit.cshtml", intake);
        }


        // DepartmentIntake: Delete
        public async Task<IActionResult> DeleteIntake(int id)
        {
            var intake = await _context.DepartmentIntakes
                .Include(i => i.Dept)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (intake == null) return NotFound();

            return View("~/Views/DepartmentIntake/Delete.cshtml", intake);
        }

        [HttpPost, ActionName("DeleteIntake")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteIntakeConfirmed(int id)
        {
            var intake = await _context.DepartmentIntakes.FindAsync(id);
            if (intake != null)
            {
                // Soft delete
                intake.IsDeleted = true;
                intake.UpdatedDate = DateTime.Now;
                intake.UpdatedDateInt = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();

                _context.Update(intake);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentIntakes", new { departmentId = intake.DeptId });
            }
            return NotFound();
        }



        //Department Vision
        // GET: DepartmentVision/Manage
        public async Task<IActionResult> ManageVision(int departmentId)
        {
            var vision = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.DeptId == departmentId);

            ViewBag.DepartmentName = await _context.Departments
                .Where(d => d.Id == departmentId)
                .Select(d => d.Name)
                .FirstOrDefaultAsync();

            if (vision == null)
            {
                // Show Create form
                return View("~/Views/DepartmentVision/Create.cshtml", new DepartmentVision { DeptId = departmentId });
            }
            else
            {
                // Show Edit form
                return View("~/Views/DepartmentVision/Edit.cshtml", vision);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageVision(DepartmentVision model)
        {
            if (ModelState.IsValid)
            {
                var existing = await _context.DepartmentVisions
                    .FirstOrDefaultAsync(v => v.DeptId == model.DeptId);

                if (existing != null)
                {
                    // Update
                    existing.VisionText = model.VisionText;
                    existing.UpdatedDate = DateTime.Now;
                    existing.UpdatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                    _context.Update(existing);
                }
                else
                {
                    // Create
                    model.CreatedDate = DateTime.Now;
                    model.CreatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                    _context.Add(model);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("ViewVision", "Department", new { departmentId = model.DeptId });
                
            }

            // Return to appropriate view if error
            return View(model.Id == 0 ? "~/Views/DepartmentVision/Create.cshtml" : "~/Views/DepartmentVision/Edit.cshtml", model);
        }
        public async Task<IActionResult> ViewVision(int departmentId)
        {
            var vision = await _context.DepartmentVisions
                .FirstOrDefaultAsync(v => v.DeptId == departmentId);

            if (vision == null)
                return Content("No vision found for this department.");

            ViewBag.DepartmentName = await _context.Departments
                .Where(d => d.Id == departmentId)
                .Select(d => d.Name)
                .FirstOrDefaultAsync();

            return View("~/Views/DepartmentVision/Details.cshtml", vision);
        }


        // GET: Department Mission List
        public async Task<IActionResult> DepartmentMissions(int departmentId)
        {
            var missions = await _context.DepartmentMissions
                .Where(m => m.DeptId == departmentId && m.IsDeleted == false)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentMission/Index.cshtml", missions);
        }

        // GET: Add New Mission
        public IActionResult AddMission(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentMission/Create.cshtml", new DepartmentMission { DeptId = departmentId });
        }

        // POST: Add New Mission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMission(DepartmentMission mission)
        {
            if (ModelState.IsValid)
            {
                mission.CreatedDate = DateTime.Now;
                mission.CreatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                mission.IsDeleted = false;

                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentMissions", new { departmentId = mission.DeptId });
            }

            ViewBag.DepartmentId = mission.DeptId;
            return View("~/Views/DepartmentMission/Create.cshtml", mission);
        }

        // GET: Edit Mission
        public async Task<IActionResult> EditMission(int id)
        {
            var mission = await _context.DepartmentMissions.FindAsync(id);
            if (mission == null || mission.IsDeleted)
                return NotFound();

            ViewBag.DepartmentId = mission.DeptId;
            return View("~/Views/DepartmentMission/Edit.cshtml", mission);
        }

        // POST: Edit Mission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMission(int id, DepartmentMission mission)
        {
            if (id != mission.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existing = await _context.DepartmentMissions.FindAsync(id);
                if (existing == null)
                    return NotFound();

                existing.MissionText = mission.MissionText;
                existing.UpdatedDate = DateTime.Now;
                existing.UpdatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                _context.Update(existing);
                await _context.SaveChangesAsync();

                return RedirectToAction("DepartmentMissions", new { departmentId = mission.DeptId });
            }

            ViewBag.DepartmentId = mission.DeptId;
            return View("~/Views/DepartmentMission/Edit.cshtml", mission);
        }

        // POST: Soft Delete Mission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var mission = await _context.DepartmentMissions.FindAsync(id);
            if (mission != null)
            {
                mission.IsDeleted = true;
                mission.UpdatedDate = DateTime.Now;
                mission.UpdatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                _context.Update(mission);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("DepartmentMissions", new { departmentId = mission?.DeptId });
        }

        // View All PEOs
        public async Task<IActionResult> DepartmentPeo(int departmentId)
        {
            var peos = await _context.DepartmentPeos
                .Where(m => m.DeptId == departmentId && !m.IsDeleted)
                .Include(m => m.Dept)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentPeo/Index.cshtml", peos);
        }

        // Show Create PEO Form
        public IActionResult AddPeos(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentPeo/Create.cshtml", new DepartmentPeo { DeptId = departmentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPeos(DepartmentPeo peo)
        {
            ModelState.Remove("Dept");

            if (ModelState.IsValid)
            {
                peo.CreatedDate = DateTime.Now;
                peo.CreatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                peo.IsDeleted = false;

                _context.Add(peo);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentPeo", new { departmentId = peo.DeptId });
            }

            ViewBag.DepartmentId = peo.DeptId;
            return View("~/Views/DepartmentPeo/Create.cshtml", peo);
        }

        public async Task<IActionResult> DepartmentPsos(int departmentId)
        {
            var psos = await _context.DepartmentPsos
                .Where(p => p.DeptId == departmentId && !p.IsDeleted)
                .Include(p => p.Dept)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentPso/Index.cshtml", psos);
        }

        public IActionResult AddPsos(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentPso/Create.cshtml", new DepartmentPso { DeptId = departmentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPsos(DepartmentPso pso)
        {
            ModelState.Remove("Dept");

            if (ModelState.IsValid)
            {
                pso.CreatedDate = DateTime.Now;
                pso.CreatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                pso.IsDeleted = false;

                _context.Add(pso);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentPsos", new { departmentId = pso.DeptId });
            }

            ViewBag.DepartmentId = pso.DeptId;
            return View("~/Views/DepartmentPso/Create.cshtml", pso);
        }

        public async Task<IActionResult> DepartmentLab(int departmentId)
        {
            var labs = await _context.DepartmentLabs
                .Where(l => l.DeptId == departmentId && !l.IsDeleted)
                .Include(l => l.Dept)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentLabs/Index.cshtml", labs);
        }

        public IActionResult AddLab(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentLabs/Create.cshtml", new DepartmentLab { DeptId = departmentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLab(DepartmentLab lab, IFormFile? LabImageFile)
        {
            ModelState.Remove("Dept");

            if (ModelState.IsValid)
            {
                if (LabImageFile != null && LabImageFile.Length > 0)
                {
                    var folderPath = Path.Combine("wwwroot", "Labs", lab.DeptId.ToString());
                    if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                    var fileName = Path.GetFileName(LabImageFile.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await LabImageFile.CopyToAsync(stream);
                    }

                    lab.LabImage = $"Labs/{lab.DeptId}/{fileName}";
                }

                lab.CreatedDate = DateTime.Now;
                lab.CreatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                lab.IsDeleted = false;

                _context.Add(lab);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentLab", new { departmentId = lab.DeptId });
            }

            ViewBag.DepartmentId = lab.DeptId;
            return View("~/Views/DepartmentLabs/Create.cshtml", lab);
        }

        public async Task<IActionResult> EditLab(int id)
        {
            var lab = await _context.DepartmentLabs.FindAsync(id);
            if (lab == null) return NotFound();

            ViewBag.DepartmentId = lab.DeptId;
            return View("~/Views/DepartmentLabs/Edit.cshtml", lab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLab(int id, DepartmentLab lab, IFormFile? LabImageFile)
        {
            if (id != lab.LabId) return NotFound();
            ModelState.Remove("Dept");

            if (ModelState.IsValid)
            {
                try
                {
                    if (LabImageFile != null && LabImageFile.Length > 0)
                    {
                        var folderPath = Path.Combine("wwwroot", "Labs", lab.DeptId.ToString());
                        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                        var fileName = Path.GetFileName(LabImageFile.FileName);
                        var filePath = Path.Combine(folderPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await LabImageFile.CopyToAsync(stream);
                        }

                        lab.LabImage = $"Labs/{lab.DeptId}/{fileName}";
                    }

                    lab.UpdatedDate = DateTime.Now;
                    lab.UpdatedDateInt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                    _context.Update(lab);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("DepartmentLab", new { departmentId = lab.DeptId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.DepartmentLabs.Any(e => e.LabId == lab.LabId))
                        return NotFound();
                    else throw;
                }
            }

            ViewBag.DepartmentId = lab.DeptId;
            return View("~/Views/DepartmentLabs/Edit.cshtml", lab);
        }


    }
}


