using LeHungCuong_2122110266.Context;
using LeHungCuong_2122110266.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHungCuong_2122110266.Controllers
{
    public class PaymentController : Controller
    {
        WebAspDbEntities db = new WebAspDbEntities();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var listCart = (List<CartModel>)Session["cart"];
                Order order = new Order();
                order.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                order.UserId = int.Parse(Session["Id"].ToString());
                order.CreatedAt = DateTime.Now;
                order.Status = 1;
                order.Price = listCart.Sum(n => n.Product.Price * n.Quantity);
                db.Order.Add(order);
                db.SaveChanges();

                int intOrderId = order.Id;

                List<OrderDetail> listOrderDetail = new List<OrderDetail>();

                foreach (var item in listCart)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = intOrderId;
                    orderDetail.ProductId = item.Product.Id;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.UserId = int.Parse(Session["Id"].ToString());
                    listOrderDetail.Add(orderDetail);
                }
                db.OrderDetail.AddRange(listOrderDetail);
                db.SaveChanges();
                // Xóa giỏ hàng
                Session["cart"] = null;
                Session["count"] = 0;
            }
            return View();
        }
    }
}