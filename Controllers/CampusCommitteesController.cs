using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CampusCommitteesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CampusCommitteesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ======================
    // INDEX
    // ======================
    public IActionResult Index()
    {
        var committees = _context.CampusCommittees
            .Where(x => !x.IsDeleted)
            .ToList();

        return View(committees);
    }

    // ======================
    // CREATE (GET)
    // ======================
    public IActionResult Create()
    {
        return View();
    }

    // ======================
    // CREATE (POST)
    // ======================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CampusCommittee model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _context.CampusCommittees.Add(model);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // ======================
    // EDIT (GET)
    // ======================
    public IActionResult Edit(int id)
    {
        var committee = _context.CampusCommittees
            .FirstOrDefault(x => x.Id == id && !x.IsDeleted);

        if (committee == null)
            return NotFound();

        return View(committee);
    }

    // ======================
    // EDIT (POST)
    // ======================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CampusCommittee model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _context.CampusCommittees.Update(model);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // ======================
    // DETAILS
    // ======================
    public IActionResult Details(int id)
    {
        var committee = _context.CampusCommittees
            .FirstOrDefault(x => x.Id == id && !x.IsDeleted);

        if (committee == null)
            return NotFound();

        return View(committee);
    }

    // ======================
    // DELETE (SOFT DELETE)
    // ======================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var committee = _context.CampusCommittees
            .FirstOrDefault(x => x.Id == id && !x.IsDeleted);

        if (committee == null)
            return NotFound();

        committee.IsDeleted = true;
        _context.Update(committee);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    //----------------
    //VISION----------
    //----------------
    public async Task<IActionResult> ManageVision(int committeeId)
    {
        var vision = await _context.CommitteeVisions
            .FirstOrDefaultAsync(v => v.CommitteeId == committeeId);

        if (vision == null)
        {
            return View("VisionManage", new CommitteeVision
            {
                CommitteeId = committeeId
            });
        }

        return View("VisionManage", vision);
    }

    public async Task<IActionResult> Vision(int id)
    {
        var vision = await _context.CommitteeVisions
            .FirstOrDefaultAsync(v => v.CommitteeId == id);

        if (vision == null)
        {
            // No vision → go to manage (add)
            return RedirectToAction(nameof(ManageVision), new { committeeId = id });
        }

        // Vision exists → show details
        return View("VisionDetails", vision);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ManageVision(CommitteeVision model)
    {
        var visionInDb = await _context.CommitteeVisions
            .FirstOrDefaultAsync(v => v.CommitteeId == model.CommitteeId);

        if (visionInDb == null)
        {
            // ADD
            _context.CommitteeVisions.Add(model);
        }
        else
        {
            // EDIT
            visionInDb.VisionText = model.VisionText;
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Vision), new { id = model.CommitteeId });
    }

}
