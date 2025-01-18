using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeHungCuong_2122110266.Models
{
    public class OrderMasterData
    {
        public int Id { get; set; }

        [Display(Name = "Tên đơn hàng")]
        public string Name { get; set; }
        [Display(Name = "Giá")]
        public string Price { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedAt { get; set; }

        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> UpdatedAt { get; set; }


        [Display(Name = "Trạng thái")]
        public Nullable<int> Status { get; set; }

        [Display(Name = "ID người dùng")]
        public Nullable<int> UserId { get; set; }
    }
}