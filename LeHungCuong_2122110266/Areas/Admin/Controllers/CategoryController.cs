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
    public class CategoryController : Controller
    {
        WebAspDbEntities db = new WebAspDbEntities();

        // GET: Admin/Category
        public ActionResult Index(string Search, string currentFilter, int? page)
        {
            var listCategory = new List<Category>();
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
                listCategory = db.Category.Where(n => n.Name.Contains(Search)).ToList();
            }
            else
            {
                listCategory = db.Category.ToList();
            }
            ViewBag.CurrentFilter = Search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listCategory = listCategory.OrderByDescending(n => n.Id).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CategoryList", listCategory.ToPagedList(pageNumber, pageSize));
            }

            return View(listCategory.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra file được upload
                    if (category.ImageUpLoad != null && category.ImageUpLoad.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(category.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(category.ImageUpLoad.FileName);

                        // Tạo tên file mới để tránh trùng lặp
                        fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                        // Đường dẫn lưu file
                        string path = Path.Combine(Server.MapPath("~/Content/images/items/"), fileName);

                        // Lưu file
                        category.ImageUpLoad.SaveAs(path);

                        // Gán tên file vào thuộc tính Image
                        category.Image = fileName;
                    }

                    // Lưu thông tin vào cơ sở dữ liệu
                    category.CreatedAt = DateTime.Now;
                    db.Category.Add(category);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Không thể tạo danh mục. Lỗi: " + ex.Message);
                }
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var category = db.Category.Where(n => n.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = db.Category.Where(n => n.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category, int id)
        {
            var existingCategory = db.Category.Where(n => n.Id == id).FirstOrDefault();
            if (existingCategory == null)
            {
                return HttpNotFound();
            }

            if (category.ImageUpLoad != null && category.ImageUpLoad.ContentLength > 0)
            {
                // Nếu có hình mới, thực hiện lưu hình mới
                string fileName = Path.GetFileNameWithoutExtension(category.ImageUpLoad.FileName);
                string extension = Path.GetExtension(category.ImageUpLoad.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                category.Image = fileName;

                // Lưu hình vào thư mục
                category.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
            }
            else
            {
                // Nếu không có hình mới, giữ lại hình cũ
                category.Image = existingCategory.Image;
            }

            // Cập nhật các thông tin khác
            existingCategory.Name = category.Name;
            existingCategory.Deleted = category.Deleted;
            existingCategory.ShowOnHomePage = category.ShowOnHomePage;
            existingCategory.DisplayOrder = category.DisplayOrder;
            existingCategory.Image = category.Image; // Giữ hình cũ hoặc cập nhật hình mới
            existingCategory.UpdatedAt = DateTime.Now;

            db.Entry(existingCategory).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = db.Category.Where(n => n.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                var categoryToDelete = db.Category.Where(n => n.Id == category.Id).FirstOrDefault();
                db.Category.Remove(categoryToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while deleting the category.");
                return View(category);
            }
        }
    }
}