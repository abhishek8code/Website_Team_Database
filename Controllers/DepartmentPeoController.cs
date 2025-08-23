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
    public class DepartmentPeoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentPeoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentPeo
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext= _context.DepartmentPeos.Include(d => d.Dept);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: DepartmentPeo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentPeo = await _context.DepartmentPeos
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentPeo == null)
            {
                return NotFound();
            }

            return View(departmentPeo);
        }

        // GET: DepartmentPeo/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: DepartmentPeo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeptId,PeoText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentPeo departmentPeo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentPeo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentPeo.DeptId);
            return View(departmentPeo);
        }

        // GET: DepartmentPeo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentPeo = await _context.DepartmentPeos.FindAsync(id);
            if (departmentPeo == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentPeo.DeptId);
            return View(departmentPeo);
        }

        // POST: DepartmentPeo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeptId,PeoText,CreatedDate,UpdatedDate,IsDeleted,CreatedDateInt,UpdatedDateInt")] DepartmentPeo departmentPeo)
        {
            if (id != departmentPeo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentPeo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentPeoExists(departmentPeo.Id))
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
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", departmentPeo.DeptId);
            return View(departmentPeo);
        }

        // GET: DepartmentPeo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentPeo = await _context.DepartmentPeos
                .Include(d => d.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentPeo == null)
            {
                return NotFound();
            }

            return View(departmentPeo);
        }

        // POST: DepartmentPeo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentPeo = await _context.DepartmentPeos.FindAsync(id);
            if (departmentPeo != null)
            {
                _context.DepartmentPeos.Remove(departmentPeo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentPeoExists(int id)
        {
            return _context.DepartmentPeos.Any(e => e.Id == id);
        }
    }
}
