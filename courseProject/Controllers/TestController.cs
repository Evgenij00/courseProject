using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using courseProject.Models;
using myCourseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Controllers;

namespace myCourseProject.Controllers
{
    public class TestController : ApplicationController
    {
        public TestController(ApplicationDbContext context) : base(context) { }

        //[Route("Speaker/{id:int}")]
        //[Route("/Speaker/Evaluations", Name = "speakerevals")]
        public IActionResult Index(int? id) //TODO: использовать модель
        {
            if (id == null) return RedirectToAction("Index", "Home");

            //TODO: разобраться, как вызвать Include после отбора данных по условию. (Пока вызывается перед отбором)
            Test test = DataContext.Tests.Include(t => t.Questions.OrderBy(q => q.Number)).FirstOrDefault<Test>(t => t.Id == id);

            if (test != null)
            {
                return View(test);
            }
            return NotFound();
        }

        public IActionResult Question(int? id, int number = 1, int test_score = 0)
        {
            if (id == null) return RedirectToAction("Index");

            Test test = DataContext.Tests.FirstOrDefault(test => test.Id == id);

            //TODO: подумать, как упростить запрос. Найти нужный вопрос через тест, а не через контекст данных
            Question question = DataContext.Questions.Include(q => q.Answers).FirstOrDefault<Question>(q => q.TestId == id && q.Number == number);

            if (question != null)
            {
                QuestionViewModel model = new QuestionViewModel();

                model.Test = test;
                model.Question = question;

                foreach (var answer in question.Answers)
                {
                    answer.Score = answer.Score + test_score;
                }
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Result(int? id, int test_score)
        {
            if (id == null) return RedirectToAction("Index");

            Test test = DataContext.Tests.Include(t => t.ResultTests).FirstOrDefault<Test>(t => t.Id == id);
            Category category = DataContext.Categories.FirstOrDefault<Category>(c => c.Id == test.CategoryId);

            if (test != null)
            {
                ResultViewModel model = new ResultViewModel();

                model.Test = test;
                model.Category = category;

                foreach (var result in test.ResultTests.OrderByDescending(r => r.Scores))
                {
                    if (test_score <= result.Scores)
                    {
                        model.ResultTest = result;
                    }
                }
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
    }
}