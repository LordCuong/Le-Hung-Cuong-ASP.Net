using LeHungCuong_2122110266.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeHungCuong_2122110266.Models
{
    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public List<OrderDetailInfo> OrderDetail { get; set; }
    }
    public class OrderDetailInfo
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public string ProductName { get; set; }
        public decimal UserId { get; set; }
    }
}