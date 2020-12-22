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
    public class PromotionController : Controller
    {
        private readonly DataContext dataContext;

        public PromotionController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var promotion = dataContext.Promotions.ToList();
            return View(promotion);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Promotion promotion = new Promotion();
            return View(promotion);
        }
        [HttpPost]
        public IActionResult Add(Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                Promotion newPromotion = new Promotion
                {
                    PromotionDiscount = promotion.PromotionDiscount,
                    PromotionCode = promotion.PromotionCode,
                    PromotionName = promotion.PromotionName,
                };
                dataContext.Promotions.Add(newPromotion);
                dataContext.SaveChanges();
                return RedirectToAction("Index", "Promotion");
            }
            else
                return View(promotion);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Promotion promotion = dataContext.Promotions.FirstOrDefault(p => p.PromotionId == id);
            return View(promotion);
        }
        [HttpPost]
        public IActionResult Edit(int id, Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                Promotion oldPromotion = dataContext.Promotions.FirstOrDefault(p => p.PromotionId == id);
                oldPromotion.PromotionCode = promotion.PromotionCode;
                oldPromotion.PromotionName = promotion.PromotionName;
                oldPromotion.PromotionDiscount = promotion.PromotionDiscount;
                dataContext.SaveChanges();
                ViewBag.Status = 1;
                return RedirectToAction("Index", "Promotion");
            }
            else
                return View(promotion);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Promotion promotion = dataContext.Promotions.FirstOrDefault(p => p.PromotionId == id);
            return View(promotion);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Promotion promotion = dataContext.Promotions.FirstOrDefault(p => p.PromotionId == id);
            var productDetail = dataContext.PromotionDetails.Where(p => p.PromotionId == id);
            foreach (var itemDetail in productDetail)
            {
                Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == itemDetail.ProductId);
                product.ProductPriceReality = product.ProductPrice;
            }
            dataContext.SaveChanges();
            dataContext.Promotions.Remove(promotion);
            dataContext.SaveChanges();
            return RedirectToAction("Index", "Promotion");
        }
        [HttpGet]
        public IActionResult Apply(int id)
        {
            Promotion promotion = dataContext.Promotions.FirstOrDefault(p => p.PromotionId == id);
            return View(promotion);
        }
        [HttpPost]
        public IActionResult Apply(int id, Promotion promotion)
        {
            Promotion changePromotion = dataContext.Promotions.FirstOrDefault(p => p.PromotionId == id);
            var productApply = dataContext.Products.Where(p => p.ProductCode.Contains(promotion.PromotionCode)).ToList();
            foreach(var item in productApply)
            {
                dataContext.PromotionDetails.Add(new PromotionDetail()
                {
                    ProductId = item.ProductId,
                    PromotionId = id
                });
                
            }
            dataContext.SaveChanges();
            var productDetail = dataContext.PromotionDetails.Where(p => p.PromotionId == id);
            foreach(var itemDetail in productDetail)
            {
                Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == itemDetail.ProductId);
                product.ProductPriceReality -= (product.ProductPriceReality * (itemDetail.Promotion.PromotionDiscount / 100));
            }
            dataContext.SaveChanges();
            return RedirectToAction("Index", "Promotion");
        }
    }
}
