using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using courseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.Controllers
{
    public abstract class ApplicationController : Controller
    {

        private ApplicationDbContext _db; // объявление переменной, в которой будет находиться контекст данных

        public ApplicationDbContext DataContext // геттер для получения контекста данных из внешнего кода
        {
            get { return _db; }
        }
        public ApplicationController(ApplicationDbContext context) //конструктор, в котором получаем контекст данных
        {
            _db = context;
        }
    }
}