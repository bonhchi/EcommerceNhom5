﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCWeb.Models.Account;

namespace PCWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            string[] gender = { "Nam", "Nữ" };
            ViewBag.Selected = gender.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistation userModel, string name)
        {
            string[] gender = { "Nam", "Nữ" };
            userModel.Gender = name;
            if (!ModelState.IsValid)
            {
                ViewBag.Selected = gender.ToList();
                return View(userModel);
            }
            var user = _mapper.Map<User>(userModel);
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                ViewBag.Selected = gender.ToList();
                return View(userModel);
            }
            await _userManager.AddToRoleAsync(user, "Customer");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin userModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = new UserInfo
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                DayOfBirth = user.DayOfBirth
            };
            ViewBag.Id = id;
            return View(model);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            string[] gender = { "Nam", "Nữ" };
            ViewBag.Selected = gender.ToList();
            var user = await _userManager.FindByIdAsync(id);
            var model = new UserEdit
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                DayOfBirth = user.DayOfBirth
            };
            ViewBag.Id = id;
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string id, UserEdit userModel, string name)
        {
            string[] gender = { "Nam", "Nữ" };
            userModel.Gender = name;
            var user = await _userManager.FindByIdAsync(id);
            if (ModelState.IsValid)
            {
                user.DayOfBirth = userModel.DayOfBirth;
                user.Email = userModel.Email;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                //user.Gender = userModel.Gender;
                user.PhoneNumber = userModel.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    ViewBag.Status = 1;
                    ViewBag.Id = id;
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ViewBag.Selected = gender.ToList();
            }
            ViewBag.Id = id;
            return View(userModel);
        }
        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return RedirectToAction("Index","Home");
                }
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    ViewBag.Id = id;
                    return View();
                }
                ViewBag.Status = 1;
                ViewBag.Id = id;
                await _signInManager.RefreshSignInAsync(user);
            }
            ViewBag.Id = id;
            return View(model);
        }
    }
}