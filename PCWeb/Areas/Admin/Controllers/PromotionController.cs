using Microsoft.AspNetCore.Mvc;
using PCWeb.Data;
using PCWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCWeb.Areas.Admin.Controllers
{
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
                    PromotionApply = promotion.PromotionApply,
                    PromotionCode = promotion.PromotionCode,
                    PromotionName = promotion.PromotionName
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
                oldPromotion.PromotionApply = promotion.PromotionApply;
                oldPromotion.PromotionCode = promotion.PromotionCode;
                oldPromotion.PromotionName = promotion.PromotionName;
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
            dataContext.Promotions.Remove(promotion);
            dataContext.SaveChanges();
            return RedirectToAction("Index", "Promotion");
        }
    }
}
