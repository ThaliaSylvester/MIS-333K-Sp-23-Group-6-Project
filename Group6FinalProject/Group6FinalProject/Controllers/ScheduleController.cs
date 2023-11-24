using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group_6_Final_Project.DAL;
using Group_6_Final_Project.Models;

namespace Group6FinalProject.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly AppDbContext _context;

        public ScheduleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Schedule/Index
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Schedules.Include(s => s.Movie).Include(s => s.Price);
            ViewBag.AllMovieSchedule = appDbContext.Count();
            ViewBag.FilteredMovieSchedule = appDbContext.Count();
            return View(await appDbContext.ToListAsync());
        }

        // POST: Schedule/Index
        [HttpPost]
        public IActionResult Index(Theatre? selectedTheatre, DateTime? weekStartDate)
        {
            IQueryable<Schedule> schedulesQuery = _context.Schedules.Include(s => s.Movie).Include(s => s.Price);

            ViewBag.AllMovieSchedule = schedulesQuery.Count();

            // Check if a specific theater is selected
            if (selectedTheatre.HasValue)
            {
                schedulesQuery = schedulesQuery.Where(s => s.Theatre == selectedTheatre.Value);
            }

            // Check start date
            if (weekStartDate.HasValue)
            {
                var weekEndDate = weekStartDate.Value.AddDays(6);
                ViewBag.EndDate = weekEndDate;
                schedulesQuery = schedulesQuery.Where(s => s.StartTime.Date >= weekStartDate.Value.Date && s.StartTime.Date <= weekEndDate.Date);
            }

            var schedules = schedulesQuery.ToList();
            ViewBag.FilteredMovieSchedule = schedules.Count();
            ViewBag.SelectedTheatre = selectedTheatre;
            ViewBag.SelectedWeekStartDate = weekStartDate;
            return View("Index", schedules);
        }

        // GET: Schedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Movie)
                .Include(s => s.Price)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedule/Create
        public IActionResult Create()
        {
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID");
            ViewData["PriceID"] = new SelectList(_context.Prices, "PriceID", "PriceID");
            return View();
        }

        // POST: Schedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleID,StartTime,EndTime,Theatre,PriceID,MovieID")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", schedule.MovieID);
            ViewData["PriceID"] = new SelectList(_context.Prices, "PriceID", "PriceID", schedule.PriceID);
            return View(schedule);
        }

        // GET: Schedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", schedule.MovieID);
            ViewData["PriceID"] = new SelectList(_context.Prices, "PriceID", "PriceID", schedule.PriceID);
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleID,StartTime,EndTime,Theatre,PriceID,MovieID")] Schedule schedule)
        {
            if (id != schedule.ScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleID))
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
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", schedule.MovieID);
            ViewData["PriceID"] = new SelectList(_context.Prices, "PriceID", "PriceID", schedule.PriceID);
            return View(schedule);
        }

        // GET: Schedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Movie)
                .Include(s => s.Price)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Schedules == null)
            {
                return Problem("Entity set 'AppDbContext.Schedules'  is null.");
            }
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return (_context.Schedules?.Any(e => e.ScheduleID == id)).GetValueOrDefault();
        }
    }
}
