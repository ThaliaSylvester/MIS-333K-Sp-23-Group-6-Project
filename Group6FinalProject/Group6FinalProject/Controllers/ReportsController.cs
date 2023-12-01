//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Group_6_Final_Project.DAL;
//using Group_6_Final_Project.Models;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authorization;
//using System.Data;
//using Group_6_Final_Project.ViewModels;
//using Group6FinalProject.Models.ViewModels;


//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//namespace Group_6_Final_Project.Controllers
//{
//    public class ReportsController : Controller
//    {
//        private readonly AppDbContext _context;

//        public ReportsController(AppDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index(string customerId, DateTime? startDate, DateTime? endDate, string? movieId)
//        {
//            var totalSeatsSold = _context.TransactionDetails.Sum(td => td.NumberofTickets);

//            var totalRevenue = CalculateTotalRevenue();

//            var customerTotalSeats = customerId != null
//            ? _context.Transactions
//            .Where(t => t.AppUserId == customerId)
//            .Sum(t => t.TransactionDetail.Sum(td => td.NumberofTickets))
//            : 0;

//            // Create a ReportsViewModel
//            var reportsViewModel = new ReportViewModel
//            {
//                TotalSeatsSold = totalSeatsSold,
//                TotalRevenue = totalRevenue,
//            };

//            // Pass the view model to the view
//            return View(reportsViewModel);
//        }

//        public IActionResult TotalSeatsSoldReport(DateTime? startDate, DateTime? endDate, string? movieId)
//        {
//            var totalSeatsSold = _context.TransactionDetails
//                .Where(td => (startDate == null || td.Transaction.TransactionDate >= startDate) &&
//                             (endDate == null || td.Transaction.TransactionDate <= endDate) &&
//                             (movieId == null || td.Schedule.MovieId == movieId))
//                .Sum(td => td.NumberofTickets);

//            var reportsViewModel = new ReportViewModel
//            {
//                TotalSeatsSold = totalSeatsSold,
//            };

//            return View("Index", reportsViewModel);
//        }

//        public IActionResult TotalRevenueReport(DateTime? startDate, DateTime? endDate, string? movieId)
//        {
//            var totalRevenue = _context.Transactions
//                .Where(t => (startDate == null || t.TransactionDate >= startDate) &&
//                            (endDate == null || t.TransactionDate <= endDate) &&
//                            (movieId == null || t.TransactionDetails.Any(td => td.Schedule.MovieId == movieId)))
//                .Sum(t => t.TransactionTotal);

//            var reportsViewModel = new ReportViewModel
//            {
//                TotalRevenue = totalRevenue,
//            };

//            return View("Index", reportsViewModel);
//        }

//        public IActionResult TotalSeatsAndRevenueReport(DateTime? startDate, DateTime? endDate, string? movieId)
//        {
//            var totalSeatsSold = // ... your logic to calculate total seats sold
//            var totalRevenue = // ... your logic to calculate total revenue

//            var reportsViewModel = new ReportViewModel
//            {
//                TotalSeatsSold = totalSeatsSold,
//                TotalRevenue = totalRevenue,
//            };

//            return View("Index", reportsViewModel);
//        }

//        public IActionResult CustomerReport(string customerId, DateTime? startDate, DateTime? endDate, string? movieId)
//        {
//            var totalSeatsSold = // ... your logic to calculate total seats sold for the customer
//            var totalRevenue = // ... your logic to calculate total revenue for the customer

//            var reportsViewModel = new ReportViewModel
//            {
//                TotalSeatsSold = totalSeatsSold,
//                TotalRevenue = totalRevenue,
//            };

//            return View("Index", reportsViewModel);
//        }

//        public IActionResult PopcornPointsReport(DateTime? startDate, DateTime? endDate, string? movieId)
//        {
//            var popcornPoints = // ... your logic to calculate popcorn points

//            var reportsViewModel = new ReportViewModel
//            {
//                PopcornPoints = popcornPoints,
//            };

//            return View("Index", reportsViewModel);
//        }
//    }

//    private decimal CalculateTotalRevenue()
//        {
//            // Your logic to calculate total revenue based on transactions
//            var totalRevenue = _context.Transactions.Sum(t => t.TransactionTotal);
//            return totalRevenue;
//        }
//    }
//}