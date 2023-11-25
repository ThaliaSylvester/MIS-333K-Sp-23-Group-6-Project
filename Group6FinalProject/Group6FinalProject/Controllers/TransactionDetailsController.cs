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
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TransactionDetails
                //.Include(t => t.Schedule)
                .Include(t => t.Transaction);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TransactionDetails/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: OrderDetails/Create
        public IActionResult Create(int transactionID)
        {
            TransactionDetail od = new TransactionDetail();

            Transaction dbTransaction = _context.Transactions.Find(transactionID);
            od.Transaction = dbTransaction;

            ViewBag.StartTimes = GetStartTime();
            ViewBag.Theatres = GetTheatre();

            return View(od);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionDetail transactionDetail, int SelectedStartTime, int SelectedTheatre)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.StartTimes = GetStartTime();
                ViewBag.Theatres = GetTheatre();
                return View(transactionDetail);
            }

            // Find the ScheduleID based on the selected StartTime and Theatre
            Schedule dbSchedules = _context.Schedules.FirstOrDefault(s => s.StartTime == new DateTime(SelectedStartTime) && s.Theatre == (Theatre)SelectedTheatre);


            //if (dbSchedules == null)
            //{
            //    ModelState.AddModelError(string.Empty, "Invalid StartTime and Theatre combination");
            //    ViewBag.StartTimes = GetStartTime();
            //    ViewBag.Theatres = GetTheatre();
            //    return View(transactionDetail);
            //}

            transactionDetail.Schedule = dbSchedules;

            Transaction dbTransactions = _context.Transactions.Find(transactionDetail.TransactionID);
            transactionDetail.Transaction = dbTransactions;

            // Perform any other necessary logic here

            _context.Add(transactionDetail);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Transaction", new { id = transactionDetail.Transaction.TransactionID });
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
        private SelectList GetTheatre()
        {
            List<Schedule> allTheatre = _context.Schedules.ToList();

            SelectList slallTheatre = new SelectList(allTheatre, nameof(Schedule.ScheduleID), nameof(Schedule.Theatre));

            return slallTheatre;
        }
    }
}