using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCWeb.Data;
using PCWeb.Helper;
using PCWeb.Models;
using PCWeb.Models.Source;

namespace PCWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext dataContext;
        public CartController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.ProductPrice * item.Quantity);
            }
            return View();
        }
        //[Route("quantity/{id}")]
        public IActionResult Quantity(int id, int quantity)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            if (index != -1)
                cart[index].Quantity = quantity;
            var query = dataContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (quantity > query.ProductQuantity)
                ViewBag.Status = 1;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart") == null)
            {
                List<OrderDetail> cart = new List<OrderDetail>
                {
                    new OrderDetail { Product = dataContext.Products.FirstOrDefault(p => p.ProductId == id), Quantity = 1}
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                    cart[index].Quantity++;
                else
                    cart.Add(new OrderDetail { Product = dataContext.Products.FirstOrDefault(p => p.ProductId == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        //[Route("remove/{id}")]
        //[HttpPost]
        public IActionResult Remove(int id)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        private int IsExist(int id)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Confirm()
        {
            ViewBag.Status = TempData["check"];
            return View();
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.ProductPrice * item.Quantity);
            }
            var order = new Order();
            return View(order);
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (ModelState.IsValid)
            {
                Order orderTemp = new Order
                {
                    OrderDate = DateTime.Now,
                    Phone = order.Phone,
                    Address = order.Address,
                    Email = order.Email,
                    CusName = order.CusName,
                    OrderConditionId = 1
                };
                dataContext.Orders.Add(orderTemp);
                dataContext.SaveChanges();
                var query = dataContext.Orders.FirstOrDefault(p => p.OrderId == orderTemp.OrderId);
                foreach (var item in cart)
                {
                    dataContext.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = query.OrderId,
                        ProductId = item.Product.ProductId,
                        Quantity = item.Quantity,
                    });
                    Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == item.Product.ProductId);
                    product.ProductQuantity -= item.Quantity;
                }
                dataContext.SaveChanges();
                cart.Clear();
                TempData["check"] = query.OrderId;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Confirm", "Cart");
            }
            else
            {
                if (cart != null)
                {
                    ViewBag.cart = cart;
                    ViewBag.total = cart.Sum(item => item.Product.ProductPrice * item.Quantity);
                }
                else
                    return View();
                return View(order);
            }
        }
    }
}
