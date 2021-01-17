using courseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using courseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            int pageSize = 1;

            IQueryable<Test> tests = DataContext.Tests;
            int totalOfTests = await tests.CountAsync();
            List<Test> testsOfCurrentPage = await tests.Skip((numPage - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(totalOfTests, numPage, pageSize);

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Tests = testsOfCurrentPage
            };

            return View(viewModel);
        }

        
        public IActionResult Category(int? id)  // контроллер для страницы c уникальной категорией
        {
            //выполняем переадресацию на метод Index, который выводит список тестов.
            if (id == null) return RedirectToAction("Index");

            Category currentCategory = DataContext.Categories.FirstOrDefault(c => c.Id == id);

            if (currentCategory != null)
            {
                CategoryViewModel model = new CategoryViewModel();

                model.Category = currentCategory;
                model.Tests = from t in DataContext.Tests
                              where (t.CategoryId == id)
                              select t; ;

                return View(model);
            }
            return NotFound();
        }
    }
}
//Во-первых, здесь удалены все ненужные нам методы - все кроме метода Index,
//который будет использоваться для передачи пользователю данных о товарах.
