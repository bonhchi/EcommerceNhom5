using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models.Source
{
    public class Product
    {
        [DisplayName("Mã số")]
        public int ProductId { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string ProductCode { get; set; }
        [DisplayName("Mã vạch")]
        [Required(ErrorMessage = "Thiếu mã vạch")]
        public string ProductSeries { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string ProductName { get; set; }
        [DisplayName("Hình ảnh")]
        public string ProductImage { get; set; }
        [DisplayName("Giá")]
        [Range(0, int.MaxValue, ErrorMessage = "Sản phẩm không được có giá dưới 0")]
        public double ProductPrice { get; set; }
        [DisplayName("Mô tả sản phẩm")]
        public string ProductDescription { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime DayCreate { get; set; }
        [DisplayName("Bảo hành")]
        [Range(12, 120, ErrorMessage = "Sản phẩm phải được bảo hành trên 12 tháng")]
        public int ProductWarranty { get; set; }
        [DisplayName("Số lượng")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int ProductQuantity { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public List<Promotion> Promotions { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
