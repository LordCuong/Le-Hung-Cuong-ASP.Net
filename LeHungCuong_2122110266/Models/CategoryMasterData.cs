using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeHungCuong_2122110266.Models
{
    public class CategoryMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Têm danh mục")]
        public string Name { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "slug")]
        public string Slug { get; set; }

        [Display(Name = "hiển thị")]
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