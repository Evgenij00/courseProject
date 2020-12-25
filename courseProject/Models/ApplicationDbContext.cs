using Microsoft.EntityFrameworkCore; //Подключаем EntityFrameworkCore
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myCourseProject.Models
{
    public class ApplicationDbContext : DbContext //Чтобы создать контекст, нам надо унаследовать новый класс от класса DbContext (AplicationContext)
    {
        //По умолчанию у нас база данных отсутствуют.Поэтому в конструктор TestsContext определен вызов Database.EnsureCreated(),
        //который при отсутствии базы данных автоматически создает ее.Если база данных уже есть, то ничего не происходит.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //Конструктор
        {
            Database.EnsureCreated();
        }

    }
}