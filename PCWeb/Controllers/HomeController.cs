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
        private const string KeyCPU = "cpuList";
        private const string KeyBrand = "brandList";
        private const string KeyPrice = "priceList";
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
        public IActionResult FilterCPULaptop(string cpu)
        {
            if (SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyCPU) == null)
            {
                List<string> cpuList = new List<string>
                {
                        cpu
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, KeyCPU, cpuList);
            }
            else
            {
                List<string> cpuList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyCPU);
                string index = ExistCPU(cpu);
                if (index != "")
                    cpuList.Remove(cpu);
                else
                    cpuList.Add(cpu);
                SessionHelper.SetObjectAsJson(HttpContext.Session, KeyCPU, cpuList);
            }
            List<string> cpuResult = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyCPU);
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
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == null)
                    break;
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].ProductId == result[j].ProductId)
                    {
                        result.RemoveAt(j);
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

        public IActionResult FilterBrandLaptop(string brand)
        {
            if (SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyBrand) == null)
            {
                List<string> brandList = new List<string>
                {
                    brand
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, KeyBrand, brandList);
            }
            else
            {
                List<string> brandList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyBrand);
                string index = ExistBrand(brand);
                if (index != "")
                    brandList.Remove(brand);
                else
                    brandList.Add(brand);
                SessionHelper.SetObjectAsJson(HttpContext.Session, KeyBrand, brandList);
            }
            List<string> brandResult = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyBrand);
            List<Product> resultTemp = new List<Product>();
            var brandName = dataContext.Brands.ToList();
            foreach (var item in brandResult)
            {
                var queryBrand = dataContext.Products.Where(p => p.Brand.BrandName.Contains(item));
                foreach (var itemBrand in queryBrand)
                {
                    resultTemp.Add(itemBrand);
                }
            }
            //Bỏ code này vào hàm private
            for (int i = 0; i < resultTemp.Count; i++)
            {
                if (resultTemp[i] == null)
                    break;
                for (int j = i + 1; j < resultTemp.Count; j++)
                {
                    if (resultTemp[i].ProductId == resultTemp[j].ProductId)
                    {
                        resultTemp.RemoveAt(j);
                        break;
                    }
                }
            }
            var laptop = dataContext.Laptops.ToList();
            List<Product> result = new List<Product>();
            for(int i = 0; i < resultTemp.Count; i++)
            {
                for(int j = 0; j < laptop.Count; j++)
                {
                    if (resultTemp[i].ProductId == laptop[j].ProductId)
                        result.Add(resultTemp[i]);
                }
            }
            return View("Laptop", result);
        }
        public IActionResult FilterPriceLaptop(string price)
        {
            if (SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyPrice) == null)
            {
                List<string> priceList = new List<string>
                {
                    price
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, KeyPrice, priceList);
            }
            else
            {
                List<string> priceList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyPrice);
                string index = ExistPrice(price);
                if (index != "")
                    priceList.Remove(price);
                else
                    priceList.Add(price);
                SessionHelper.SetObjectAsJson(HttpContext.Session, KeyPrice, priceList);
            }
            List<string> priceResult = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyPrice);
            List<Product> resultTemp = new List<Product>();
            List<Product> queryPrice = new List<Product>();
            foreach (var item in priceResult)
            {
                if (item == "20tr")
                {
                    queryPrice = dataContext.Products.Where(p => p.ProductPrice >= 20000000 && p.ProductPrice <= 30000000).ToList();
                }
                if(item == "60tr")
                {
                    queryPrice = dataContext.Products.Where(p => p.ProductPrice >= 60000000 && p.ProductPrice <= 70000000).ToList();
                }
                if (item == "120tr")
                {
                    queryPrice = dataContext.Products.Where(p => p.ProductPrice >= 120000000).ToList();
                }
                if (queryPrice != null)
                {
                    foreach (var itemPrice in queryPrice)
                    {
                        resultTemp.Add(itemPrice);
                    }
                }
                
            }
            //Bỏ code này vào hàm private
            for (int i = 0; i < resultTemp.Count; i++)
            {
                if (resultTemp[i] == null)
                    break;
                for (int j = i + 1; j < resultTemp.Count; j++)
                {
                    if (resultTemp[i].ProductId == resultTemp[j].ProductId)
                    {
                        resultTemp.RemoveAt(j);
                        break;
                    }
                }
            }
            var laptop = dataContext.Laptops.ToList();
            List<Product> result = new List<Product>();
            for (int i = 0; i < resultTemp.Count; i++)
            {
                for (int j = 0; j < laptop.Count; j++)
                {
                    if (resultTemp[i].ProductId == laptop[j].ProductId)
                        result.Add(resultTemp[i]);
                }
            }
            return View("Laptop", result);
        }
        public IActionResult DeleteFilterLaptop()
        {
            return View();
        }
        private string ExistCPU(string cpu)
        {
            List<string> cpuList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyCPU);
            for(int i = 0; i < cpuList.Count; i++)
            {
                if (cpuList[i] == cpu)
                    return cpu;
            }
            return "";
        }

        private string ExistPrice(string price)
        {
            List<string> priceList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyPrice);
            for (int i = 0; i < priceList.Count; i++)
            {
                if (priceList[i] == price)
                    return price;
            }
            return "";
        }
        private string ExistBrand(string brand)
        {
            List<string> brandList = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, KeyBrand);
            for (int i = 0; i < brandList.Count; i++)
            {
                if (brandList[i] == brand)
                    return brand;
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
