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
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Slogan,Tagline,TitleImage,About,ShowIntake,IsDeleted,CreatedDate,CreatedDateInt,UpdatedDate,UpdatedDateInt,CreatedBy,UpdatedBy")] Department department, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                // Step 1: Save department first to generate Id (if it's Identity/auto-increment)
                _context.Add(department);
                await _context.SaveChangesAsync();

                // Step 2: Check if an image is uploaded
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Build path like: wwwroot/Department/5/
                    var folderPath = Path.Combine("wwwroot", "Department", department.Id.ToString());

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    // Unique file name (optional: add timestamp or GUID)
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    // Store relative path like: Department/5/yourimage.jpg
                    department.Image = $"Department/{department.Id}/{fileName}";

                    // Step 3: Update department with image path
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Slogan,Tagline,TitleImage,About,ShowIntake,CreatedDate,CreatedDateInt,UpdatedDate,UpdatedDateInt,CreatedBy,UpdatedBy")] Department department, IFormFile ImageFile)
        {
            if (id != department.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
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
            if (id != intake.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(intake);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentIntakes", new { departmentId = intake.DeptId });
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
                _context.DepartmentIntakes.Remove(intake);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentIntakes", new { departmentId = intake.DeptId });
            }
            return NotFound();
        }
        public async Task<IActionResult> ManageVision(int departmentId)
        {
            var vision = await _context.DepartmentVision
                .FirstOrDefaultAsync(v => v.DeptId == departmentId);

            if (vision == null)
            {
                vision = new DepartmentVision { DeptId = departmentId };
            }

            ViewBag.DepartmentName = _context.Departments
                .Where(d => d.Id == departmentId)
                .Select(d => d.Name)
                .FirstOrDefault();

            return View("VisionForm", vision);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageVision(DepartmentVision model)
        {
            if (ModelState.IsValid)
            {
                var existing = await _context.DepartmentVision
                    .FirstOrDefaultAsync(v => v.DeptId == model.DeptId);

                if (existing != null)
                {
                    existing.VisionText = model.VisionText;
                    _context.Update(existing);
                }
                else
                {
                    _context.Add(model);
                }
                var maxId = _context.DepartmentVision.Max(v => (int?)v.Id) ?? 0;
                model.Id = maxId + 1;

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); // or department details page
            }

            return View("VisionForm", model);
        }


        public async Task<IActionResult> ViewVision(int departmentId)
        {
            var vision = await _context.DepartmentVision
                .FirstOrDefaultAsync(v => v.DeptId == departmentId);

            if (vision == null)
                return Content("No vision found for this department.");

            ViewBag.DepartmentName = await _context.Departments
                .Where(d => d.Id == departmentId)
                .Select(d => d.Name)
                .FirstOrDefaultAsync();

            return View("VisionDisplay", vision);
        }



        //Department Mission
        public async Task<IActionResult> DepartmentMissions(int departmentId)
        {
            var missions = await _context.DepartmentMission
                .Where(m => m.DeptId == departmentId)
                .Include(m => m.Dept)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentMission/Index.cshtml", missions);
        }
        public IActionResult AddMission(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentMission/Create.cshtml", new DepartmentMission { DeptId = departmentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMission(DepartmentMission mission)
        {
            ModelState.Remove("Dept"); // since it's virtual and not bound

            if (ModelState.IsValid)
            {
                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentMissions", new { departmentId = mission.DeptId });
            }

            ViewBag.DepartmentId = mission.DeptId;
            return View("~/Views/DepartmentMission/Create.cshtml", mission);
        }


        // View All PEOs
        public async Task<IActionResult> DepartmentPeos(int departmentId)
        {
            var peos = await _context.DepartmentPeos
                .Where(m => m.DeptId == departmentId)
                .Include(m => m.Dept)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentPeos/Index.cshtml", peos);
        }



        // Show Create PEO Form
        public IActionResult AddPeos(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentPeos/Create.cshtml", new DepartmentPeos { DeptId = departmentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Submit Create PEO Form
        public async Task<IActionResult> AddPeos(DepartmentPeos Peo)
        {
            ModelState.Remove("Dept"); // since it's virtual and not bound

            if (ModelState.IsValid)
            {
                _context.Add(Peo);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentPeos", new { departmentId = Peo.DeptId });
            }

            ViewBag.DepartmentId = Peo.DeptId;
            return View("~/Views/DepartmentPeos/Create.cshtml", Peo);
        }
        // View PSOs for a Department
        public async Task<IActionResult> DepartmentPsos(int departmentId)
        {
            var psos = await _context.DepartmentPsos
                .Where(p => p.DeptId == departmentId)
                .Include(p => p.Dept)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentPsos/Index.cshtml", psos);
        }

        // Show Create PSO Form
        public IActionResult AddPsos(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentPsos/Create.cshtml", new DepartmentPsos { DeptId = departmentId });
        }

        // Submit Create PSO Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPsos(DepartmentPsos Pso)
        {
            ModelState.Remove("Dept"); // since it's virtual and not posted from form

            if (ModelState.IsValid)
            {
                _context.Add(Pso);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentPsos", new { departmentId = Pso.DeptId });
            }

            ViewBag.DepartmentId = Pso.DeptId;
            return View("~/Views/DepartmentPsos/Create.cshtml", Pso);
        }
        public async Task<IActionResult> DepartmentLabs(int departmentId)
        {
            var labs = await _context.DepartmentLabs
                .Where(l => l.DeptId == departmentId)
                .Include(l => l.Dept)
                .ToListAsync();

            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.DepartmentId = departmentId;

            return View("~/Views/DepartmentLabs/Index.cshtml", labs);
        }

        // Show Create Form
        public IActionResult AddLab(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View("~/Views/DepartmentLabs/Create.cshtml", new DepartmentLabs { DeptId = departmentId });
        }

        // Save New Lab
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLab(DepartmentLabs lab, IFormFile? LabImageFile)
        {
            ModelState.Remove("Dept"); // Skip validation for navigation property

            if (ModelState.IsValid)
            {
                // Upload image if provided
                if (LabImageFile != null && LabImageFile.Length > 0)
                {
                    var folderPath = Path.Combine("wwwroot", "Labs", lab.DeptId.ToString());
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var fileName = Path.GetFileName(LabImageFile.FileName);
                    var filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await LabImageFile.CopyToAsync(stream);
                    }

                    lab.LabImage = $"Labs/{lab.DeptId}/{fileName}";
                }

                _context.Add(lab);
                await _context.SaveChangesAsync();
                return RedirectToAction("DepartmentLabs", new { departmentId = lab.DeptId });
            }

            ViewBag.DepartmentId = lab.DeptId;
            return View("~/Views/DepartmentLabs/Create.cshtml", lab);
        }
        // Show Edit Form
        public async Task<IActionResult> EditLab(int id)
        {
            var lab = await _context.DepartmentLabs.FindAsync(id);
            if (lab == null) return NotFound();

            ViewBag.DepartmentId = lab.DeptId;
            return View("~/Views/DepartmentLabs/Edit.cshtml", lab);
        }

        // Handle Edit Submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLab(int id, DepartmentLabs lab, IFormFile? LabImageFile)
        {
            if (id != lab.LabId) return NotFound();
            ModelState.Remove("Dept");

            if (ModelState.IsValid)
            {
                try
                {
                    // Update image if uploaded
                    if (LabImageFile != null && LabImageFile.Length > 0)
                    {
                        var folderPath = Path.Combine("wwwroot", "Labs", lab.DeptId.ToString());
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        var fileName = Path.GetFileName(LabImageFile.FileName);
                        var filePath = Path.Combine(folderPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await LabImageFile.CopyToAsync(stream);
                        }

                        lab.LabImage = $"Labs/{lab.DeptId}/{fileName}";
                    }

                    _context.Update(lab);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("DepartmentLabs", new { departmentId = lab.DeptId });
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


