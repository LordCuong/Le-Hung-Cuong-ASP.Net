using LeHungCuong_2122110266.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHungCuong_2122110266.Controllers
{
    public class CategoryController : Controller
    {
        WebAspDbEntities db = new WebAspDbEntities();
        // GET: Category
        public ActionResult Category()
        {
            var listCategory = db.Category.ToList();
            return View(listCategory);
        }
        //public ActionResult ProductCategory(int Id)
        //{
        //    var products = db.Product.Where(n => n.CategoryId == Id).ToList();
        //    return View(products);  // Truyền danh sách sản ph
        //}
        public ActionResult ProductCategory(int Id, int page = 1, int pageSize = 1)
        {
            List<Product> listProduct;

            if (Id == 0) // Nếu ID là 0, lấy tất cả sản phẩm
            {
                listProduct = db.Product.ToList();
            }
            else
            {
                listProduct = db.Product.Where(n => n.CategoryId == Id).ToList();
            }

            // Tính tổng số sản phẩm
            int totalProducts = listProduct.Count;

            // Phân trang
            var paginatedProducts = listProduct.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Truyền dữ liệu cần thiết sang ViewBag
            ViewBag.CurrentCategoryId = Id;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
            ViewBag.PageSize = pageSize;

            return View(paginatedProducts);
        }
    }
}