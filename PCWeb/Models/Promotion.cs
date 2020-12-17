﻿using PCWeb.Models.Source;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models
{
    public class Promotion
    {
        [DisplayName("STT")]
        public int PromotionId { get; set; }
        [DisplayName("Tên khuyến mãi")]
        [Required(ErrorMessage = "Khuyến mãi không được để trống")]
        public string PromotionName { get; set; }
        [DisplayName("Mặt hàng áp dụng")]
        public string PromotionApply { get; set; }
        [RegularExpression(@"^[A-Z]+[0-9]+$", ErrorMessage = "Mã giảm giá phải có số và chữ")]
        [MinLength(8, ErrorMessage = "Mã giám giá ít nhất 8 kí tự")]
        [DisplayName("Mã giảm giá")]
        public string PromotionCode { get; set; }
    }
}
