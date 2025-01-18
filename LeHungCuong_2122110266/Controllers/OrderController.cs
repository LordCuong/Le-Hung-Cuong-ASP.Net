using LeHungCuong_2122110266.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LeHungCuong_2122110266.Controllers
{
    public class OrderController : Controller
    {
        WebAspDbEntities db = new WebAspDbEntities();

        // GET: Order
        public ActionResult Index(int Id)
        {
           
            return View();
        }
    }
}