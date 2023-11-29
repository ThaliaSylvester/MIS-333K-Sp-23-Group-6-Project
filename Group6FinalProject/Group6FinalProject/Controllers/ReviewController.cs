using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group_6_Final_Project.DAL;
using Group_6_Final_Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Group6FinalProject.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Manager"))
            {
                var appDbContext = _context.Reviews.Include(r => r.Movies);
                return View(await appDbContext.ToListAsync());
            }
            else
            {
                var reviews = await _context.Reviews
                    .Where(r => r.Status == Status.Approved)
                    .Include(r => r.Movies)
                    .ToListAsync();

                return View(reviews);
            }
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Movies)
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create(string movieId)
        {
            if (string.IsNullOrEmpty(movieId))
            {
                // Handle the case where MovieID is not provided.
                // You may redirect to an error page or take appropriate action.
                return RedirectToAction("Index", "Home"); // Redirect to the home page as an example.
            }

            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "Title");
            ViewData["SelectedMovieID"] = movieId; // Add this line to pass the selected MovieID to the view.

            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("ReviewID,Rating,Description,Status,MovieID")] Review review)
{
    if (ModelState.IsValid)
    {
        // Get the user ID of the currently logged-in user
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Check if the user has already submitted a review for the same movie
        var existingReview = _context.Reviews
            .FirstOrDefault(r => r.MovieID == review.MovieID && r.UserID == userId);

        if (existingReview != null)
        {
            // Display an error message or handle the situation where the user has already submitted a review for the same movie.
            ModelState.AddModelError("DuplicateReview", "You have already submitted a review for this movie.");
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", review.MovieID);
            return View();
        }

        // Set the user ID for the review
        review.UserID = userId;

        // Set the default status for the review
        review.Status = Status.NeedsReview;

        _context.Add(review);
        await _context.SaveChangesAsync();
                return View();
            }

            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", review.MovieID);

            return RedirectToAction("Index");
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", review.MovieID);
            return View(review);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,Rating,Description,Status,UserID,MovieID")] Review review)
        {
            // Check if the user is a manager or employee
            if (User.IsInRole("Manager") || User.IsInRole("Employee"))
            {
                // Allow managers and employees to modify Rating and Description
                if (ModelState.IsValid)
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                // If the user is not a manager or employee, prevent modification of Rating and Description
                ModelState.AddModelError(string.Empty, "You do not have permission to perform this action.");
            }

            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", review.MovieID);
            return View(review);
        }
        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Movies)
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reviews == null)
            {
                return Problem("Entity set 'AppDbContext.Reviews'  is null.");
            }
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
          return (_context.Reviews?.Any(e => e.ReviewID == id)).GetValueOrDefault();
        }
    }
}
