using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using courseProject.Models;
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
    }
}