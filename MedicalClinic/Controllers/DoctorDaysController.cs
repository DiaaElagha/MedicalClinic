using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Data;
using MedicalClinic.Models;

namespace MedicalClinic.Controllers
{
    public class DoctorDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoctorDays
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DoctorDays.Include(d => d.Doctor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DoctorDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDays = await _context.DoctorDays
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorDays == null)
            {
                return NotFound();
            }

            return View(doctorDays);
        }

        // GET: DoctorDays/Create
        public IActionResult Create()
        {
            DayOfWeek[] days = {
                DayOfWeek.Sunday,
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday
            };
            ViewBag.days = days;
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "FullName");
            return View();
        }

        // POST: DoctorDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Day,DoctorId,Id")] DoctorDays doctorDays)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorDays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "FullName", doctorDays.DoctorId);
            return View(doctorDays);
        }

        // GET: DoctorDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDays = await _context.DoctorDays.FindAsync(id);
            if (doctorDays == null)
            {
                return NotFound();
            }
            DayOfWeek[] days = {
                DayOfWeek.Sunday,
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday
            };
            ViewBag.days = days;
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "FullName", doctorDays.DoctorId);
            return View(doctorDays);
        }

        // POST: DoctorDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Day,DoctorId,Id")] DoctorDays doctorDays)
        {
            if (id != doctorDays.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorDays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorDaysExists(doctorDays.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "FullName", doctorDays.DoctorId);
            return View(doctorDays);
        }

        // GET: DoctorDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDays = await _context.DoctorDays
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorDays == null)
            {
                return NotFound();
            }

            return View(doctorDays);
        }

        // POST: DoctorDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorDays = await _context.DoctorDays.FindAsync(id);
            _context.DoctorDays.Remove(doctorDays);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorDaysExists(int id)
        {
            return _context.DoctorDays.Any(e => e.Id == id);
        }
    }
}
