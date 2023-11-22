using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group_6_Final_Project.Models;
using Group_6_Final_Project.DAL;

namespace Group_6_Final_Project.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index(string searchString)
        {
            // Retrieve movies including the Genre information and reviews
            var movies = await _context.Movies
                .Include(m => m.Genre)
                .Include(m => m.Review)
                .ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                // Convert both the search string and movie titles to lowercase for case-insensitive comparison
                var searchLower = searchString.ToLower();
                movies = movies.Where(m => m.Title.ToLower().Contains(searchLower)).ToList();

                // Check if a valid date string is provided
                if (DateTime.TryParse(searchString, out DateTime searchDate))
                {
                    // Convert the DateTime to an int (Unix timestamp, for example)
                    int searchTimestamp = Convert.ToInt32(searchDate.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

                    // Example: Search for movies with a published date equal to the specified value
                    movies = movies.Where(m => m.PublishedDate == searchTimestamp).ToList();
                }
            }

            // Calculate and store average ratings in a dictionary
            Dictionary<string, double> averageRatings = new Dictionary<string, double>();
            foreach (var movie in movies)
            {
                if (movie.Review != null && movie.Review.Any())
                {
                    double averageRating = movie.Review.Average(r => (int)r.Rating);
                    averageRatings.Add(movie.MovieID, averageRating);
                }
                else
                {
                    averageRatings.Add(movie.MovieID, 0.0); // Set default rating if no reviews
                }
            }

            ViewBag.AverageRatings = averageRatings;
            ViewBag.TotalMovieCount = movies.Count;
            ViewBag.CurrentlyShowingMovies = movies.Count;

            return View(movies);
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Genre) // Include the Genre information
                .FirstOrDefaultAsync(m => m.MovieID == id);

            if (movie == null)
            {
                return NotFound();
            }

            // Fetch reviews for the movie
            var reviews = await _context.Reviews
                .Where(r => r.MovieID == id)
                .ToListAsync();

            // Calculate average customer review
            double averageRating = reviews.Any() ? reviews.Average(r => (int)r.Rating) : 0.0;

            ViewBag.AverageCustomerReview = averageRating;

            // Pass the reviews to the view
            ViewBag.Reviews = reviews;

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            // Populate ViewBag.GenreList with available genres
            ViewBag.GenreList = new SelectList(_context.Genres, "GenreID", "Genres");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,MPAARating,Title,Description,Tagline,PublishedDate,Actors,Runtime,GenreID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Check ModelState errors here (use debugger)
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            // Add a breakpoint here to inspect errors

            ViewBag.GenreList = new SelectList(_context.Genres, "GenreID", "Genres", movie.GenreID);
            return View(movie);
        }


        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MovieID,MPAARating,Title,Description,Tagline,PublishedDate,Actors,Runtime")] Movie movie)
        {
            if (id != movie.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieID))
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
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'AppDbContext.Movies'  is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(string id)
        {
            return (_context.Movies?.Any(e => e.MovieID == id)).GetValueOrDefault();
        }
        // Allow user to run a detailed search for movies
        public IActionResult DetailedSearch()
        {
            ViewBag.GenreList = GetGenreSelectList();

            // Default properties
            SearchViewModel searchViewModel = new SearchViewModel();
            return View();
        }

        private SelectList GetGenreSelectList()
        {
            var genres = Enum.GetValues(typeof(GenreType))
                             .Cast<GenreType>()
                             .Select(g => new SelectListItem
                             {
                                 Value = ((int)g).ToString(),
                                 Text = g.ToString()
                             })
                             .ToList();

            genres.Insert(0, new SelectListItem { Value = "0", Text = "All Genres" });

            return new SelectList(genres, "Value", "Text");
        }

        public IActionResult DisplaySearchResults(SearchViewModel searchViewModel)
        {
            // Filter movies using LINQ
            var query = from movie in _context.Movies
                        select movie;

            // Check if user entered a title
            if (!string.IsNullOrEmpty(searchViewModel.SearchTitle))
            {
                query = query.Where(m => m.Title.Contains(searchViewModel.SearchTitle));
            }

            // Check if user entered a description
            if (!string.IsNullOrEmpty(searchViewModel.SearchDescription))
            {
                query = query.Where(m => m.Description.Contains(searchViewModel.SearchDescription));
            }

            // Checks if user entered a specific genre
            if (searchViewModel.SelectedGenreID.HasValue && searchViewModel.SelectedGenreID.Value != 0)
            {
                query = query.Where(m => m.GenreID == searchViewModel.SelectedGenreID);
            }

            if (searchViewModel.SelectedYear.HasValue)
            {
                // Example: Search for movies with published date greater than or less than the specified value
                if (searchViewModel.SearchType == SearchType.GreaterThan)
                {
                    query = query.Where(m => m.PublishedDate >= searchViewModel.SelectedYear.Value);
                }
                else if (searchViewModel.SearchType == SearchType.LessThan)
                {
                    query = query.Where(m => m.PublishedDate < searchViewModel.SelectedYear.Value);
                }
            }

            if (!string.IsNullOrEmpty(searchViewModel.SearchActors))
            {
                query = query.Where(m => m.Actors.Contains(searchViewModel.SearchActors));
            }

            if (searchViewModel.SelectedRuntime != null)
            {
                // Example: Search for movies with runtime greater than or less than the specified value
                if (searchViewModel.SearchType == SearchType.GreaterThan)
                {
                    query = query.Where(m => m.Runtime >= searchViewModel.SelectedRuntime);
                }
                else if (searchViewModel.SearchType == SearchType.LessThan)
                {
                    query = query.Where(m => m.Runtime <= searchViewModel.SelectedRuntime);
                }
            }

            // Filter movies based on user ratings
            if (searchViewModel.MinRating.HasValue)
            {
                // Assuming Rating is of type CustomerRating in your model
                query = query.Where(m => m.Review.Any(r => (decimal)r.Rating > (decimal)searchViewModel.MinRating.Value));
            }

            if (searchViewModel.MaxRating.HasValue)
            {
                // Assuming Rating is of type CustomerRating in your model
                query = query.Where(m => m.Review.Any(r => (decimal)r.Rating < searchViewModel.MaxRating.Value));
            }

            // Calculate average user rating for each selected movie
            Dictionary<string, double> averageRatings = new Dictionary<string, double>();
            foreach (var movie in query)
            {
                var ratings = _context.Reviews
                    .Where(review => review.MovieID == movie.MovieID && review.Status == Status.Approved)
                    .Select(review => (int)review.Rating);

                if (ratings.Any())
                {
                    averageRatings[movie.MovieID] = ratings.Average();
                }
                else
                {
                    // If no approved ratings are available, you can handle it accordingly
                    averageRatings[movie.MovieID] = 0; // or another default value
                }
            }

            // Pass the average ratings dictionary to the view
            ViewBag.AverageRatings = averageRatings;

            // Set the GenreList in ViewBag
            ViewBag.GenreList = GetGenreSelectList();

            List<Movie> selectedMovies = query.Include(m => m.Genre).ToList();

            ViewBag.AllMovies = _context.Movies.Count();
            ViewBag.SelectedMovies = selectedMovies.Count();

            // Update the ViewBag properties and return the Index view
            ViewBag.TotalMovieCount = selectedMovies.Count();
            ViewBag.CurrentlyShowingMovies = selectedMovies.Count();

            return View("Index", selectedMovies.OrderByDescending(m => m.PublishedDate));
        }
    }
}