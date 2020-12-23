﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCWeb.Data;
using PCWeb.Models;
using PCWeb.Models.Source;

namespace PCWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator, Staff")]
    public class OrderController : Controller
    {
        private readonly DataContext dataContext;
        public OrderController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Index(string search)
        {
            var item = dataContext.Orders.Select(p => p).ToList();
            List<OrderCondition> orderConditions = new List<OrderCondition>();
            foreach (var item2 in item)
            {
                OrderCondition orderCondition = dataContext.OrderConditions.FirstOrDefault(p => p.OrderConditionId == item2.OrderConditionId);
                orderConditions.Add(orderCondition);
            }
            if (!string.IsNullOrEmpty(search))
            {
                var query = dataContext.Orders.Where(p => p.Email.Contains(search)).ToList();
                return View(query);
            }
            return View(item);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Order oldOrder = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            return View(oldOrder);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Order order = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            dataContext.Orders.Remove(order);
            dataContext.SaveChanges();
            return RedirectToAction("Index", "Order");
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Order order = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            var item = dataContext.OrderDetails.Where(p => p.OrderId == order.OrderId).ToList();
            List<Product> products = new List<Product>();
            foreach (var item2 in item)
            {
                Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == item2.ProductId);
                products.Add(product);
            }
            TestViewBag(item);
            return View(order);
        }
        private void TestViewBag(List<OrderDetail> order)
        {
            ViewBag.order = order;
            double total = order.Sum(item => item.Product.ProductPrice * item.Quantity);
            double vat = dataContext.Fees.FirstOrDefault(p => p.FeeId == 2).FeeAmount / 100;
            double vatFee = vat * total;
            double weight = 0;
            foreach (var item in order)
            {
                weight += (item.Product.ProductPackage * item.Quantity);
            }
            double weightCost = weight * dataContext.Fees.FirstOrDefault(p => p.FeeId == 1).FeeAmount;
            ViewBag.VAT = (vat * 100).ToString();
            ViewBag.VATfee = vatFee;
            ViewBag.Weight = weight.ToString();
            ViewBag.WeightCost = weightCost;
            ViewBag.total = total + vatFee + weightCost;
            ViewBag.Point = total / 10000;
        }
        [HttpGet]
        public IActionResult Condition(int id)
        {
            Order order = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            var condition = dataContext.OrderConditions.Select(p => p).ToList();
            OrderCondition orderCondition = dataContext.OrderConditions.FirstOrDefault(p => p.OrderConditionId == order.OrderConditionId);
            ViewBag.Condition = new SelectList(condition, "OrderConditionId", "OrderConditionName", orderCondition.OrderConditionId);
            return View(order);
        }
        [HttpPost]
        public IActionResult Condition(Order order, int id)
        {
            Order changeCondition = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            changeCondition.OrderConditionId = order.OrderConditionId;
            if(order.OrderConditionId == 5 && order.OrderCheckout == "Chưa thanh toán")
            {
                changeCondition.OrderCheckout = "Đã thanh toán";
            }
            dataContext.SaveChanges();
            if(order.OrderCheckout == "Đã thanh toán")
            {
                var orderList = dataContext.OrderDetails.Where(p => p.OrderId == id).ToList();
                List<Product> products = new List<Product>();
                foreach(var item in orderList)
                {
                    Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                    products.Add(product);
                    var revenueId = dataContext.Revenues.FirstOrDefault(p => p.ProductId == item.ProductId).RevenueId;
                    dataContext.RevenueDetails.Add(new RevenueDetail()
                    {
                        RevenueId = revenueId,
                        DateIssue = DateTime.Now,
                        Quantity = item.Quantity,
                        PriceReality = item.Product.ProductPrice
                    });
                }
            };
            dataContext.SaveChanges();
            return RedirectToAction("Index", "Order");
        }
    }
}
