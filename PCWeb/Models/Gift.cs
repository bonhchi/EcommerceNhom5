using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Models
{
    public class Gift
    {
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
}
