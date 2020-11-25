using Microsoft.AspNetCore.Mvc;
using PCWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        private readonly DataContext dataContext;
        public IActionResult Index()
        {
            return View();
        }
    }
}
