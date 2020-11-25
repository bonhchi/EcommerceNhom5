using Microsoft.AspNetCore.Mvc;
using PCWeb.Data;
using PCWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Areas.Admin.Controllers
{
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
            return View(revenueList);
        }
    }
}
