using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCWeb.Areas.Admin.Controllers
{
    public class RAMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
