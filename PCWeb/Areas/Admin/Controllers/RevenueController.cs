using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCWeb.Data;
using PCWeb.Models;
using PCWeb.Models.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator, Staff")]
    public class RevenueController : Controller
    {
        private readonly DataContext dataContext;

        public RevenueController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var revenueList = dataContext.Revenues.ToList();
            var revenueDetailList = dataContext.RevenueDetails.ToList();
            List<int> quantity = new List<int>();
            List<double> allTotal = new List<double>();
            for (int i = 0; i < revenueList.Count; i++)
            {
                int count = 0;
                double total = 0;
                var find = dataContext.RevenueDetails.Where(p => p.RevenueId == revenueList[i].RevenueId).ToList();
                if(find != null)
                {
                    foreach(var item in find)
                    {
                        count += item.Quantity;
                        total += item.PriceReality;
                    }
                    quantity.Add(count);
                    allTotal.Add(total);
                }
            }
            ViewBag.Quantity = quantity;
            ViewBag.Total = allTotal;
            return View(revenueList);
        }
    }
}
