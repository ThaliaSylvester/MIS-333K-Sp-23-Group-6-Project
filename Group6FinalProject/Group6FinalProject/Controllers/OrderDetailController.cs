//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization;
//using Mikel_Ethan_HW5.DAL;
//using Mikel_Ethan_HW5.Models;

//namespace Mikel_Ethan_HW5.Controllers
//{
//    public class OrderDetailsController : Controller
//    {
//        private readonly AppDbContext _context;

//        public OrderDetailsController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: OrderDetails
//        public IActionResult Index(int? orderID)
//        {
//            if (orderID == null)
//            {
//                return View("Error", new String[] { "Please specify an order to view!" });
//            }

//            //limit the list to only the order details that belong to this order
//            List<OrderDetail> ods = _context.OrderDetails
//                                          .Include(od => od.Product)
//                                          .Where(od => od.Order.OrderID == orderID)
//                                          .ToList();

//            return View(ods);
//        }

//        // GET: OrderDetails/Create
//        public IActionResult Create(int orderID)
//        {
//            OrderDetail od = new OrderDetail();

//            Order dbOrder = _context.Orders.Find(orderID);

//            od.Order = dbOrder;

//            ViewBag.AllProducts = GetProductSelectList();

//            return View(od);
//        }

//        // POST: OrderDetails/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(OrderDetail orderDetail, int SelectedProduct)
//        {
//            if (ModelState.IsValid == false)
//            {
//                ViewBag.AllProducts = GetProductSelectList();
//                return View(orderDetail);
//            }

//            Product dbProduct = _context.Product.Find(SelectedProduct);

//            orderDetail.Product = dbProduct;

//            Order dbOrder = _context.Orders.Find(orderDetail.Order.OrderID);

//            orderDetail.Order = dbOrder;

//            orderDetail.ProductPrice = dbProduct.Price;

//            orderDetail.ExtendedPrice = orderDetail.Quantity * orderDetail.ProductPrice;

//            _context.Add(orderDetail);

//            await _context.SaveChangesAsync();

//            return RedirectToAction("Details", "Orders", new { id = orderDetail.Order.OrderID });
//        }

//        // GET: OrderDetails/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return View("Error", new String[] { "Please specify an order detail to edit!" });
//            }

//            OrderDetail orderDetail = await _context.OrderDetails
//                                                   .Include(od => od.Product)
//                                                   .Include(od => od.Order)
//                                                   .FirstOrDefaultAsync(od => od.OrderDetailID == id);
//            if (orderDetail == null)
//            {
//                return View("Error", new String[] { "This order detail was not found" });
//            }
//            return View(orderDetail);
//        }

//        // POST: OrderDetails/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, OrderDetail orderDetail)
//        {
//            if (id != orderDetail.OrderDetailID)
//            {
//                return View("Error", new String[] { "There was a problem editing this record. Try again!" });
//            }

//            OrderDetail dbOD;
//            try
//            {
//                dbOD = _context.OrderDetails
//                      .Include(od => od.Product)
//                      .Include(od => od.Order)
//                      .FirstOrDefault(od => od.OrderDetailID == orderDetail.OrderDetailID);

//                if (ModelState.IsValid == false)
//                {
//                    return View(orderDetail);
//                }

//                dbOD.Quantity = orderDetail.Quantity;
//                dbOD.ProductPrice = dbOD.Product.Price;
//                dbOD.ExtendedPrice = dbOD.Quantity * dbOD.ProductPrice;

//                _context.Update(dbOD);
//                await _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                return View("Error", new String[] { "There was a problem editing this record", ex.Message });
//            }

//            return RedirectToAction("Details", "Orders", new { id = dbOD.Order.OrderID });
//        }

//        // GET: OrderDetails/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return View("Error", new String[] { "Please specify an order detail to delete!" });
//            }

//            OrderDetail orderDetail = await _context.OrderDetails
//                                                    .Include(o => o.Order)
//                                                   .FirstOrDefaultAsync(m => m.OrderDetailID == id);

//            if (orderDetail == null)
//            {
//                return View("Error", new String[] { "This order detail was not in the database!" });
//            }

//            return View(orderDetail);
//        }

//        // POST: OrderDetails/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            OrderDetail orderDetail = await _context.OrderDetails
//                                                   .Include(o => o.Order)
//                                                   .FirstOrDefaultAsync(o => o.OrderDetailID == id);

//            _context.OrderDetails.Remove(orderDetail);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("Details", "Orders", new { id = orderDetail.Order.OrderID });
//        }

//        private SelectList GetProductSelectList()
//        {
//            List<Product> allProducts = _context.Product.ToList();

//            SelectList slAllProducts = new SelectList(allProducts, nameof(Product.ProductID), nameof(Product.Name));

//            return slAllProducts;
//        }
//    }
//}