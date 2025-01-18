using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeHungCuong_2122110266.Models
{
    public class BrandMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Têm thương hiệu")]
        public string Name { get; set; }

        [Display(Name = "Têm hình ảnh")]
        public string Image { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        [Display(Name = "Hiển thị")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedAt { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }
    }
}