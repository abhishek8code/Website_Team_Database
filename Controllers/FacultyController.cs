using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FacultyController : Controller
{
    private readonly ApplicationDbContext _context;

    public FacultyController(ApplicationDbContext context)
    {
        _context = context;
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
    public async Task<IActionResult> Create(Faculty faculty)
    {
        Console.WriteLine("CREATE POST HIT");

        if (!ModelState.IsValid)
        {
            return View(faculty);
        }

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
    public async Task<IActionResult> Edit(int id, Faculty faculty)
    {
        if (id != faculty.FacultyId)
            return NotFound();

        if (!ModelState.IsValid)
            return View(faculty);

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
}
