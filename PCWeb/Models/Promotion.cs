using PCWeb.Models.Source;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models
{
    public class Promotion
    {
        [DisplayName("STT")]
        public int PromotionId { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Tên khuyến mãi")]
        [Required(ErrorMessage = "Khuyến mãi không được để trống")]
        public string PromotionName { get; set; }
        public Product Product { get; set; }
    }
}
