using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Models
{
    public class RevenueDetail
    {
        public int RevenueDetailId { get; set; }
        public int RevenueId { get; set; }
        public DateTime DateIssue { get; set; }
        public Revenue Revenue { get; set; }
    }
}
