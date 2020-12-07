using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Controllers
{
    public class PCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
