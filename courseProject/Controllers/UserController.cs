using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using courseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using courseProject.ViewModels;
using сourseProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Web.Helpers;
using System;

namespace courseProject.Controllers
{

    [Authorize]
    public class UserController : ApplicationController
    {
        public UserController(ApplicationDbContext context) : base(context) { }

        public async Task<IActionResult> IndexAsync()
        {
            string userName = User.Identity.Name;

            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName);

            AccountViewModel model = new AccountViewModel();

            model.User = currentUser;
            model.UserTests = (from ut in DataContext.UserTests.Include(ut => ut.Test)
                               where (ut.UserId == currentUser.Id && ut.Favorite)
                               select ut).ToList();

            return View(model);
        }

        
        public async Task<IActionResult> ChangePersonalData(PersonalViewModel model)
        {
           
            string userName = User.Identity.Name;

            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName);

            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.Gender = model.Gender;
            currentUser.Birthday = model.Birthday;
            await DataContext.SaveChangesAsync();
            return RedirectToAction("Index", "User");
        }

        
        public async Task<IActionResult> ChangeRegisterData(RegisterViewModel model)
        {
            if (model.Email == null && model.Password == null) return RedirectToAction("Index");

            string userName = User.Identity.Name;
            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName);

            if (model.Email != null && !DataContext.Users.Any(u => u.Email == model.Email))
            {
                currentUser.Email = model.Email;

                await DataContext.SaveChangesAsync();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await Authenticate(model.Email); // аутентификация
            }
            if (model.Password != null)
            {
                string hashPassword = Crypto.HashPassword(model.Password);
                currentUser.Password = hashPassword;
                await DataContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        private Task Authenticate(string email)
        {
            throw new NotImplementedException();
        }
    }
}