using LeHungCuong_2122110266.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHungCuong_2122110266.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        WebAspDbEntities db = new WebAspDbEntities();

        // GET: Admin/User
        public ActionResult Index(string Search, string currentFilter, int? page)
        {
            var listUser = new List<User>();
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
                listUser = db.User.Where(n => n.Email.Contains(Search)).ToList();
            }
            else
            {
                listUser = db.User.ToList();
            }
            ViewBag.CurrentFilter = Search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listUser = listUser.OrderByDescending(n => n.Id).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_UserList", listUser.ToPagedList(pageNumber, pageSize));
            }

            return View(listUser.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var User = db.User.Where(n => n.Id == id).FirstOrDefault();
            return View(User);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var User = db.User.Where(n => n.Id == id).FirstOrDefault();
            return View(User);
        }

        [HttpPost]
        public ActionResult Delete(User User)
        {
            try
            {
                var UserToDelete = db.User.Where(n => n.Id == User.Id).FirstOrDefault();
                db.User.Remove(UserToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while deleting the User.");
                return View(User);
            }
        }

    }


}