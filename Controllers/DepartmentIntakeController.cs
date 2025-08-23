using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GECPATAN_FACULTY_PORTAL.Models;
using GECPATAN_FACULTY_PORTAL.Data;

namespace GECPATAN_FACULTY_PORTAL.Controllers
{
    public class DepartmentIntakeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentIntakeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentIntake
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext= _context.DepartmentIntakes.Include(d => d.Dept);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: DepartmentIntake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentIntake = await _context.DepartmentIntakes
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentIntake == null)
            {
                return NotFound();
            }

            return View(departmentIntake);
        }

        // GET: DepartmentIntake/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: DepartmentIntake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeptId,IntakeCount,IntakeYear,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentIntake departmentIntake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentIntake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentIntake.DeptId);
            return View(departmentIntake);
        }

        // GET: DepartmentIntake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentIntake = await _context.DepartmentIntakes.FindAsync(id);
            if (departmentIntake == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentIntake.DeptId);
            return View(departmentIntake);
        }

        // POST: DepartmentIntake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeptId,IntakeCount,IntakeYear,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentIntake departmentIntake)
        {
            if (id != departmentIntake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentIntake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentIntakeExists(departmentIntake.Id))
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
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentIntake.DeptId);
            return View(departmentIntake);
        }

        // GET: DepartmentIntake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentIntake = await _context.DepartmentIntakes
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentIntake == null)
            {
                return NotFound();
            }

            return View(departmentIntake);
        }

        // POST: DepartmentIntake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentIntake = await _context.DepartmentIntakes.FindAsync(id);
            if (departmentIntake != null)
            {
                _context.DepartmentIntakes.Remove(departmentIntake);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentIntakeExists(int id)
        {
            return _context.DepartmentIntakes.Any(e => e.Id == id);
        }
    }
}
