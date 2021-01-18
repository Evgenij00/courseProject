using courseProject.Models;
using courseProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // пространство имен EntityFramework
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.Controllers
{
    public class TestController : ApplicationController 
    {
        //Вызывает конструктор ApplicationController
        public TestController(ApplicationDbContext context) : base(context) { } 

        // выполняется для адресса Test/Index
        [Authorize] //выполняется только если пользователь авторизован, иначе происходит перенаправление на страницу входа
        public async Task<IActionResult> IndexAsync(int? testId)
        {
            if (testId == null) return RedirectToAction("Index", "Home");

            int userId = await GetUserId(); // получаем Id
            UserTest userTest = DataContext.UserTests.FirstOrDefault(ut => ut.UserId == userId && ut.TestId == testId && ut.Finished);
            if (userTest != null) //проверяем, есть ли завершенный тест, userId которого совпадает с Id авторизованного пользователя и tetsId совпадает с текущем тестом
            {
                return RedirectToAction("ShowResult", userTest); //если да, то сразу показываем результат теста
            }

            // иначе показываем начальную страницу теста
            Test test = await DataContext.Tests.FirstOrDefaultAsync(t => t.Id == testId);  // находим тест по Id
            if (test != null)
            {
                return View(test);
            }

            return NotFound();
        }

        // выполняется для адресса Test/Question
        [Authorize] //выполняется только если пользователь авторизован, иначе происходит перенаправление на страницу входа
        public async Task<IActionResult> Question(int? testId, int number = 1, int testScore = 0) //принимает Id теста, номер вопроса и текущее кол-во очков теста
        {
            if (testId == null) return RedirectToAction("Index", "Home");
             
            Test test = await DataContext.Tests.FirstOrDefaultAsync(test => test.Id == testId); // получаем тест

            Question question = await DataContext.Questions.Include(q => q.Answers).FirstOrDefaultAsync(q => q.TestId == testId && q.Number == number); // получаем текущий вопрос
            if (question != null)
            {
                foreach (var answer in question.Answers) // пробегаемся по всем атветам вопроса и прибавляем к их баллам текущие баллы теста
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

        // выполняется для адресса Test/Result
        [Authorize] //выполняется только если пользователь авторизован, иначе происходит перенаправление на страницу входа
        public async Task<IActionResult> Result(int? testId, int testScore) // принимает Id теста и набранные баллы в тесте
        {
            if (testId == null) return RedirectToAction("Index", "Home");

            Test currentTest = await DataContext.Tests.Include(t => t.ResultTests).FirstOrDefaultAsync(t => t.Id == testId); // получаем тест
            if (currentTest != null) 
            {
                Category category = await DataContext.Categories.FirstOrDefaultAsync(c => c.Id == currentTest.CategoryId);  // получаем категорю, к торой относиться тест

                ResultTest currentResult = null; // здесь будет хранится результат теста, основанный на набранных баллах

                // пробегаемся по всем результатам теста и сравниваем их баллы с полученными
                foreach (ResultTest result in currentTest.ResultTests.OrderByDescending(r => r.Scores))
                {
                    if (testScore <= result.Scores)
                    {
                        currentResult = result;
                    }
                }

                int userId = await GetUserId(); // получаем Id пользователя
                UserTest userTest = await DataContext.UserTests.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TestId == testId);  // получаем тест
                if (userTest != null)
                {
                    userTest.Finished = true; // указываем, что он пройден для авторизованного пользователя
                    userTest.ResultId = currentResult.Id; // добавляем полученный результат
                    await DataContext.SaveChangesAsync();  // обновляем бд
                }
                else
                {
                    // передаем в новый тест полученные данные и добавляем в бд
                    DataContext.UserTests.Add(new UserTest { UserId = userId, TestId = currentTest.Id, ResultId = currentResult.Id, Finished = true });
                    await DataContext.SaveChangesAsync(); // обновляем бд
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
        //вспомагающий метод, позволяющий просмотреть результат теста авторизованного пользователя, минуя его прохождение
        public async Task<ActionResult> ShowResult(UserTest userTest)
        {

            Test currentTest = await DataContext.Tests.FirstOrDefaultAsync(t => t.Id == userTest.TestId); // получаем тест
            ResultTest result = await DataContext.ResultTests.FirstOrDefaultAsync(r => r.Id == userTest.ResultId); // получаем результат теста
            Category category = await DataContext.Categories.FirstOrDefaultAsync(c => c.Id == currentTest.CategoryId);  // получаем категорию, которая относятся к тесту

            ResultViewModel model = new ResultViewModel
            {
                Test = currentTest,
                Category = category,
                ResultTest = result,
            };
            return View("Result", model);
        }

        // выполняется для адресса Test/RepeatTest
        public async Task<ActionResult> RepeatTest(int? testId)
        {
            if (testId == null) return RedirectToAction("Index", "Home");

            int userId = await GetUserId(); // получаем Id пользователя
            UserTest userTest = await DataContext.UserTests.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TestId == testId);  // получаем тест, относящийся к пользователю
            if (userTest != null)
            {
                userTest.Finished = false; // указываем, что он снова будет доступен для прохождения
                await DataContext.SaveChangesAsync(); // обновляем бд
            }

            return RedirectToAction("Index", "Test", new { testId });
        }

        // выполняется для адресса Test/Favorite. Запрос прилетает от favorite.js
        public async Task Favorite(int testId, bool isFavorite)
        {
            int userId = await GetUserId(); // получаем Id пользователя

            if (isFavorite)
            {
                // получаем тест пользователя
                UserTest userTest = await DataContext.UserTests.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TestId == testId); 
                if (userTest != null)
                {
                    userTest.Favorite = true; // указываем, что он избранный для пользователя
                    await DataContext.SaveChangesAsync(); // обновляем бд
                }
                else
                {
                    // добавляем новый тест пользователя и указываем, что он избранный
                    DataContext.UserTests.Add(new UserTest { UserId = userId, TestId = testId, Favorite = true });
                    await DataContext.SaveChangesAsync(); // обновляем бд
                }
            }
            else
            {
                // получаем тест пользователя
                UserTest usertTest = await DataContext.UserTests.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TestId == testId);
                usertTest.Favorite = false; // указываем, что он перестал быть избранным
                await DataContext.SaveChangesAsync(); // обновляем бд
            }
        }

        [NonAction] // это внутренний метод, не может быть вызван как действие контроллера
        public async Task<int> GetUserId() //возвращает Id авторизованного пользователя
        {
            string userName = User.Identity.Name;
            User currentUser = await DataContext.Users.FirstOrDefaultAsync(u => u.Email == userName);
            return currentUser.Id;
        }
    }
}