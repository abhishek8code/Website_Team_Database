using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GECPATAN_FACULTY_PORTAL.Data;
using GECPATAN_FACULTY_PORTAL.Models;

namespace GECPATAN_FACULTY_PORTAL.Controllers
{
    public class DepartmentMissionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentMissionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentMission
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext= _context.DepartmentMissions.Include(d => d.Dept);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: DepartmentMission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentMission = await _context.DepartmentMissions
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentMission == null)
            {
                return NotFound();
            }

            return View(departmentMission);
        }

        // GET: DepartmentMission/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: DepartmentMission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeptId,MissionText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentMission departmentMission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentMission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentMission.DeptId);
            return View(departmentMission);
        }

        // GET: DepartmentMission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentMission = await _context.DepartmentMissions.FindAsync(id);
            if (departmentMission == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentMission.DeptId);
            return View(departmentMission);
        }

        // POST: DepartmentMission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeptId,MissionText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentMission departmentMission)
        {
            if (id != departmentMission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentMission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentMissionExists(departmentMission.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentMission.DeptId);
            return View(departmentMission);
        }

        // GET: DepartmentMission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentMission = await _context.DepartmentMissions
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentMission == null)
            {
                return NotFound();
            }

            return View(departmentMission);
        }

        // POST: DepartmentMission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentMission = await _context.DepartmentMissions.FindAsync(id);
            if (departmentMission != null)
            {
                _context.DepartmentMissions.Remove(departmentMission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentMissionExists(int id)
        {
            return _context.DepartmentMissions.Any(e => e.Id == id);
        }
    }
}
