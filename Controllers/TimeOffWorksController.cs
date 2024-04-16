using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeePortal.Data;
using EmployeePortal.Models;

namespace EmployeePortal.Controllers
{
    public class TimeOffWorksController : Controller
    {
        private readonly EmployeePortalDbContext _context;

        public TimeOffWorksController(EmployeePortalDbContext context)
        {
            _context = context;
        }

        // GET: TimeOffWorks
        public async Task<IActionResult> Index()
        {
            var employeePortalDbContext = _context.timeOffWorks.Include(t => t.Employee);
            return View(await employeePortalDbContext.ToListAsync());
        }

        public async Task<IActionResult> ShowTimeOffWork()
        {
            var employeePortalDbContext = _context.timeOffWorks.Include(t => t.Employee);
            return View(await employeePortalDbContext.ToListAsync());
        }

        // GET: TimeOffWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOffWork = await _context.timeOffWorks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimeOffWorkId == id);
            if (timeOffWork == null)
            {
                return NotFound();
            }

            return View(timeOffWork);
        }

        // GET: TimeOffWorks/Create
        public IActionResult Create()
        {

            List<string> offTimeType = new List<string>()
            {
                "Vabb",
                "Semester",
                "Tjänstledighet"

            };

            ViewBag.OffTimeType = new SelectList(offTimeType);

            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View();
        }



        

        // POST: TimeOffWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeOffWorkId,TimeOffWorkType,StartDate,EndDate,FkEmployeeId")] TimeOffWork timeOffWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeOffWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timeOffWork.FkEmployeeId);
            return View(timeOffWork);
        }

        // GET: TimeOffWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOffWork = await _context.timeOffWorks.FindAsync(id);
            if (timeOffWork == null)
            {
                return NotFound();
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timeOffWork.FkEmployeeId);
            return View(timeOffWork);
        }

        // POST: TimeOffWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeOffWorkId,TimeOffWorkType,StartDate,EndDate,FkEmployeeId")] TimeOffWork timeOffWork)
        {
            if (id != timeOffWork.TimeOffWorkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeOffWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeOffWorkExists(timeOffWork.TimeOffWorkId))
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
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timeOffWork.FkEmployeeId);
            return View(timeOffWork);
        }

        // GET: TimeOffWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOffWork = await _context.timeOffWorks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimeOffWorkId == id);
            if (timeOffWork == null)
            {
                return NotFound();
            }

            return View(timeOffWork);
        }

        // POST: TimeOffWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeOffWork = await _context.timeOffWorks.FindAsync(id);
            if (timeOffWork != null)
            {
                _context.timeOffWorks.Remove(timeOffWork);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeOffWorkExists(int id)
        {
            return _context.timeOffWorks.Any(e => e.TimeOffWorkId == id);
        }
    }
}
