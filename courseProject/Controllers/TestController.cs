﻿using courseProject.Models;
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

        [Authorize]
        public async Task<IActionResult> Result(int? testId, int testScore)
        {
            if (testId == null) return RedirectToAction("Index", "Home");

            Test currentTest = await DataContext.Tests.Include(t => t.ResultTests).FirstOrDefaultAsync(t => t.Id == testId);
            if (currentTest != null)
            {
                Category category = await DataContext.Categories.FirstOrDefaultAsync(c => c.Id == currentTest.CategoryId);

                ResultTest currentResult = null;
                foreach (ResultTest result in currentTest.ResultTests.OrderByDescending(r => r.Scores))
                {
                    if (testScore <= result.Scores)
                    {
                        currentResult = result;
                    }
                }

                int userId = await GetUserId();
                UserTest userTest = await DataContext.UserTests.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TestId == testId);
                if (userTest != null)
                {
                    userTest.Finished = true;
                    userTest.ResultId = currentResult.Id;
                    await DataContext.SaveChangesAsync();
                }
                else
                {
                    DataContext.UserTests.Add(new UserTest { UserId = userId, TestId = currentTest.Id, ResultId = currentResult.Id, Finished = true });
                    await DataContext.SaveChangesAsync();
                }

                ResultViewModel model = new ResultViewModel
                {
                    Test = currentTest,
                    Category = category,
                    ResultTest = currentResult,
                };
                return View(model);
            }
            return NotFound();
        }

        [NonAction]
        public async Task<int> GetUserId()
        {
            string userName = User.Identity.Name;
            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName);
            return currentUser.Id;
        }
    }
}