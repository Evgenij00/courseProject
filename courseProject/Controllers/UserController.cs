﻿using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using courseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using сourseProject.ViewModels;
using System.Collections.Generic;

namespace courseProject.Controllers
{
    public class UserController : ApplicationController
    {
        public UserController(ApplicationDbContext context) : base(context) { }

        public async Task<IActionResult> IndexAsync()
        {
            string userName = User.Identity.Name;

            User currentUser = DataContext.Users.FirstOrDefault(u => u.Email == userName);

            if (currentUser == null)
            {
                return NotFound();
            }

            return View(currentUser);
        }

        //TODO: валидация модели
        public async Task<IActionResult> ChangePersonalData(PersonalViewModel model)
        {
            //if (ModelState.IsValid) {}
            //return View(model);

            string userName = User.Identity.Name;
            User currentUser = DataContext.Users.FirstOrDefault(u => u.Email == userName);

            if (currentUser != null)
            {
                // обновляем пользователя в бд
                currentUser.FirstName = model.FirstName;
                currentUser.LastName = model.LastName;
                currentUser.Gender = model.Gender;
                currentUser.Birthday = model.Birthday;
                await DataContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "User");
        }

        //TODO: одинаковый email
        public async Task<IActionResult> ChangeRegisterData(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                User user = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user == null)
                {

                    string userName = User.Identity.Name;

                    User currentUser = DataContext.Users.FirstOrDefault(u => u.Email == userName);

                    if (currentUser != null)
                    {
                        // обновляем пользователя в бд
                        currentUser.Email = model.Email;
                        currentUser.Password = model.Password;

                        await DataContext.SaveChangesAsync();

                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                        //Аутентификация
                        List<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Email)
                            };

                        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                        //Аутентификация
                    }
                    else
                    {
                        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким Email уже существует");
                }
            }
            return RedirectToAction("Index", "User");
        }
    }
}