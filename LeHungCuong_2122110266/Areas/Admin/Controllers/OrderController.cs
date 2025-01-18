using LeHungCuong_2122110266.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using LeHungCuong_2122110266.Models;

namespace LeHungCuong_2122110266.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebAspDbEntities db = new WebAspDbEntities();
        private WebAspDbEntities _context;
        public OrderController()
        {
            _context = new WebAspDbEntities();
        }
        // GET: Admin/Order
        public ActionResult Index(string Search, string currentFilter, int? page)
        {
            var listOrder = new List<Order>();
            if (Search != null)
            {
                page = 1;
            }
            else
            {
                Search = currentFilter;
            }
            if (!String.IsNullOrEmpty(Search))
            {
                listOrder = db.Order.Where(n => n.Name.Contains(Search)).ToList();
            }
            else
            {
                listOrder = db.Order.ToList();
            }
            ViewBag.CurrentFilter = Search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listOrder = listOrder.OrderByDescending(n => n.Id).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_OrderList", listOrder.ToPagedList(pageNumber, pageSize));
            }

            return View(listOrder.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public JsonResult UpdateStatus(int id, int status)
        {
            try
            {
                // Tìm đơn hàng theo Id
                var order = _context.Order.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return Json(new { success = false, message = "Đơn hàng không tồn tại." });
                }

                // Cập nhật trạng thái
                order.Status = status;
                order.UpdatedAt = DateTime.Now;

                // Lưu thay đổi
                _context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Order = db.Order.Where(n => n.Id == id).FirstOrDefault();
            return View(Order);
        }

        [HttpPost]
        public ActionResult Delete(Order Order)
        {
            try
            {
                var OrderToDelete = db.Order.Where(n => n.Id == Order.Id).FirstOrDefault();
                db.Order.Remove(OrderToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while deleting the Order.");
                return View(Order);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = db.Order.Where(n => n.Id == id).FirstOrDefault();

            if (order != null)
            {
                // Fetch the order details based on the OrderId
                var orderDetails = db.OrderDetail.Where(od => od.Id == id).ToList();

                // Fetch product info and assign it to the details list
                var orderDetailInfos = orderDetails.Select(od => new OrderDetailInfo
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    Price = (decimal)db.Product.Where(p => p.Id == od.ProductId).Select(p => p.Price).FirstOrDefault(),
                    ProductName = db.Product.Where(p => p.Id == od.ProductId).Select(p => p.Name).FirstOrDefault(),
                    TotalPrice = od.Quantity * (decimal)db.Product.Where(p => p.Id == od.ProductId).Select(p => p.Price).FirstOrDefault()
                }).ToList();

                // Pass the order and order details to the view
                var model = new OrderDetailViewModel
                {
                    Order = order,
                    OrderDetail = orderDetailInfos
                };

                return View(model);
            }

            return HttpNotFound();
        }
    }

}