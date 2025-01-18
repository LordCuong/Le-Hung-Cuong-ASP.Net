using LeHungCuong_2122110266.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeHungCuong_2122110266.Models
{
    public class HomeModel
    {
        public List<Product> ListProducts { get; set; }
        public List<Category> ListCategories { get; set; }
    }
}