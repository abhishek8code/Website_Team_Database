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
    public class DepartmentVisionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentVisionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentVision
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext= _context.DepartmentVisions.Include(d => d.Dept);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: DepartmentVision/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentVision = await _context.DepartmentVisions
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentVision == null)
            {
                return NotFound();
            }

            return View(departmentVision);
        }

        // GET: DepartmentVision/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: DepartmentVision/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeptId,VisionText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentVision departmentVision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentVision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentVision.DeptId);
            return View(departmentVision);
        }

        // GET: DepartmentVision/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentVision = await _context.DepartmentVisions.FindAsync(id);
            if (departmentVision == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentVision.DeptId);
            return View(departmentVision);
        }

        // POST: DepartmentVision/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeptId,VisionText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentVision departmentVision)
        {
            if (id != departmentVision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentVision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentVisionExists(departmentVision.Id))
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
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentVision.DeptId);
            return View(departmentVision);
        }

        // GET: DepartmentVision/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentVision = await _context.DepartmentVisions
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentVision == null)
            {
                return NotFound();
            }

            return View(departmentVision);
        }

        // POST: DepartmentVision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentVision = await _context.DepartmentVisions.FindAsync(id);
            if (departmentVision != null)
            {
                _context.DepartmentVisions.Remove(departmentVision);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentVisionExists(int id)
        {
            return _context.DepartmentVisions.Any(e => e.Id == id);
        }
    }
}
