using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

public class FacultyController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;
    public FacultyController(ApplicationDbContext context,IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    // LIST
    public async Task<IActionResult> Index()
    {
        var faculties = await _context.Faculties
            .Where(f => f.IsActive)
            .OrderBy(f => f.SeniorityOrder)
            .ToListAsync();

        return View(faculties);
    }

    // DETAILS
    public async Task<IActionResult> Details(int id)
    {
        var faculty = await _context.Faculties
            .FirstOrDefaultAsync(f => f.FacultyId == id);

        if (faculty == null)
            return NotFound();

        return View(faculty);
    }

    // CREATE (GET)
    public IActionResult Create()
    {
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Faculty faculty, IFormFile Photo)
    {
        if (!ModelState.IsValid)
        {
            return View(faculty);
        }

        // 🔹 Handle Faculty Photo Upload
        if (Photo != null && Photo.Length > 0)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "faculty");

            // Ensure directory exists
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileExtension = Path.GetExtension(Photo.FileName);
            string fileName = Guid.NewGuid().ToString() + fileExtension;
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Photo.CopyToAsync(stream);
            }

            // Save relative path in DB
            faculty.ImagePath = "/uploads/faculty/" + fileName;
        }
        else
        {
            faculty.ImagePath = null; // optional, safe
        }

        // 🔹 Save Faculty
        _context.Faculties.Add(faculty);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // EDIT (GET)
    public async Task<IActionResult> Edit(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty == null)
            return NotFound();

        return View(faculty);
    }

    // EDIT (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Faculty faculty, IFormFile Photo)
    {
        if (id != faculty.FacultyId)
            return NotFound();

        if (!ModelState.IsValid)
            return View(faculty);

        // Get existing record (to preserve old image)
        var existingFaculty = await _context.Faculties
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.FacultyId == id);

        if (existingFaculty == null)
            return NotFound();

        // 🔹 Handle Photo Replace
        if (Photo != null && Photo.Length > 0)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "faculty");
            Directory.CreateDirectory(uploadsFolder);

            string fileName = Guid.NewGuid() + Path.GetExtension(Photo.FileName);
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Photo.CopyToAsync(stream);
            }

            // 🔥 Delete old image (optional but recommended)
            if (!string.IsNullOrEmpty(existingFaculty.ImagePath))
            {
                string oldImagePath = Path.Combine(
                    _env.WebRootPath,
                    existingFaculty.ImagePath.TrimStart('/')
                );

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            faculty.ImagePath = "/uploads/faculty/" + fileName;
        }
        else
        {
            // Keep old image
            faculty.ImagePath = existingFaculty.ImagePath;
        }

        _context.Update(faculty);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // DELETE (Soft Delete)
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty != null)
        {
            faculty.IsActive = false;
            _context.Update(faculty);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Experience(int id) // id = FacultyId
    {
        ViewBag.FacultyId = id;

        var list = await _context.ProfessionalExperiences
            .Where(x => x.FacultyId == id)
            .ToListAsync();

        return View(list);
    }
    public IActionResult CreateExperience(int id) // id = FacultyId
    {
        ViewBag.FacultyId = id;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateExperience(ProfessionalExperience model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.FacultyId = model.FacultyId;
            return View(model);
        }

        _context.ProfessionalExperiences.Add(model);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Experience), new { id = model.FacultyId });
    }
    public async Task<IActionResult> EditExperience(int id)
    {
        var exp = await _context.ProfessionalExperiences.FindAsync(id);
        if (exp == null)
            return NotFound();

        return View(exp);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditExperience(ProfessionalExperience model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _context.Update(model);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Experience), new { id = model.FacultyId });
    }
    public async Task<IActionResult> DeleteExperience(int id)
    {
        var exp = await _context.ProfessionalExperiences.FindAsync(id);
        if (exp == null)
            return NotFound();

        int facultyId = exp.FacultyId;

        _context.ProfessionalExperiences.Remove(exp);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Experience), new { id = facultyId });
    }
    public async Task<IActionResult> Training(int id) // id = FacultyId
    {
        ViewBag.FacultyId = id;

        var list = await _context.TrainingAndWorkshops
            .Where(x => x.FacultyId == id)
            .ToListAsync();

        return View(list);
    }
    public IActionResult CreateTraining(int id) // id = FacultyId
    {
        ViewBag.FacultyId = id;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateTraining(TrainingAndWorkshop model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.FacultyId = model.FacultyId;
            return View(model);
        }

        _context.TrainingAndWorkshops.Add(model);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Training), new { id = model.FacultyId });
    }
    public async Task<IActionResult> EditTraining(int id)
    {
        var training = await _context.TrainingAndWorkshops.FindAsync(id);
        if (training == null)
            return NotFound();

        return View(training);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditTraining(TrainingAndWorkshop model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _context.Update(model);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Training), new { id = model.FacultyId });
    }
    public async Task<IActionResult> DeleteTraining(int id)
    {
        var training = await _context.TrainingAndWorkshops.FindAsync(id);
        if (training == null)
            return NotFound();

        int facultyId = training.FacultyId;

        _context.TrainingAndWorkshops.Remove(training);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Training), new { id = facultyId });
    }
    public async Task<IActionResult> Publication(int id) // id = FacultyId
    {
        ViewBag.FacultyId = id;

        var list = await _context.Publications
            .Where(x => x.FacultyId == id)
            .OrderBy(x => x.SrNo)
            .ToListAsync();

        return View(list);
    }
    public IActionResult CreatePublication(int id) // id = FacultyId
    {
        ViewBag.FacultyId = id;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePublication(Publication model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.FacultyId = model.FacultyId;
            return View(model);
        }

        _context.Publications.Add(model);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Publication), new { id = model.FacultyId });
    }
    public async Task<IActionResult> EditPublication(int id)
    {
        var pub = await _context.Publications.FindAsync(id);
        if (pub == null)
            return NotFound();

        return View(pub);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPublication(Publication model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _context.Update(model);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Publication), new { id = model.FacultyId });
    }
    public async Task<IActionResult> DeletePublication(int id)
    {
        var pub = await _context.Publications.FindAsync(id);
        if (pub == null)
            return NotFound();

        int facultyId = pub.FacultyId;

        _context.Publications.Remove(pub);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Publication), new { id = facultyId });
    }

}
