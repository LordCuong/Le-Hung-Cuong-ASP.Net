using LeHungCuong_2122110266.Context;
using LeHungCuong_2122110266.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace LeHungCuong_2122110266.Controllers
{
    public class CartController : Controller
    {
        private WebAspDbEntities db = new WebAspDbEntities();

        // Display Shopping Cart
        // Display Shopping Cart
        public ActionResult ShoppingCart()
        {
            List<CartModel> cart = Session["cart"] as List<CartModel>;

            if (cart == null || !cart.Any())
            {
                Session["count"] = 0; // Nếu giỏ hàng trống, cập nhật count về 0
            }

            return View(cart);
        }


        // Add Product to Cart
        public ActionResult AddToCart(int id, int quantity)
        {
            try
            {
                List<CartModel> cart = Session["cart"] as List<CartModel> ?? new List<CartModel>();
                int index = cart.FindIndex(item => item.Product.Id == id);

                if (index != -1)
                {
                    // If the product exists in the cart, update the quantity
                    cart[index].Quantity += quantity;
                }
                else
                {
                    // Add new product to the cart
                    var product = db.Product.Find(id);
                    if (product == null) return Json(new { success = false, message = "Sản phẩm không tồn tại" });

                    cart.Add(new CartModel { Product = product, Quantity = quantity });
                }

                // Update session
                Session["cart"] = cart;
                Session["count"] = cart.Count;

                return Json(new { success = true, message = "Thêm vào giỏ hàng thành công", cartCount = cart.Count });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Remove Product from Cart

        public ActionResult Remove(int id)
        {
            try
            {
                List<CartModel> cart = Session["cart"] as List<CartModel>;

                if (cart != null && cart.Any())
                {
                    cart.RemoveAll(item => item.Product.Id == id);
                    Session["cart"] = cart;
                    Session["count"] = cart.Count;

                    decimal totalPrice = CalculateTotalPrice(cart, out decimal discount);
                    decimal totalWithDiscount = totalPrice - discount;

                    // Nếu giỏ hàng trống, cập nhật count về 0
                    if (cart.Count == 0)
                    {
                        Session["count"] = 0;
                    }

                    return Json(new
                    {
                        success = true,
                        message = "Xóa sản phẩm thành công",
                        cartCount = cart.Count,
                        totalPrice,
                        discount,
                        totalWithDiscount,
                        cartEmpty = cart.Count == 0
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "Giỏ hàng rỗng" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        // Update Product Quantity in Cart

        public ActionResult UpdateQuantity(int id, int quantity)
        {
            try
            {
                List<CartModel> cart = Session["cart"] as List<CartModel>;
                int index = cart?.FindIndex(item => item.Product.Id == id) ?? -1;

                if (index != -1)
                {
                    cart[index].Quantity = quantity;
                    Session["cart"] = cart;

                    decimal totalPrice = CalculateTotalPrice(cart, out decimal discount);
                    decimal totalWithDiscount = totalPrice - discount;

                    return Json(new
                    {
                        success = true,
                        message = "Cập nhật số lượng thành công",
                        totalPrice,
                        discount,
                        totalWithDiscount
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        // Utility: Calculate Total Price and Discount
        private decimal CalculateTotalPrice(List<CartModel> cart, out decimal discount)
        {
           decimal totalPrice = 0;
    discount = 0;

    foreach (var item in cart)
    {
        // Không cần kiểm tra null vì Price và PriceDiscount là kiểu double
        decimal price = (decimal)item.Product.Price;
        decimal priceDiscount = (decimal)item.Product.PriceDiscount;

        if (item.Product.TypeId == 1) // If discounted
        {
            price -= priceDiscount;
        }

        totalPrice += price * item.Quantity;
        discount += priceDiscount * item.Quantity;
    }

    return totalPrice;
        }

        // View Cart Summary
        public ActionResult CartSummary()
        {
            var cart = Session["cart"] as List<CartModel>;
            if (cart == null || !cart.Any())
            {
                return View(); // Giỏ hàng trống
            }

            decimal totalPrice = CalculateTotalPrice(cart, out decimal discount);
            decimal totalWithDiscount = totalPrice - discount;

            // Sau khi tính toán giá trị, xóa giỏ hàng khỏi session
            Session["cart"] = null;

            // Đưa các giá trị cần thiết vào ViewBag để hiển thị
            ViewBag.TotalPrice = totalPrice;
            ViewBag.Discount = discount;
            ViewBag.TotalWithDiscount = totalWithDiscount;

            return View(cart);
        }


    }
}