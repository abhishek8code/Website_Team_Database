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
    public class DepartmentPsoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentPsoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentPso
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext= _context.DepartmentPsos.Include(d => d.Dept);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: DepartmentPso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentPso = await _context.DepartmentPsos
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentPso == null)
            {
                return NotFound();
            }

            return View(departmentPso);
        }

        // GET: DepartmentPso/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: DepartmentPso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeptId,PsoText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentPso departmentPso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentPso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentPso.DeptId);
            return View(departmentPso);
        }

        // GET: DepartmentPso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentPso = await _context.DepartmentPsos.FindAsync(id);
            if (departmentPso == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentPso.DeptId);
            return View(departmentPso);
        }

        // POST: DepartmentPso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeptId,PsoText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentPso departmentPso)
        {
            if (id != departmentPso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentPso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentPsoExists(departmentPso.Id))
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
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentPso.DeptId);
            return View(departmentPso);
        }

        // GET: DepartmentPso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentPso = await _context.DepartmentPsos
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentPso == null)
            {
                return NotFound();
            }

            return View(departmentPso);
        }

        // POST: DepartmentPso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentPso = await _context.DepartmentPsos.FindAsync(id);
            if (departmentPso != null)
            {
                _context.DepartmentPsos.Remove(departmentPso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentPsoExists(int id)
        {
            return _context.DepartmentPsos.Any(e => e.Id == id);
        }
    }
}
