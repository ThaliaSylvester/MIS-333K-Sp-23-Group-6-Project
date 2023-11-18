//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Mikel_Ethan_HW5.DAL;
//using Mikel_Ethan_HW5.Models;
//using Mikel_Ethan_HW5.Utilities;

//namespace Mikel_Ethan_HW5.Controllers
//{
//    [Authorize]
//    public class OrdersController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly UserManager<AppUser> _userManager;

//        public OrdersController(AppDbContext context, UserManager<AppUser> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }

//        // GET: Orders
//        public IActionResult Index()
//        {
//            List<Order> orders;
//            if (User.IsInRole("Admin"))
//            {
//                orders = _context.Orders
//                                .Include(r => r.OrderDetails)
//                                .ToList();
//            }
//            else
//            {
//                orders = _context.Orders
//                                .Include(r => r.OrderDetails)
//                                .Where(r => r.User.UserName == User.Identity.Name)
//                                .ToList();
//            }
//            return View(orders);
//        }

//        // GET: Orders/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return View("Error", new String[] { "Please specify an order to view!" });
//            }
//            Order order = await _context.Orders
//                                              .Include(r => r.OrderDetails)
//                                              .ThenInclude(r => r.Product)
//                                              .Include(r => r.User)
//                                              .FirstOrDefaultAsync(m => m.OrderID == id);
//            if (order == null)
//            {
//                return View("Error", new String[] { "This order was not found!" });
//            }

//            if (User.IsInRole("Customer") && order.User.UserName != User.Identity.Name)
//            {
//                return View("Error", new String[] { "This is not your order!  Don't be such a snoop!" });
//            }

//            return View(order);
//        }

//        [Authorize(Roles = "Customer")]
//        public IActionResult AddToCart(int? productID)
//        {
//            if (productID == null)
//            {
//                return View("Error", new string[] { "Please specify a product to add to the order" });
//            }

//            Product dbProduct = _context.Product.Find(productID);

//            if (dbProduct == null)
//            {
//                return View("Error", new string[] { "This product was not in the database!" });
//            }

//            Order ord = _context.Orders.FirstOrDefault(r => r.User.UserName == User.Identity.Name);

//            if (ord == null)
//            {
//                ord = new Order();

//                ord.OrderDate = DateTime.Now;
//                ord.OrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_context);
//                ord.User = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

//                _context.Orders.Add(ord);
//                _context.SaveChanges();
//            }

//            OrderDetail od = new OrderDetail();

//            od.Product = dbProduct;
//            od.Order = ord;
//            od.Quantity = 1;
//            od.ProductPrice = dbProduct.Price;
//            od.ExtendedPrice = dbProduct.Price * od.Quantity;

//            _context.OrderDetails.Add(od);
//            _context.SaveChanges(true);

//            return RedirectToAction("Details", new { id = ord.OrderID });
//        }

//        // GET: Orders/Edit/5
//        [Authorize(Roles = "Customer")]
//        public IActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return View("Error", new String[] { "Please specify an order to edit." });
//            }

//            Order order = _context.Orders
//                                       .Include(o => o.OrderDetails)
//                                       .ThenInclude(r => r.Product)
//                                       .Include(r => r.User)
//                                       .FirstOrDefault(r => r.OrderID == id);

//            if (order == null)
//            {
//                return View("Error", new String[] { "This order was not found in the database!" });
//            }

//            if (User.IsInRole("Customer") && order.User.UserName != User.Identity.Name)
//            {
//                return View("Error", new String[] { "You are not authorized to edit this order!" });
//            }

//            return View(order);
//        }

//        // POST: Orders/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [Authorize(Roles = "Customer")]
//        public async Task<IActionResult> Edit(int id, Order order)
//        {
//            if (id != order.OrderID)
//            {
//                return View("Error", new String[] { "There was a problem editing this order. Try again!" });
//            }

//            if (ModelState.IsValid == false)
//            {
//                return View(order);
//            }

//            try
//            {
//                Order dbOrder = _context.Orders.Find(order.OrderID);

//                dbOrder.OrderNotes = order.OrderNotes;

//                _context.Update(dbOrder);
//                await _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                return View("Error", new String[] { "There was an error updating this order!", ex.Message });
//            }
//            return RedirectToAction(nameof(Index));
//        }


//        //GET: Orders/Create
//        [HttpGet]
//        [Authorize]
//        [Authorize(Roles = "Customer")]
//        public async Task<IActionResult> Create()
//        {
//            if (User.IsInRole("Customer"))
//            {
//                Order ord = new Order();
//                ord.User = await _userManager.FindByNameAsync(User.Identity.Name);
//                return View(ord);
//            }
//            else
//            {
//                ViewBag.UserNames = await GetAllCustomerUserNamesSelectList();
//                return View("SelectCustomerForOrder");
//            }
//        }


//        [HttpPost]
//        [Authorize]
//        [ValidateAntiForgeryToken]
//        [Authorize(Roles = "Customer")]
//        public async Task<IActionResult> Create([Bind("User, OrderNotes")] Order order)
//        {
//            order.OrderNumber = Utilities.GenerateNextOrderNumber.GetNextOrderNumber(_context);

//            order.OrderDate = DateTime.Now;

//            order.User = await _userManager.FindByNameAsync(order.User.UserName);

//            _context.Add(order);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("Create", "OrderDetails", new { orderID = order.OrderID });
//        }


//        [Authorize(Roles = "Admin")]
//        public async Task<IActionResult> SelectCustomerForOrder(String SelectedCustomer)
//        {
//            if (String.IsNullOrEmpty(SelectedCustomer))
//            {
//                ViewBag.UserNames = await GetAllCustomerUserNamesSelectList();
//                return View("SelectCustomerForOrder");
//            }

//            Order ord = new Order();
//            ord.User = await _userManager.FindByNameAsync(SelectedCustomer);
//            return View("Create", ord);
//        }


//        [Authorize]
//        public async Task<IActionResult> CheckoutOrder(int? id)
//        {
//            if (id == null)
//            {
//                return View("Error", new String[] { "Please specify an order to view!" });
//            }

//            Order order = await _context.Orders
//                                              .Include(o => o.OrderDetails)
//                                              .ThenInclude(o => o.Product)
//                                              .Include(o => o.User)
//                                              .FirstOrDefaultAsync(m => m.OrderID == id);

//            if (order == null)
//            {
//                return View("Error", new String[] { "This order was not found!" });
//            }

//            if (User.IsInRole("Customer") && order.User.UserName != User.Identity.Name)
//            {
//                return View("Error", new String[] { "This is not your order!  Don't be such a snoop!" });
//            }

//            return View("Confirm", order);
//        }

//        private async Task<IActionResult> Confirm(int? id)
//        {
//            Order dbOrd = await _context.Orders.FindAsync(id);
//            _context.Update(dbOrd);
//            _context.SaveChanges();

//            return RedirectToAction("Index");
//        }


//        private async Task<SelectList> GetAllCustomerUserNamesSelectList()
//        {
//            List<AppUser> allCustomers = new List<AppUser>();

//            foreach (AppUser dbUser in _context.Users)
//            {
//                if (await _userManager.IsInRoleAsync(dbUser, "Customer") == true)//user is a customer
//                {
//                    allCustomers.Add(dbUser);
//                }
//            }

//            SelectList sl = new SelectList(allCustomers.OrderBy(c => c.Email), nameof(AppUser.UserName), nameof(AppUser.Email));

//            return sl;

//        }
//    }
//}
