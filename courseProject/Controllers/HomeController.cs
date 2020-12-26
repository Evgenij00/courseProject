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
        //private TestsContext db;
        public HomeController(ApplicationDbContext context) : base(context)
        { //ничего не выполняет. Вызывает конструктор ApplicationController
            //List<Category> temp = DataContext.Categories.ToList();
            //ViewBag.Categories = temp;
        }

        //Каждый метод контроллера по умоланию использует одноименное представление.
        //То есть метод Index будет использовать представление Index.cshtml.
        public IActionResult Index()
        {

            //И в этот метод передаются все объекты из таблицы Tests в базе данных.
            //Для передачи данных нам достаточно использовать такую конструкцию: db.Tests.ToList().
            //return View(db.Tests.ToList());

            //TODO: нужно инкапсулировать в ApplicationController
            //ViewBag.Categories = DataContext.Categories.OrderBy(c => c.Id);

            ViewBag.Categories = DataContext.Categories;

            //TODO: Решить, создавать контейнер для нескольких моделей или все передавать через ViewBag
            CategoryTest model = new CategoryTest();

            //TODO: разобраться, необходим ли метод ToList()
            model.Tests = DataContext.Tests.OrderBy(t => t.Id).ToList();
            model.Categories = DataContext.Categories.OrderBy(c => c.Id).ToList();

            return View(model);
            //TODO: Решить, создавать контейнер для нескольких моделей или все передавать через ViewBag
        }
    }
}
//Во-первых, здесь удалены все ненужные нам методы - все кроме метода Index,
//который будет использоваться для передачи пользователю данных о товарах.
