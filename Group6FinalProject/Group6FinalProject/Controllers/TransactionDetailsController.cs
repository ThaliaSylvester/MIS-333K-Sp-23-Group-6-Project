using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Group_6_Final_Project.Models;
using Group_6_Final_Project.DAL;

namespace Group_6_Final_Project.Controllers
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
                return View("Error", new string[] { "Please specify a transaction to view!" });
            }

            List<TransactionDetail> transactionDetails = _context.TransactionDetails
                                          .Include(td => td.Schedule)
                                          .Where(td => td.Transaction.TransactionID == transactionID)
                                          .ToList();

            return View(transactionDetails);
        }

        // GET: TransactionDetails/Create
        public IActionResult Create(int transactionID)
        {
            TransactionDetail transactionDetail = new TransactionDetail
            {
                NumberOfTickets = 0
            };

            Transaction dbTransaction = _context.Transactions.Find(transactionID);
            transactionDetail.Transaction = dbTransaction;

            ViewBag.AllProducts = GetProductSelectList();

            return View(transactionDetail);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(TransactionDetail transactionDetail, int selectedProduct)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        ViewBag.AllProducts = GetProductSelectList();
        //        return View(transactionDetail);
        //    }

        //    Schedule dbSchedule = _context.Schedules.Find(selectedProduct);
        //    transactionDetail.Schedule = dbSchedule;

        //    Transaction dbTransaction = _context.Transactions.Find(transactionDetail.Transaction.TransactionID);
        //    transactionDetail.Transaction = dbTransaction;

        //    // Update NumberOfTickets to represent the count of selected seats
        //    transactionDetail.NumberOfTickets = transactionDetail.NumberOfTickets;

        //    // Calculate MoviePrice based on the count of selected seats
        //    transactionDetail.MoviePrice = transactionDetail.NumberOfTickets * dbSchedule.Price.TicketPrice;

        //    _context.Add(transactionDetail);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Details", "Transaction", new { id = transactionDetail.Transaction.TransactionID });
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionDetail transactionDetail, int SelectedProduct)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.AllProducts = GetProductSelectList();
                return View(transactionDetail);
            }

            Schedule dbSchdule = _context.Schedules.Find(SelectedProduct);

            transactionDetail.Schedule = dbSchdule;

            Transaction dbTransaction = _context.Transactions.Find(transactionDetail.Transaction.TransactionID);

            transactionDetail.Transaction = dbTransaction;

            transactionDetail.NumberOfTickets = transactionDetail.NumberOfTickets;

            transactionDetail.MoviePrice = 5;

            _context.Add(transactionDetail);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Orders", new { id = transactionDetail.Transaction.TransactionID });
        }

        // GET: TransactionDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "Please specify a transaction detail to edit!" });
            }

            TransactionDetail transactionDetail = await _context.TransactionDetails
                                                   .Include(td => td.Schedule)
                                                   .Include(td => td.Transaction)
                                                   .FirstOrDefaultAsync(td => td.TransactionDetailID == id);

            if (transactionDetail == null)
            {
                return View("Error", new string[] { "This transaction detail was not found" });
            }

            ViewBag.AllProducts = GetProductSelectList();

            return View(transactionDetail);
        }

        // POST: TransactionDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TransactionDetail transactionDetail, int selectedProduct)
        {
            if (id != transactionDetail.TransactionDetailID)
            {
                return View("Error", new string[] { "There was a problem editing this record. Try again!" });
            }

            TransactionDetail dbTransactionDetail;
            try
            {
                dbTransactionDetail = _context.TransactionDetails
                      .Include(td => td.Schedule)
                      .ThenInclude(s => s.Price)  // Include the Price associated with the Schedule
                      .Include(td => td.Transaction)
                      .FirstOrDefault(td => td.TransactionDetailID == transactionDetail.TransactionDetailID);

                if (dbTransactionDetail == null)
                {
                    return NotFound("TransactionDetail not found.");
                }

                if (ModelState.IsValid == false)
                {
                    ViewBag.AllProducts = GetProductSelectList();
                    return View(transactionDetail);
                }

                dbTransactionDetail.NumberOfTickets = transactionDetail.NumberOfTickets;

                // Calculate MoviePrice based on the count of selected seats
                dbTransactionDetail.MoviePrice = dbTransactionDetail.NumberOfTickets * dbTransactionDetail.Schedule.Price.TicketPrice;

                _context.Update(dbTransactionDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new string[] { "There was a problem editing this record", ex.Message });
            }

            return RedirectToAction("Details", "Transactions", new { id = dbTransactionDetail.Transaction.TransactionID });
        }

        // GET: TransactionDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify an Transaction detail to delete!" });
            }

            TransactionDetail TransactionDetail = await _context.TransactionDetails
                                                    .Include(o => o.Transaction)
                                                   .FirstOrDefaultAsync(m => m.TransactionDetailID == id);

            if (TransactionDetail == null)
            {
                return View("Error", new String[] { "This Transaction detail was not in the database!" });
            }

            return View(TransactionDetail);
        }

        // POST: TransactionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TransactionDetail TransactionDetail = await _context.TransactionDetails
                                                   .Include(o => o.Transaction)
                                                   .FirstOrDefaultAsync(o => o.TransactionDetailID == id);

            _context.TransactionDetails.Remove(TransactionDetail);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Transactions", new { id = TransactionDetail.Transaction.TransactionID });
        }
        private SelectList GetProductSelectList()
        {
            List<Schedule> allSchedule = _context.Schedules.ToList();

            SelectList slAllSchedule = new SelectList(allSchedule, nameof(Schedule.ScheduleID));

            return slAllSchedule;
        }
    }
}