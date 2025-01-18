using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeHungCuong_2122110266.Models
{
    public class ProductMasterData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]

        [Display(Name = "Têm sảm phẩm")]
        public string Name { get; set; }

        [Display(Name = "Chọn Ảnh đại diện")]
        public string Image { get; set; }

        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả ngắn")]
        [Display(Name = "Mô tả ngắn")]
        public string ShortDes { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả đầy đủ")]
        [Display(Name = "Mô tả đầy đủ")]
        public string FullDescription { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá gốc")]
        [Display(Name = "Giá gốc")]
        public Nullable<double> Price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá khuyến mãi")]
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> TypeId { get; set; }
        public string Slug { get; set; }

        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }
    }
}