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

        
        public IActionResult Category(int? id)  // контроллер для страницы c уникальной категорией
        {
            if (id == null) return RedirectToAction("Index"); //выполняем переадресацию на метод Index, который выводит список тестов.

            Category category = DataContext.Categories.FirstOrDefault<Category>(c => c.Id == id);

            if (category != null)
            {
                //ViewBag.Categories = DataContext.Categories.OrderBy(c => c.Id);
                //ViewBag.Tests = DataContext.Tests;
                //ViewBag.Test = DataContext.Tests.Find(id);

                ViewBag.Categories = DataContext.Categories;
                ViewBag.Tests = from t in DataContext.Tests
                                where (t.CategoryId == id)
                                select t;

                return View(category);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Test(int? id)  // контроллер для страницы с уникальным тестом
        {
            if (id == null) return RedirectToAction("Index"); //выполняем переадресацию на метод Index, который выводит список тестов.

            //Test test = DataContext.Tests.FirstOrDefault<Test>(t => t.Id == id);

            //TODO: разобраться, как вызвать Include после отбора данных по условию. (Пока вызывается перед отбором)
            var test = DataContext.Tests.Include(t => t.Questions.OrderBy(q => q.Number)).FirstOrDefault<Test>(t => t.Id == id);

            if (test != null)
            {
                //TODO: сделать сортировку
                //List<Question> questions = test.Questions;
                //Response.Write(questions);
                //ViewBag.Categories = DataContext.Categories.OrderBy(c => c.Id);


                ViewBag.Categories = DataContext.Categories;
                return View(test);
            }
            return NotFound();

            //Чтобы передать id теста в представление применяется объект ViewBag.
            //ViewBag представляет такой объект,
            //который позволяет определить любую переменную и передать ей некоторое значение,
            //а затем в представлении извлечь это значение.
            //Так, мы определяем переменную ViewBag.TestId, которая и будет хранить id выбранного теста.
            //ViewBag.TestId = id;
            //return View();
        }

        [HttpPost]
        public IActionResult Question(int? id, int num = 1, int answer_score = 0)  // контроллер для страницы с уникальным тестом
        {
            if (id == null) return RedirectToAction("Index"); //выполняем переадресацию на метод Index, который выводит список тестов.

            //Test test = DataContext.Tests.Include(t => t.Questions).FirstOrDefault<Test>(t => t.Id == id);

            Test test = DataContext.Tests.FirstOrDefault(test => test.Id == id);

            //TODO: подумать, как упростить запрос. Найти нужный вопрос через тест, а не через контекст данных
            Question q = DataContext.Questions.Include(q => q.Answers).FirstOrDefault<Question>(q => q.TestId == id && q.Number == num);

            if (q != null)
            {
                //return View(test);
                //List<Question> questions = test.Questions
                //return Ok(questions);
                //Response.Write(questions
                //ViewBag.Categories = DataContext.Categories.OrderBy(c => c.Id);


                ViewBag.Categories = DataContext.Categories;
                ViewBag.Test = test;

                //foreach(var a in q.Answers.OrderBy(a => a.Id))
                foreach (var a in q.Answers)
                {
                    a.Score = a.Score + answer_score;
                }
                return View(q);
            }
            return NotFound();
        }
    }
}
//Во-первых, здесь удалены все ненужные нам методы - все кроме метода Index,
//который будет использоваться для передачи пользователю данных о товарах.
