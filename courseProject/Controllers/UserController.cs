using System.Security.Claims;
using Microsoft.EntityFrameworkCore; // пространство имен EntityFramework
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

    [Authorize] // все методы будут выполняться для авторизованных пользователей, в противном случие будет происходить перенаправление на страницу входа
    public class UserController : ApplicationController
    {
        public UserController(ApplicationDbContext context) : base(context) { } // Вызывает конструктор ApplicationController

        public async Task<IActionResult> IndexAsync()  // выполняется для адресса User/Index
        {
            string userName = User.Identity.Name; // получаем Email пользователя

            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName); // получаем объект авторизованного пользователя

            AccountViewModel model = new AccountViewModel(); // Модель-представление для личного кабинета

            model.User = currentUser;
            model.UserTests = (from ut in DataContext.UserTests.Include(ut => ut.Test) // Получаем понравившееся тесты пользователя из бд
                               where (ut.UserId == currentUser.Id && ut.Favorite)
                               select ut).ToList();

            return View(model);
        }

        
        public async Task<IActionResult> ChangePersonalData(PersonalViewModel model) // выполняется для адресса User/ChangePersonalData
        {
           
            string userName = User.Identity.Name; // получаем Email пользователя

            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName); // получаем объект авторизованного пользователя

            // обновляем данные пользователя в бд
            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.Gender = model.Gender;
            currentUser.Birthday = model.Birthday;

            await DataContext.SaveChangesAsync(); // сохраняем обновленные данные пользователя в бд

            return RedirectToAction("Index", "User"); //обновляем страницу
        }

        
        public async Task<IActionResult> ChangeRegisterData(RegisterViewModel model)  // выполняется для адресса User/ChangeRegisterData
        {
            if (model.Email == null && model.Password == null) return RedirectToAction("Index"); // если не введен Email или пароль, перезагружаем страницу

            string userName = User.Identity.Name; // получаем Email пользователя
            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName); // получаем объект авторизованного пользователя

            if (model.Email != null && !DataContext.Users.Any(u => u.Email == model.Email))  // если введен Email и и такой Email нигде не зафиксирован в бд
            {
                currentUser.Email = model.Email; // обновляем Email пользователя

                await DataContext.SaveChangesAsync(); // сохраняем обновления
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await Authenticate(model.Email); // аутентификация
            }
            if (model.Password != null) // если введен пароль
            {
                string hashPassword = Crypto.HashPassword(model.Password); // создаем хэш пароля
                currentUser.Password = hashPassword; // обновляем пароль пользователя
                await DataContext.SaveChangesAsync(); // сохраняем обновления
            }
            return RedirectToAction("Index");  // обновляем страницу
        }
    }
}