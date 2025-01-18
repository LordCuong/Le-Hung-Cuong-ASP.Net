using LeHungCuong_2122110266.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHungCuong_2122110266.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        WebAspDbEntities db = new WebAspDbEntities();

        // GET: Admin/Brand
        public ActionResult Index(string Search, string currentFilter, int? page)
        {
            var listBrand = new List<Brand>();
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
                listBrand = db.Brand.Where(n => n.Name.Contains(Search)).ToList();
            }
            else
            {
                listBrand = db.Brand.ToList();
            }
            ViewBag.CurrentFilter = Search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listBrand = listBrand.OrderByDescending(n => n.Id).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_BrandList", listBrand.ToPagedList(pageNumber, pageSize));
            }

            return View(listBrand.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brand Brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra file được upload
                    if (Brand.ImageUpLoad != null && Brand.ImageUpLoad.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(Brand.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(Brand.ImageUpLoad.FileName);

                        // Tạo tên file mới để tránh trùng lặp
                        fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                        // Đường dẫn lưu file
                        string path = Path.Combine(Server.MapPath("~/Content/images/items/"), fileName);

                        // Lưu file
                        Brand.ImageUpLoad.SaveAs(path);

                        // Gán tên file vào thuộc tính Image
                        Brand.Image = fileName;
                    }

                    // Lưu thông tin vào cơ sở dữ liệu
                    Brand.CreatedAt = DateTime.Now;
                    db.Brand.Add(Brand);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Không thể tạo danh mục. Lỗi: " + ex.Message);
                }
            }
            return View(Brand);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var Brand = db.Brand.Where(n => n.Id == id).FirstOrDefault();
            return View(Brand);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Brand = db.Brand.Where(n => n.Id == id).FirstOrDefault();
            return View(Brand);
        }

        [HttpPost]
        public ActionResult Edit(Brand Brand, int id)
        {
            var existingBrand = db.Brand.Where(n => n.Id == id).FirstOrDefault();
            if (existingBrand == null)
            {
                return HttpNotFound();
            }

            if (Brand.ImageUpLoad != null && Brand.ImageUpLoad.ContentLength > 0)
            {
                // Nếu có hình mới, thực hiện lưu hình mới
                string fileName = Path.GetFileNameWithoutExtension(Brand.ImageUpLoad.FileName);
                string extension = Path.GetExtension(Brand.ImageUpLoad.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                Brand.Image = fileName;

                // Lưu hình vào thư mục
                Brand.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
            }
            else
            {
                // Nếu không có hình mới, giữ lại hình cũ
                Brand.Image = existingBrand.Image;
            }

            // Cập nhật các thông tin khác
            existingBrand.Name = Brand.Name;
            existingBrand.Deleted = Brand.Deleted;
            existingBrand.ShowOnHomePage = Brand.ShowOnHomePage;
            existingBrand.DisplayOrder = Brand.DisplayOrder;
            existingBrand.Image = Brand.Image; // Giữ hình cũ hoặc cập nhật hình mới
            existingBrand.UpdatedAt = DateTime.Now;
            db.Entry(existingBrand).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Brand = db.Brand.Where(n => n.Id == id).FirstOrDefault();
            return View(Brand);
        }

        [HttpPost]
        public ActionResult Delete(Brand Brand)
        {
            try
            {
                var BrandToDelete = db.Brand.Where(n => n.Id == Brand.Id).FirstOrDefault();
                db.Brand.Remove(BrandToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while deleting the Brand.");
                return View(Brand);
            }
        }
    }
}