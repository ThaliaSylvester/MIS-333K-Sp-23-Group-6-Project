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
            // Setup list of reviews to display
            List<Review> reviews;

            reviews = _context.Reviews
                      .Include(r => r.Movies)
                      .ToList();

            return View(reviews);

        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return View("Error", new String[] { "Please specify a review to view!" });
            }

            Review review = await _context.Reviews
                            .Include(r => r.Movies)
                            .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review == null)
            {
                return View("Error", new String[] { "That review was not found." });
            }

            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create(string movieId)
        {
            if (movieId == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.MovieID = new SelectList(_context.Movies, "MovieID", "Title");
            ViewBag.SelectedMovieID = movieId;

            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([Bind("Rating, Description, MovieID")] Review review)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Check if the user has already submitted a review for the same movie
                var existingReview = _context.Reviews
                    .FirstOrDefault(r => r.MovieID == review.MovieID && r.UserID == userId);

                if (existingReview != null)
                {
                    ViewBag.ReviewCreateError = "You have already submitted a review for this movie.";
                    ViewBag.MovieID = new SelectList(_context.Movies, "MovieID", "Title", review.MovieID);
                    return View(review);
                }

                // Set additional properties for the review
                review.UserID = userId;
                review.Status = Status.NeedsReview;

                // Add the review to the database
                _context.Add(review);
                await _context.SaveChangesAsync();

                // Redirect the user to the review index page
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, reload the view with the form data
            ViewBag.MovieID = new SelectList(_context.Movies, "MovieID", "Title", review.MovieID);
            return View(review);
        }



        //public async Task<IActionResult> Create([Bind("")] Review review)
        //{

        //    if (ModelState.IsValid == false)
        //    {
        //        ViewBag.MovieID = new SelectList(_context.Movies, "MovieID", "Title", review.MovieID);
        //        return View(review);
        //    }

        //    // Get the user ID of the currently logged-in user
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    // Check if the user has already submitted a review for the same movie
        //    var existingReview = _context.Reviews
        //        .FirstOrDefault(r => r.MovieID == review.MovieID && r.UserID == userId);

        //    // Check to see if user has already made a review for that movie
        //    if (existingReview != null)
        //    {
        //        //ModelState.AddModelError("DuplicateReview", "You have already submitted a review for this movie.");
        //        ViewBag.MovieID = new SelectList(_context.Movies, "MovieID", "Title", review.MovieID);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    // Set the user ID for the review
        //    review.UserID = userId;

        //    // Set the default status for the review
        //    review.Status = Status.NeedsReview;

        //    _context.Add(review);
        //    await _context.SaveChangesAsync();

        //    //Send the user to the page with all the departments
        //    return RedirectToAction(nameof(Index));
        //}

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
