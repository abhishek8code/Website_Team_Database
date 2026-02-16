using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
    public async Task<IActionResult> ManageMission(int committeeId)
    {
        ViewBag.CommitteeId = committeeId;

        var missions = await _context.CommitteeMissions
            .Where(m => m.CommitteeId == committeeId && !m.IsDeleted)
            .OrderBy(m => m.Id)
            .ToListAsync();

        return View(missions);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddMission(CommitteeMission model)
    {
        if (ModelState.IsValid)
        {
            model.IsDeleted = false;

            model.CreatedDate = DateTime.Now;
            model.CreatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

            _context.CommitteeMissions.Add(model);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ManageMission),
            new { committeeId = model.CommitteeId });
    }
    public async Task<IActionResult> EditMission(int id)
    {
        var mission = await _context.CommitteeMissions.FindAsync(id);
        if (mission == null)
            return NotFound();

        return View(mission);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditMission(CommitteeMission model)
    {
        var missionInDb = await _context.CommitteeMissions
            .FirstOrDefaultAsync(m => m.Id == model.Id);

        if (missionInDb == null)
            return NotFound();

        missionInDb.MissionText = model.MissionText;

        missionInDb.UpdatedDate = DateTime.Now;
        missionInDb.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageMission),
            new { committeeId = missionInDb.CommitteeId });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteMission(int id)
    {
        var mission = await _context.CommitteeMissions.FindAsync(id);
        if (mission == null)
            return NotFound();

        int committeeId = mission.CommitteeId;
        // SOFT DELETE
        mission.IsDeleted = true;

        mission.UpdatedDate = DateTime.Now;
        mission.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();
        _context.CommitteeMissions.Remove(mission);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageMission),
            new { committeeId });
    }
    public async Task<IActionResult> ManageObjective(int committeeId)
    {
        ViewBag.CommitteeId = committeeId;

        var objectives = await _context.CommitteeObjectives
            .Where(o => o.CommitteeId == committeeId && !o.IsDeleted)
            .OrderBy(o => o.Id)
            .ToListAsync();

        return View(objectives);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddObjectives(CommitteeObjective model)
    {
        if (ModelState.IsValid)
        {
            model.IsDeleted = false;

            model.CreatedDate = DateTime.Now;
            model.CreatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

            _context.CommitteeObjectives.Add(model);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ManageObjective),
            new { committeeId = model.CommitteeId });
    }
    public async Task<IActionResult> EditObjectives(int id)
    {
        var objective = await _context.CommitteeObjectives
            .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);

        if (objective == null)
            return NotFound();

        return View(objective);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditObjectives(CommitteeObjective model)
    {
        var objectiveInDb = await _context.CommitteeObjectives
            .FirstOrDefaultAsync(o => o.Id == model.Id && !o.IsDeleted);

        if (objectiveInDb == null)
            return NotFound();

        objectiveInDb.ObjectiveText = model.ObjectiveText;

        objectiveInDb.UpdatedDate = DateTime.Now;
        objectiveInDb.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageObjective),
            new { committeeId = objectiveInDb.CommitteeId });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteObjective(int id)
    {
        var objective = await _context.CommitteeObjectives
            .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);

        if (objective == null)
            return NotFound();

        objective.IsDeleted = true;
        objective.UpdatedDate = DateTime.Now;
        objective.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageObjective),
            new { committeeId = objective.CommitteeId });
    }
    public async Task<IActionResult> ManageSubObjective(int committeeId)
    {
        ViewBag.CommitteeId = committeeId;

        var subObjectives = await _context.CommitteeSubObjectives
            .Where(s => s.CommitteeId == committeeId && !s.IsDeleted)
            .OrderBy(s => s.Id)
            .ToListAsync();

        return View(subObjectives);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddSubObjective(CommitteeSubObjective model)
    {
        if (ModelState.IsValid)
        {
            model.IsDeleted = false;
            model.CreatedDate = DateTime.Now;
            model.CreatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

            _context.CommitteeSubObjectives.Add(model);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ManageSubObjective),
            new { committeeId = model.CommitteeId });
    }
    public async Task<IActionResult> EditSubObjective(int id)
    {
        var subObjective = await _context.CommitteeSubObjectives
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        if (subObjective == null)
            return NotFound();

        return View(subObjective);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSubObjective(CommitteeSubObjective model)
    {
        var subObjectiveInDb = await _context.CommitteeSubObjectives
            .FirstOrDefaultAsync(s => s.Id == model.Id && !s.IsDeleted);

        if (subObjectiveInDb == null)
            return NotFound();

        subObjectiveInDb.SubObjectiveText = model.SubObjectiveText;
        subObjectiveInDb.UpdatedDate = DateTime.Now;
        subObjectiveInDb.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageSubObjective),
            new { committeeId = subObjectiveInDb.CommitteeId });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSubObjective(int id)
    {
        var subObjective = await _context.CommitteeSubObjectives
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        if (subObjective == null)
            return NotFound();

        subObjective.IsDeleted = true;
        subObjective.UpdatedDate = DateTime.Now;
        subObjective.UpdatedDateInt = DateTimeOffset.Now.ToUnixTimeSeconds();

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageSubObjective),
            new { committeeId = subObjective.CommitteeId });
    }

}
