using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Project_Final1.Data;
using Project_Final1.Models;

namespace Project_Final1.Controllers
{
    public class RegistersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index(String sortBy)
        {
            ViewData["Title"] = "Registeration List";

            var registers = await _context.Register
                .Include(r => r.Student)
                .Include(r => r.Course)
                .Where(t => t.Semester == eSemester.First)
                .ToListAsync();

            switch (sortBy)
            {
                case "Ascending":
                    registers = registers.OrderBy(r => r.Grade).ToList();
                    break;
                case "Descending":
                    registers = registers.OrderByDescending(t => t.Grade).ToList();
                    break;
                default:
                    registers = registers.OrderBy(t => t.Grade).ToList();
                    break;
            }

            return View(registers);
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Title"] = "Registeration Details";

            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .Include(r => r.Student)
                .Include(r => r.Course)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Add Registeration";

            ViewData["Student"] = new SelectList(_context.Student, "StudentId", "Name");
            ViewData["Course"] = new SelectList(_context.Course, "CourseId", "Subject");

            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,TeacherName,Grade,StartTime,Semester,StudentId,CourseId")] Register register)
        {
            ViewBag.Title = "Add Registeration";

            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If the model state is not valid, repopulate the ViewBag
            ViewBag.Student = new SelectList(_context.Student, "StudentId", "Name", register.StudentId);
            ViewBag.Course = new SelectList(_context.Course, "CourseId", "Subject", register.CourseId);

            return View(register);
        }


        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Title"] = "Edit Registeration";

            ViewData["Student"] = new SelectList(_context.Student, "StudentId", "Name");
            ViewData["Course"] = new SelectList(_context.Course, "CourseId", "Subject");

            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Number,TeacherName,Grade,StartTime,Semester")] Register register)
        
       {
            ViewData["Title"] = "Edit Registeration";

            if (id != register.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Number))
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
            ViewBag.Student = new SelectList(_context.Student, "StudentId", "Name", register.StudentId);
            ViewBag.Course = new SelectList(_context.Course, "CourseId", "Subject", register.CourseId);

            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Title"] = "Delete Registeration";
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .Include(r => r.Student)
                .Include(r => r.Course)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Title"] = "Delete Registeration";

            var register = await _context.Register.FindAsync(id);
            if (register != null)
            {
                _context.Register.Remove(register);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.Number == id);
        }
    }
}
