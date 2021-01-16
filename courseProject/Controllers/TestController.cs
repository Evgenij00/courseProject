using courseProject.Models;
using courseProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.Controllers
{
    public class TestController : ApplicationController
    {
        public TestController(ApplicationDbContext context) : base(context) { }

        [Authorize]
        public async Task<IActionResult> IndexAsync(int? testId)
        {
            if (testId == null) return RedirectToAction("Index", "Home");

            Test test = await DataContext.Tests.FirstOrDefaultAsync(t => t.Id == testId);
            if (test != null)
            {
                return View(test);
            }

            return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> Question(int? testId, int number = 1, int testScore = 0)
        {
            if (testId == null) return RedirectToAction("Index", "Home");

            Test test = await DataContext.Tests.FirstOrDefaultAsync(test => test.Id == testId);
            Question question = await DataContext.Questions.Include(q => q.Answers).FirstOrDefaultAsync(q => q.TestId == testId && q.Number == number);
            if (question != null)
            {
                foreach (var answer in question.Answers)
                {
                    answer.Score += testScore;
                }

                QuestionViewModel model = new QuestionViewModel
                {
                    Test = test,
                    Question = question
                };
                return View(model);
            }
            return NotFound();
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