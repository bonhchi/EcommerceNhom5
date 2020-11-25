using PCWeb.Models.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Models
{
    public class Revenue
    {
        public int RevenueId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int RevenueDetailId { get; set; }
        public List<RevenueDetail> RevenueDetails { get; set; }
        
    }
}
