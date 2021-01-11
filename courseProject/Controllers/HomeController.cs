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
        public IActionResult Index()
        {
            //И в этот метод передаются все объекты из таблицы Tests в базе данных.
            //Для передачи данных нам достаточно использовать такую конструкцию: View(db.Tests.ToList());

            //TODO: разобраться, необходим ли метод ToList()
            List<Test> Tests = DataContext.Tests.ToList();

            return View(Tests);
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

        [HttpPost]
        public IActionResult Result(int? id, int answer_score)  // контроллер для страницы с уникальным тестом
        {
            if (id == null) return RedirectToAction("Index"); //выполняем переадресацию на метод Index, который выводит список тестов.

            Test test = DataContext.Tests.Include(t => t.ResultTests).FirstOrDefault<Test>(t => t.Id == id);
            Category category = DataContext.Categories.FirstOrDefault<Category>(c => c.Id == test.CategoryId);

            //ResultTest r = DataContext.ResultTests.FirstOrDefault<ResultTest>(r => r.TestId == id);

            if (test != null)
            {
                //ViewBag.Categories = DataContext.Categories.OrderBy(c => c.Id);


                ViewBag.Categories = DataContext.Categories;
                ViewBag.Test = test;
                ViewBag.Category = category;

                ResultTest result = new ResultTest();

                foreach (var r in test.ResultTests.OrderByDescending(r => r.Scores))
                {
                    if (answer_score <= r.Scores)
                    {
                        result = r;
                    }
                }

                return View(result);
            }
            return NotFound();

        }
    }
}
//Во-первых, здесь удалены все ненужные нам методы - все кроме метода Index,
//который будет использоваться для передачи пользователю данных о товарах.
