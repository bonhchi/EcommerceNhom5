using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraintreeHttp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayPal.Core;
using PayPal.v1.Payments;
using PCWeb.Data;
using PCWeb.Helper;
using PCWeb.Models;
using PCWeb.Models.Source;

namespace PCWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IConfiguration config;
        private readonly string clientId;
        private readonly string secretKey;
        private const double exchange = 23220;
        private const string currency = "USD";

        public CartController(DataContext dataContext, IConfiguration config)
        {
            this.dataContext = dataContext;
            this.config = config;
            clientId = config["PaypalSetting:ClientId"];
            secretKey = config["PaypalSetting:SecretKey"];
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
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.ProductPrice * item.Quantity);
            }
            var order = new Models.Order();
            var paymentMethod = dataContext.PaymentMethods.ToList();
            return View(order);
        }
        [HttpPost]
        public IActionResult Checkout(Models.Order order, string answer)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (ModelState.IsValid)
            {
                if(answer == "paypal")
                {
                    Models.Order orderTemp = new Models.Order
                    {
                        OrderDate = DateTime.Now,
                        Phone = order.Phone,
                        Address = order.Address,
                        Email = order.Email,
                        CusName = order.CusName,
                        OrderConditionId = 1,
                        PaymentMethodId = 2
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
                    return RedirectToAction("CheckoutPaypal", "Cart");
                }
                else
                {
                    Models.Order orderTemp = new Models.Order
                    {
                        OrderDate = DateTime.Now,
                        Phone = order.Phone,
                        Address = order.Address,
                        Email = order.Email,
                        CusName = order.CusName,
                        PaymentMethodId = 1
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
        public async Task<IActionResult> PaypalCheckout()
        {
            var environment = new SandboxEnvironment(clientId, secretKey);
            var client = new PayPalHttpClient(environment);
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };
            var total = cart.Sum(item => item.Product.ProductPrice * item.Quantity);
            foreach(var item in cart)
            {
                itemList.Items.Add(new Item()
                {
                    Name = item.Product.ProductName,
                    Currency = currency,
                    Price = Math.Round(item.Product.ProductPrice / exchange, 2).ToString(),
                    Quantity = item.Quantity.ToString(),
                    Sku = item.Product.ProductSeries,
                    Tax = "0"
                });

            }
            int orderId = dataContext.Orders.Count() + 1;
            var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction ()
                    {
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = currency,
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = total.ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = $"Invoice #{orderId}",
                        InvoiceNumber = orderId.ToString()
                    }
                },
                //direct đến trang nào đó trả lệnh
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = $"{hostname}/Cart/Fail",
                    ReturnUrl = $"{hostname}/Cart/Checkout",
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };
            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);
            try
            {
                var response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();
                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while(links.MoveNext())
                {
                    LinkDescriptionObject link = links.Current;
                    if (link.Rel.ToLower().Trim().Equals("approval_url"))
                        paypalRedirectUrl = link.Href;
                }
                return Redirect(paypalRedirectUrl);   
            }
            catch(HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                return Redirect("/Cart/Fail");
            }
        }
        [HttpPost]
        public IActionResult TestCheckbox(string answer)
        {
            if (answer == "1")
                return Redirect("~/Home/Index");
            else
                return Redirect("~/Index");
        }
        public IActionResult Fail()
        {
            return View();
        }
    }
}
