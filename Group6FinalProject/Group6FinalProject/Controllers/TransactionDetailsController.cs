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
    public class TransactionDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TransactionDetails
        public IActionResult Index(int? transactionID)
        {
            if (transactionID == null)
            {
                return View("Error", new String[] { "Please specify an transaction to view!" });
            }

            List<TransactionDetail> ods = _context.TransactionDetails
                                          .Include(od => od.Schedule)
                                          .ThenInclude(od => od.Movie)
                                          .Where(od => od.Transaction.TransactionID == transactionID)
                                          .ToList();

            return View(ods);
        }

        // GET: TransactionDetails/Create
        //public async Task<IActionResult> Create(int transactionID, string movieId, int scheduleId)
        //{
        //    //create a new instance of the TransactionDetail class
        //    TransactionDetail td = new TransactionDetail();

        //    //find the transaction that should be associated with this transaction
        //    Transaction dbTransaction = _context.Transactions.Find(transactionID);

        //    //set the new transaction detail's transaction equal to the transaction you just found
        //    td.Transaction = dbTransaction;

        //    return View(td);
        //}

        // GET: TransactionDetails/Create
        public async Task<IActionResult> Create(int transactionID, string movieId, int scheduleId)
        {
            // Find the transaction in the database
            Transaction dbTransaction = await _context.Transactions.FindAsync(transactionID);

            if (dbTransaction == null)
            {
                // Handle invalid transaction ID
                return RedirectToAction("Index", "Home");
            }

            // Find MovieTitle using MovieID
            var movieTitle = await _context.Movies
                                      .Where(m => m.MovieID == movieId)
                                      .Select(m => m.Title)
                                      .FirstOrDefaultAsync();
            ViewBag.SelectedMovieTitle = movieTitle;
            ViewBag.ScheduleID = scheduleId;

            // Create a new instance of the TransactionDetail class
            TransactionDetail td = new TransactionDetail
            {
                Transaction = dbTransaction,

            };

            // Now you can use the 'scheduleId' within this action as needed

            return View(td);
        }

        // POST: TransactionDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid == false)
            {
                return View(transactionDetail);
            }

            // Check if the selected schedule is valid
            var selectedScheduleId = ViewBag.SelectedScheduleTime;
            Schedule dbSchedule = _context.Schedules.Find(selectedScheduleId);

            //if (dbSchedule == null)
            //{
            //    // Handle invalid schedule
            //    ModelState.AddModelError(string.Empty, "Invalid schedule selected.");
            //    return View(transactionDetail);
            //}

            // Find transaction in the database
            Transaction dbTransaction = _context.Transactions.Find(transactionDetail.Transaction.TransactionID);

            if (dbTransaction == null)
            {
                // Handle invalid transaction
                ModelState.AddModelError(string.Empty, "Invalid transaction.");
                return View(transactionDetail);
            }

            // Set transaction detail's schedule to be equal to the one we found
            transactionDetail.Schedule = dbSchedule;

            // Set all the detail properties based on your business logic

            // Add transaction detail to the database
            dbTransaction.TransactionDetail.Add(transactionDetail);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Send the user to the details page for the transaction
            return RedirectToAction("Details", "Transaction", new { id = transactionDetail.Transaction.TransactionID });
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(TransactionDetail transactionDetail)
        //{
        //    // Verify user entered in all fields
        //    if (ModelState.IsValid == false)
        //    {
        //        return View(transactionDetail);
        //    }

        //    var SelectedSchedule = ViewBag.SelectedScheduleTime;

        //    // Find schedule associated with transaction
        //    Schedule dbSchedule = _context.Schedules.Find(SelectedSchedule);

        //    // Set transaction detail's schedule to be equal to one we found
        //    transactionDetail.Schedule = dbSchedule;

        //    // Find transaction in database
        //    Transaction dbTransaction = _context.Transactions.Find(transactionDetail.Transaction.TransactionID);

        //    // Still need to set all the detail properties

        //    // Add transaction detail to database
        //    _context.Add(transactionDetail);
        //    await _context.SaveChangesAsync();

        //    // Send user to details page for transaction
        //    return RedirectToAction("Details", "Transaction", new { id = transactionDetail.Transaction.TransactionID });
        //}   



        // GET: TransactionDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransactionDetails == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails.FindAsync(id);
            if (transactionDetail == null)
            {
                return NotFound();
            }
            //ViewData["ScheduleID"] = new SelectList(_context.Schedules, "ScheduleID", "ScheduleID", transactionDetail.ScheduleID);
            ViewData["TransactionID"] = new SelectList(_context.Transactions, "TransactionID", "TransactionID", transactionDetail.TransactionID);
            return View(transactionDetail);
        }

        // POST: TransactionDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TransactionDetail transactionDetail)
        {
            if (id != transactionDetail.TransactionDetailID)
            {
                return View("Error", new String[] { "There was a problem editing this record. Try again!" });
            }

            TransactionDetail dbOD;
            try
            {
                dbOD = _context.TransactionDetails
                      //.Include(od => od.Schedule)
                      .Include(od => od.Transaction)
                      .FirstOrDefault(od => od.TransactionDetailID == transactionDetail.TransactionDetailID);

                if (ModelState.IsValid == false)
                {
                    return View(transactionDetail);
                }

                //dbOD.NumberOfTickets = transactionDetail.NumberOfTickets;
                //dbOD.SchedulePrice = dbOD.Schedule.SchedulePrice;
                //dbOD.ExtendedPrice = dbOD.Quantity * dbOD.ProductPrice;

                _context.Update(dbOD);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was a problem editing this record", ex.Message });
            }

            return RedirectToAction("Details", "Transaction", new { id = dbOD.Transaction.TransactionID });
        }


        //private SelectList GetProductSelectList()
        //{
        //    List<Schedule> allProducts = _context.Schedules.ToList();

        //    // Create a list of SelectListItem using ScheduleID and other properties from the Schedule model
        //    var productItems = allProducts.Select(schedule => new SelectListItem
        //    {
        //        // Assuming ScheduleID, StartTime, and Theatre are properties of the Schedule model
        //        Value = $"{schedule.ScheduleID}",
        //        Text = $"{schedule.StartTime:yyyy-MM-dd HH:mm} - Theatre {schedule.Theatre}"
        //    }).ToList();

        //    // Create the SelectList
        //    SelectList slAllProducts = new SelectList(productItems, "Value", "Text");

        //    return slAllProducts;
        //}
        private SelectList GetStartTime()
        {
            List<Schedule> allStartTime = _context.Schedules.ToList();

            SelectList slallStartTime = new SelectList(allStartTime, nameof(Schedule.ScheduleID), nameof(Schedule.StartTime));

            return slallStartTime;
        }
        //private SelectList GetTheatre()
        //{
        //    List<Schedule> allTheatre = _context.Schedules.ToList();

        //    SelectList slallTheatre = new SelectList(allTheatre, nameof(Schedule.ScheduleID), nameof(Schedule.Theatre));

        //    return slallTheatre;
        //}

        private SelectList GetScheduleSelectList()
        {
            //create a list for all the scheduled movies
            List<Schedule> allScheduledMovies = _context.Schedules.ToList();

            //the user MUST select a scheduled movie, so you don't need a dummy option for no movie

            //use the constructor on select list to create a new select list with the options
            SelectList GetAllScheduledMovies = new SelectList(allScheduledMovies, nameof(Schedule.ScheduleID), nameof(Schedule.Theatre), nameof(Schedule.StartTime));

            return GetAllScheduledMovies;
        }
    }
}