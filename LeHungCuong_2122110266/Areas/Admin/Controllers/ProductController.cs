using LeHungCuong_2122110266.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
namespace LeHungCuong_2122110266.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        WebAspDbEntities db = new WebAspDbEntities();

        // GET: Admin/Product
        public ActionResult Index(string Search, string currentFilter, int? page)
        {
            var listProduct = new List<Product>();
            if (Search != null)
            {
                page = 1;
            }
            else
            {
                Search = currentFilter;
            }
            if (!string.IsNullOrEmpty(Search))
            {
                listProduct = db.Product.Where(n => n.Name.Contains(Search)).ToList();
            }
            else
            {
                listProduct = db.Product.ToList();
            }
            ViewBag.CurrentFilter = Search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listProduct = listProduct.OrderByDescending(n => n.Id).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", listProduct.ToPagedList(pageNumber, pageSize));
            }

            return View(listProduct.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {

            this.LoadData();

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageUpLoad != null && product.ImageUpLoad.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(product.ImageUpLoad.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        product.Image = fileName;
                        product.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                    }
                    product.CreatedAt = DateTime.Now;
                    db.Product.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var Product = db.Product.Where(n => n.Id == id).FirstOrDefault();
            return View(Product);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Product = db.Product.Where(n => n.Id == id).FirstOrDefault();
            return View(Product);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var Product = db.Product.Where(n => n.Id == product.Id).FirstOrDefault();
            db.Product.Remove(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Product = db.Product.Where(n => n.Id == id).FirstOrDefault();
            return View(Product);
        }
        [HttpPost]
        public ActionResult Edit(Product product, int id)
        {
            var existingProduct = db.Product.Where(n => n.Id == id).FirstOrDefault();
            if (existingProduct == null)
            {
                return HttpNotFound();
            }


            if (product.ImageUpLoad != null && product.ImageUpLoad.ContentLength > 0)
            {
                // Nếu có hình mới, thực hiện lưu hình mới
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad.FileName);
                string extension = Path.GetExtension(product.ImageUpLoad.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                product.Image = fileName;

                // Lưu hình vào thư mục
                product.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
            }
            else
            {
                // Nếu không có hình mới, giữ lại hình cũ
                product.Image = existingProduct.Image;
            }

            // Cập nhật các thông tin khác
            existingProduct.Name = product.Name;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.BrandId = product.BrandId;
            existingProduct.ShortDes = product.ShortDes;
            existingProduct.FullDescription = product.FullDescription;
            existingProduct.Price = product.Price;
            existingProduct.PriceDiscount = product.PriceDiscount;
            existingProduct.Deleted = product.Deleted;
            existingProduct.ShowOnHomePage = product.ShowOnHomePage;
            existingProduct.Image = product.Image; // Giữ hình cũ hoặc cập nhật hình mới
            existingProduct.UpdatedAt = DateTime.Now;



            db.Entry(existingProduct).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        void LoadData()
        {
            Common objCommon = new Common();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();

            var listCategory = db.Category.ToList();
            DataTable dtCategory = converter.ToDataTable(listCategory);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            var listBrands = db.Brand.ToList();
            DataTable dtBrands = converter.ToDataTable(listBrands);
            ViewBag.ListBrands = objCommon.ToSelectList(dtBrands, "Id", "Name");

            List<ProductType> listProductType = new List<ProductType>();
            ProductType productType = new ProductType();
            productType.Id = 1;
            productType.Name = "Giảm giá sốc";
            listProductType.Add(productType);

            productType = new ProductType();
            productType.Id = 2;
            productType.Name = "Đề xuất";
            listProductType.Add(productType);

            DataTable dtProductType = converter.ToDataTable(listProductType);
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }
    }
}