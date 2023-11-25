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
        public async Task<IActionResult> Details(int? transactionid)
        {
            if (transactionid == null || _context.TransactionDetails == null)
            {
                return NotFound();
            }



            var transactionDetail = await _context.TransactionDetails
                //.Include(t => t.Schedule)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.TransactionDetailID == transactionid);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            return View(transactionDetail);
        }

        // GET: TransactionDetails/Create
        public IActionResult Create(int transactionID)
        {
            //create a new instance of the TransactionDetail class
            TransactionDetail td = new TransactionDetail();

            //find the transaction that should be associated with this transaction
            Transaction dbTransaction = _context.Transactions.Find(transactionID);

            //set the new transaction detail's transaction equal to the transaction you just found
            td.Transaction = dbTransaction;

            ViewBag.ScheduledMovies = GetScheduleSelectList();

            return View(td);
        }

        // POST: TransactionDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionDetail transactionDetail, int SelectedSchedule)
        {
            //if user has not entered all fields, send them back to try again
            //if (ModelState.IsValid == false)
            //{
            //    ViewBag.ScheduledMovies = GetScheduleSelectList();
            //    return View(transactionDetail);
            //}


            //find the scheudled movie  to be associated with this transaction
            Schedule dbSchedule = _context.Schedules.Find(SelectedSchedule);

            //set the transaction detail's scheduled movie to be equal to the one we just found
            transactionDetail.Schedule = dbSchedule;

            //find the transaction on the database that has the correct transaction id
            Transaction dbTransaction = _context.Transactions.Find(transactionDetail.Transaction.TransactionID);

            //set the transaction on the transaction detail equal to the transaction we just found
            transactionDetail.Transaction = dbTransaction;

            //set the transaction detail's price equal to the schedule's price
            //this allows us to store the price that the user paid
            transactionDetail.SchedulePrice = dbSchedule.SchedulePrice;

            //calculate the extended price for the transaction detail
            transactionDetail.ExtendedPrice = transactionDetail.NumberofTickets * transactionDetail.SchedulePrice;

            //add the transaction detail to the database
            _context.Add(transactionDetail);
            await _context.SaveChangesAsync();

            //send the user to the details page for this transaction
            return RedirectToAction("Details", "Transactions", new { id = transactionDetail.Transaction.TransactionID });

            //if (ModelState.IsValid == false)
            //{
            //    ViewBag.StartTimes = GetStartTime();
            //    ViewBag.Theatres = GetTheatre();
            //    return View(transactionDetail);
            //}

            // Find the ScheduleID based on the selected StartTime and Theatre
            //Schedule dbSchedules = _context.Schedules.FirstOrDefault(s => s.StartTime == new DateTime(SelectedStartTime) && s.Theatre == (Theatre)SelectedTheatre);


            //if (dbSchedules == null)
            //{
            //    ModelState.AddModelError(string.Empty, "Invalid StartTime and Theatre combination");
            //    ViewBag.StartTimes = GetStartTime();
            //    ViewBag.Theatres = GetTheatre();
            //    return View(transactionDetail);
            //}

            //transactionDetail.Schedule = dbSchedules;

            //Transaction dbTransactions = _context.Transactions.Find(transactionDetail.Transaction.TransactionID);
            //transactionDetail.Transaction = dbTransactions;

            //// Perform any other necessary logic here

            //_context.Add(transactionDetail);
            //await _context.SaveChangesAsync();

            //return RedirectToAction("Details", "Transactions", new { id = transactionDetail.Transaction.TransactionID });
        }



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

        // GET: TransactionDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactionDetails == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails
                //.Include(t => t.Schedule)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.TransactionDetailID == id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            return View(transactionDetail);
        }

        // POST: TransactionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransactionDetails == null)
            {
                return Problem("Entity set 'AppDbContext.TransactionDetails'  is null.");
            }
            var transactionDetail = await _context.TransactionDetails.FindAsync(id);
            if (transactionDetail != null)
            {
                _context.TransactionDetails.Remove(transactionDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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