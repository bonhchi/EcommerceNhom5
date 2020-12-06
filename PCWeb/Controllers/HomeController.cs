using Microsoft.AspNetCore.Mvc;
using PCWeb.Data;
using PCWeb.Helper;
using PCWeb.Models;
using PCWeb.Models.Root;
using PCWeb.Models.Source;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PCWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext dataContext;
        public HomeController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var item = dataContext.Products.ToList();
            var itemLaptop = dataContext.Products.Where(p => p.CategoryId == 1).ToList();
            var itemPC = dataContext.Products.Where(p => p.CategoryId == 2).ToList();
            var laptopCategory = dataContext.LaptopCategories.Select(p => p).ToList();
            var pcCategory = dataContext.PCCategories.Select(p => p).ToList();
            ViewBag.LaptopCategory = laptopCategory;
            ViewBag.PCCategory = pcCategory;
            ViewBag.PC = itemPC;
            ViewBag.Laptop = itemLaptop;
            return View(item);
        }
        public IActionResult Laptop()
        {
            var itemLaptop = dataContext.Products.Where(p => p.CategoryId == 1).ToList();
            return View(itemLaptop);
        }
        public IActionResult LaptopCategory(int id)
        {
            var itemLaptop = dataContext.Products.Where(p => p.CategoryId == 1).ToList();
            var laptops = new List<Laptop>();
            var result = new List<Product>();
            foreach (var item in itemLaptop)
            {
                Laptop laptop = dataContext.Laptops.FirstOrDefault(p => p.ProductId == item.ProductId && p.LaptopCategoryId == id);
                laptops.Add(laptop);
            }
            foreach (var item in laptops)
            {
                if(item != null)
                {
                    Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                    result.Add(product);
                }
            }
            ViewBag.LaptopCategory = dataContext.LaptopCategories.Find(id).LaptopCategoryName;
            if(result.Count > 0)
                 return View(result.ToList());
             else
                 return View();
        }
        public IActionResult PC()
        {
            var itemPC = dataContext.Products.Where(p => p.CategoryId == 2).ToList();
            return View(itemPC);
        }
        public IActionResult PCCategory(int id)
        {
            var itemPC = dataContext.Products.Where(p => p.CategoryId == 2).ToList();
            var pcs = new List<PC>();
            var result = new List<Product>();
            foreach (var item in itemPC)
            {
                PC pc = dataContext.PCs.FirstOrDefault(p => p.ProductId == item.ProductId && p.PCId == id);
                pcs.Add(pc);
            }
            foreach (var item in pcs)
            {
                if (item != null)
                {
                    Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                    result.Add(product);
                }
            }
            ViewBag.PCCategory = dataContext.PCCategories.Find(id).PCCategoryName;
            if (result.Count > 0)
                return View(result.ToList());
            else
                return View();
        }
        public IActionResult Product()
        {
            var item = dataContext.Products.Select(p => p).ToList();
            return View(item);
        }
        public IActionResult Search(string search)
        {
            var query = dataContext.Products.Where(p => p.ProductName.Contains(search)).ToList();
            if (!string.IsNullOrEmpty(search))
                return View(query);
            return RedirectToAction("Index");
        }
        public IActionResult Intro()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if(ModelState.IsValid)
            {
                Contact newContact = new Contact
                {
                    ContactAddress = contact.ContactAddress,
                    ContactEmail = contact.ContactEmail,
                    ContactName = contact.ContactName,
                    ContactNote = contact.ContactNote,
                    ContactPhone = contact.ContactPhone
                };
                dataContext.Contacts.Add(newContact);
                dataContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
                return View(contact);
        }
        public IActionResult FilterLaptop(string brand, string cpu)
        {
            if (SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "cpuList") == null)
            {
                List<string> cpuList = new List<string>
                {
                    cpu
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cpuList", cpuList);
            }
            else
            {
                List<string> cpuList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "cpuList");
                string index = Exist(cpu);
                if (index != "")
                    cpuList.Remove(cpu);
                else
                    cpuList.Add(cpu);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cpuList", cpuList);
            }
            List<string> cpuResult = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "cpuList");
            List<Product> result = new List<Product>();
            List<Laptop> resultLaptop = new List<Laptop>();
            foreach (var item in cpuResult)
            {
                var queryCPU = dataContext.Laptops.Where(p => p.LaptopCPU.Contains(item));
                foreach (var itemCPU in queryCPU)
                {
                    resultLaptop.Add(itemCPU);
                }
            }
            //Bỏ code này vào hàm private
            for (int i = 0; i < resultLaptop.Count; i++)
            {
                if (resultLaptop[i] == null)
                    break;
                for (int j = i + 1; j < resultLaptop.Count; j++)
                {
                    if (resultLaptop[i].ProductId == resultLaptop[j].ProductId)
                    {
                        resultLaptop.RemoveAt(j);
                        break;
                    }
                }
            }
            foreach (var item in resultLaptop)
            {
                Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                result.Add(product);
            }
            return View("Laptop", result);
        }
        public IActionResult DeleteFilterLaptop()
        {
            return View();
        }
        private string Exist(string cpu)
        {
            List<string> cpuList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "cpuList");
            for(int i = 0; i < cpuList.Count; i++)
            {
                if (cpuList[i] == cpu)
                    return cpu;
            }
            return "";
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
