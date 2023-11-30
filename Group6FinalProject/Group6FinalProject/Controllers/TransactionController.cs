using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Group_6_Final_Project.DAL;
using Group_6_Final_Project.Models;
using Group_6_Final_Project.Utilities;
using System.Security.Claims;
using fa22RelationalDataDemo.Utilities;

namespace Group_6_Final_Project.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<TransactionController> _logger; // Declare a logger

        public TransactionController(AppDbContext context, UserManager<AppUser> userManager, ILogger<TransactionController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        // GET: Transactions/Index
        public IActionResult Index(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";


            var transactionsQuery = from t in _context.Transactions select t;

            if (User.IsInRole("Admin"))
            {
                transactionsQuery = transactionsQuery.Include(r => r.TransactionDetail);
            }
            else
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                transactionsQuery = transactionsQuery.Include(r => r.TransactionDetail)
                                                     .Where(r => r.AppUserId == userId);
            }

            switch (sortOrder)
            {
                case "Date":
                    transactionsQuery = transactionsQuery.OrderBy(t => t.TransactionDate);
                    break;
                case "date_desc":
                    transactionsQuery = transactionsQuery.OrderByDescending(t => t.TransactionDate);
                    break;
            }

            return View(transactionsQuery.ToList());
        }

        // GET: Transaction/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return View("Error", new String[] { "Please specify a transaction to view!" });
            }

            // Find in database
            var transaction = _context.Transactions
                              .Include(t => t.TransactionDetail)
                              .ThenInclude(t => t.Schedule)
                              .ThenInclude(t => t.Movie)
                              .FirstOrDefault(m => m.TransactionID == id);

            // If transaction was not found in database
            if (transaction == null)
            {
                return View("Error", new String[] { "This transaction was not found!" });
            }

            // Send user to details page
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        [Authorize(Roles = "Customer")]
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return View("Error", new String[] { "Please specify an order to edit" });
            }

            // Find transaction in database
            Transaction transaction = _context.Transactions
                                       .Include(o => o.TransactionDetail)
                                       .ThenInclude(r => r.Schedule)
                                       .ThenInclude(s => s.Movie)
                                       .Include(r => r.AppUser)
                                       .FirstOrDefault(r => r.TransactionID == id);

            // If transaction was not found
            if (transaction == null)
            {
                return View("Error", new String[] { "This transaction was not found in the database!" });
            }

            // Order does not belong to this user
            if (User.IsInRole("Customer") && transaction.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to edit this transaction!" });
            }

            return View(transaction);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int id, Transaction transaction)
        {
            if (id != transaction.TransactionID)
            {
                return View("Error", new String[] { "There was a problem editing this transaction. Try again!" });
            }

            // If something is wrong with transaction
            if (ModelState.IsValid == false)
            {
                return View(transaction);
            }

            // If code is good, update records
            try
            {
                // Find transaction
                Transaction dbTransaction = _context.Transactions.Find(transaction.TransactionID);

                // Update notes
                dbTransaction.TransactionNote = transaction.TransactionNote;

                _context.Update(dbTransaction);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this transaction!", ex.Message });
            }

            // Send user to order index page
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(int? movieId)
        {
            ViewBag.Movies = new SelectList(_context.Movies, "MovieID", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppuserId")] Transaction transaction, int scheduleId)
        {
            // Populate ViewBag.Movies for the view
            ViewBag.Movies = new SelectList(_context.Movies, "MovieID", "Title");

            // Create a TransactionViewModel instance
            TransactionViewModel viewModel = new TransactionViewModel
            {
            };

            // Validate scheduleId
            if (scheduleId <= 0)
            {
                ModelState.AddModelError("", "Invalid schedule ID.");
                return View(viewModel); // Return the view model
            }

            // Find next transaction number from utilities class
            transaction.TransactionNumber = Utilities.GenerateNextTransactionNumber.GetNextTransactionNumber(_context);

            // Set date of transaction
            transaction.TransactionDate = DateTime.Now;

            // Associate the transaction with a logged-in customer
            transaction.AppUser = _context.Users.FirstOrDefault(o => o.UserName == User.Identity.Name);

            // Add transaction to database
            _context.Add(transaction);
            await _context.SaveChangesAsync();

            // Find Schedule based on scheduleId
            Schedule schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null)
            {
                _logger.LogError($"Schedule not found for ID: {scheduleId}");

                ModelState.AddModelError("", "Schedule not found!");
                return View(viewModel); // Return the view model
            }

            // Create a new TransactionDetail for this transaction
            TransactionDetail transactionDetail = new TransactionDetail
            {
                Schedule = schedule,
                ScheduleID = schedule.ScheduleID,
                Transaction = transaction,
                TransactionID = transaction.TransactionID
                // Set other necessary properties of TransactionDetail as required
            };

            // Add the TransactionDetail to the context and save changes
            _context.TransactionDetails.Add(transactionDetail);
            await _context.SaveChangesAsync();

            // Redirect to TransactionDetails Create view with transactionId and scheduleId
            return RedirectToAction("Create", "TransactionDetails", new { transactionId = transaction.TransactionID, scheduleId = scheduleId });
        }




        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SelectCustomerForTransaction(String SelectedCustomer)
        {
            if (String.IsNullOrEmpty(SelectedCustomer))
            {
                ViewBag.UserNames = await GetAllCustomerUserNamesSelectList();
                return View("SelectCustomerForTransaction");
            }

            string currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Transaction ord = new Transaction();
            ord.AppUserId = currentUserId;
            return View("Create", ord);
        }

        [Authorize]
        public async Task<IActionResult> CheckoutTransaction(int? id)
        {
            string currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (id == null)
            {
                return View("Error", new String[] { "Please specify an Transaction to view!" });
            }

            Transaction Transaction = await _context.Transactions
                                              .Include(o => o.TransactionDetail)
                                              //.Include(o => o.Schedule)
                                              .FirstOrDefaultAsync(m => m.TransactionID == id);

            if (Transaction == null)
            {
                return View("Error", new String[] { "This Transaction was not found!" });
            }

            if (User.IsInRole("Customer") && Transaction.AppUserId != currentUserId)
            {
                return View("Error", new String[] { "This is not your Transaction!  Don't be such a snoop!" });
            }

            return View("Confirm", Transaction);
        }

        private async Task<IActionResult> Confirm(int? id)
        {
            Transaction dbOrd = await _context.Transactions.FindAsync(id);
            _context.Update(dbOrd);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private async Task<SelectList> GetAllCustomerUserNamesSelectList()
        {
            List<AppUser> allCustomers = new List<AppUser>();

            foreach (AppUser dbUser in _context.Users)
            {
                if (await _userManager.IsInRoleAsync(dbUser, "Customer") == true)//user is a customer
                {
                    allCustomers.Add(dbUser);
                }
            }

            SelectList sl = new SelectList(allCustomers.OrderBy(c => c.UserName), nameof(AppUser.Id), nameof(AppUser.UserName));

            return sl;

        }

        public IActionResult ConfirmPurchase(int transactionId)
        {
            var transaction = _context.Transactions.Find(transactionId);
            if (transaction == null)
            {
                return NotFound();
            }

            // Update PurchaseStatus to Purchased
            transaction.PurchaseStatus = PurchaseStatus.Purchased;

            // Save changes to the database
            _context.SaveChanges();

            // Generate confirmation number
            transaction.ConfirmNumber = GenerateNextConfirmNumber.GetNextConfirmNumber(_context);
            _context.SaveChanges();

            // Send confirmation email
            //string emailSubject = "Ticket Confirmation";
            //string emailBody = $"Thank you for your purchase! Your confirmation number is: {transaction.ConfirmNumber}";

            //// Use the SendEmail method from EmailMessaging class
            //EmailMessaging.SendEmail(emailSubject, emailBody);

            return RedirectToAction("ThankYou", new { id = transactionId });
        }
        public IActionResult CancelPurchase(int transactionId)
        {
            var transaction = _context.Transactions.Find(transactionId);

            if (transaction == null)
            {
                return NotFound();
            }

            // Update PurchaseStatus to Purchased
            transaction.PurchaseStatus = PurchaseStatus.Cancelled;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult ThankYou(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = _context.Transactions
                .Include(t => t.TransactionDetail)
                    .ThenInclude(td => td.Schedule)
                        .ThenInclude(s => s.Movie)
                .FirstOrDefault(t => t.TransactionID == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }


        [HttpGet]
        public async Task<IActionResult> GetScheduleTimes(string movieId)
        {
            var schedules = await _context.Schedules
                                          .Where(s => s.MovieID == movieId.ToString())
                                          .Select(s => new { s.ScheduleID, s.StartTime })
                                          .ToListAsync();

            return Json(schedules);
        }


        public async Task<IActionResult> AddToCart(int? ScheduleID, string selectedSeatStr)
        {
            if (ScheduleID == null)
            {
                return View("Error", new string[] { "Please specify a Schedule to add to the Transaction" });
            }

            string currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Schedule dbSchedule = _context.Schedules
                                          .Include(s => s.TransactionDetails)
                                          .FirstOrDefault(s => s.ScheduleID == ScheduleID);

            if (dbSchedule == null)
            {
                return View("Error", new string[] { "This Schedule was not in the database!" });
            }

            // Convert the string to the enum
            if (!Enum.TryParse<SeatSelection>(selectedSeatStr, out SeatSelection selectedSeat))
            {
                return View("Error", new string[] { "Invalid seat selection." });
            }

            // Check if selected seat is available
            if (!dbSchedule.AvailableSeats.Contains(selectedSeat.ToString())) // Convert the enum to a string for comparison
            {
                return View("Error", new string[] { "The selected seat is not available." });
            }

            AppUser user = await _userManager.FindByIdAsync(currentUserId);

            Transaction tran = _context.Transactions
                                      .FirstOrDefault(r => r.AppUserId == currentUserId && r.PurchaseStatus == PurchaseStatus.Pending);

            if (tran == null)
            {
                tran = new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TransactionNumber = GenerateNextTransactionNumber.GetNextTransactionNumber(_context),
                    AppUserId = currentUserId,
                    AppUser = user,
                    PurchaseStatus = PurchaseStatus.Pending
                };

                _context.Transactions.Add(tran);
                await _context.SaveChangesAsync();
            }

            TransactionDetail od = new TransactionDetail
            {
                Transaction = tran,
                Schedule = dbSchedule,  // Associate the schedule with the transaction detail
                SeatSelection = selectedSeat // Add the selected seat
            };

            _context.TransactionDetails.Add(od);
            await _context.SaveChangesAsync(); // Save the transaction detail

            // Remove the selected seat from available seats
            dbSchedule.TransactionDetails.Add(od);
            _context.Update(dbSchedule);
            await _context.SaveChangesAsync(); // Save changes to the schedule

            return RedirectToAction("Details", new { id = tran.TransactionID });
        }


    }
}