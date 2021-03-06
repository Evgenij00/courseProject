﻿using courseProject.Models;
using Microsoft.AspNetCore.Mvc;
using courseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace courseProject.Controllers
{
    //TODO: разобрать как инкапсулировать общие действия в ApplicationController
    public class HomeController : ApplicationController
    {
        //ничего не выполняет. Вызывает конструктор ApplicationController
        public HomeController(ApplicationDbContext context) : base(context) { }

        //Каждый метод контроллера по умоланию использует одноименное представление.
        //То есть метод Index будет использовать представление Index.cshtml.
        public async Task<IActionResult> IndexAsync(int numPage = 1)
        {
            //И в этот метод передаются все объекты из таблицы Tests в базе данных.
            //Для передачи данных нам достаточно использовать такую конструкцию: View(db.Tests.ToList());

            int pageSize = 10;

            IQueryable<Test> tests = DataContext.Tests;
            int totalOfTests = await tests.CountAsync();
            List<Test> testsOfCurrentPage = await tests.Skip((numPage - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(totalOfTests, numPage, pageSize);

            await MarkFavoriteTests();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Tests = testsOfCurrentPage
            };

            return View(viewModel);
        }


        public async Task<IActionResult> Category(int? categoryId, int numPage = 1)
        {
            //выполняем переадресацию на метод Index, который выводит список тестов.
            if (categoryId == null) return RedirectToAction("Index");

            Category currentCategory = await DataContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (currentCategory != null)
            {
                int pageSize = 10;

                IQueryable<Test> tests = from t in DataContext.Tests
                                         where (t.CategoryId == categoryId)
                                         select t;

                int totalOfTests = await tests.CountAsync();
                List<Test> testsOfCurrentPage = await tests.Skip((numPage - 1) * pageSize).Take(pageSize).ToListAsync();

                PageViewModel pageViewModel = new PageViewModel(totalOfTests, numPage, pageSize);

                await MarkFavoriteTests();

                CategoryViewModel viewModel = new CategoryViewModel
                {
                    PageViewModel = pageViewModel,
                    Tests = testsOfCurrentPage,
                    Category = currentCategory
                };

                return View(viewModel);
            }
            return NotFound();
        }
        public async Task<IActionResult> Search(string searchString)
        {
            if (searchString == null) return RedirectToAction("Index");

            IQueryable<Test> tests = DataContext.Tests;

            if (!String.IsNullOrEmpty(searchString))
            {
                tests = tests.Where(t => t.Name.Contains(searchString));
            }

            List<Test> filteredTests = await tests.ToListAsync();

            await MarkFavoriteTests();

            return View(filteredTests);
        }
        [NonAction]
        private async Task MarkFavoriteTests()
        {
            string userName = User.Identity.Name;

            if (userName != null)
            {
                User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName);

                List<UserTest> userTests = await (from ut in DataContext.UserTests.Include(ut => ut.Test)
                                                  where (ut.UserId == currentUser.Id && ut.Favorite)
                                                  select ut).ToListAsync();

                foreach (var usertest in userTests)
                {
                    usertest.Test.Favorite = true;
                }
            }
        }
    }
}
//Во-первых, здесь удалены все ненужные нам методы - все кроме метода Index,
//который будет использоваться для передачи пользователю данных о товарах.
