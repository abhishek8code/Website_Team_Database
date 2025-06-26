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
    public class FacultyMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacultyMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacultyMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FacultyMember.ToListAsync());
        }

        // GET: FacultyMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultyMember == null)
            {
                return NotFound();
            }

            return View(facultyMember);
        }

        // GET: FacultyMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacultyMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Designation,EmailID,Department")] FacultyMember facultyMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultyMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultyMember);
        }

        // GET: FacultyMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMember.FindAsync(id);
            if (facultyMember == null)
            {
                return NotFound();
            }
            return View(facultyMember);
        }

        // POST: FacultyMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Designation,EmailID,Department")] FacultyMember facultyMember)
        {
            if (id != facultyMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultyMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyMemberExists(facultyMember.Id))
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
            return View(facultyMember);
        }

        // GET: FacultyMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultyMember == null)
            {
                return NotFound();
            }

            return View(facultyMember);
        }

        // POST: FacultyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultyMember = await _context.FacultyMember.FindAsync(id);
            if (facultyMember != null)
            {
                _context.FacultyMember.Remove(facultyMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyMemberExists(int id)
        {
            return _context.FacultyMember.Any(e => e.Id == id);
        }
    }
}
