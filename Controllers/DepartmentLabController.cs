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
    public class DepartmentLabController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentLabController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentLab
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext= _context.DepartmentLabs.Include(d => d.Dept);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: DepartmentLab/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentLab = await _context.DepartmentLabs
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.LabId == id);
            if (departmentLab == null)
            {
                return NotFound();
            }

            return View(departmentLab);
        }

        // GET: DepartmentLab/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: DepartmentLab/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LabId,DeptId,LabName,LabImage,LabDetails,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentLab departmentLab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentLab.DeptId);
            return View(departmentLab);
        }

        // GET: DepartmentLab/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentLab = await _context.DepartmentLabs.FindAsync(id);
            if (departmentLab == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentLab.DeptId);
            return View(departmentLab);
        }

        // POST: DepartmentLab/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LabId,DeptId,LabName,LabImage,LabDetails,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentLab departmentLab)
        {
            if (id != departmentLab.LabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentLabExists(departmentLab.LabId))
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
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentLab.DeptId);
            return View(departmentLab);
        }

        // GET: DepartmentLab/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentLab = await _context.DepartmentLabs
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.LabId == id);
            if (departmentLab == null)
            {
                return NotFound();
            }

            return View(departmentLab);
        }

        // POST: DepartmentLab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentLab = await _context.DepartmentLabs.FindAsync(id);
            if (departmentLab != null)
            {
                _context.DepartmentLabs.Remove(departmentLab);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentLabExists(int id)
        {
            return _context.DepartmentLabs.Any(e => e.LabId == id);
        }
    }
}
