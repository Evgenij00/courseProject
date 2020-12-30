using Microsoft.EntityFrameworkCore; //Подключаем EntityFrameworkCore
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.Models
{
    public class ApplicationDbContext : DbContext //Чтобы создать контекст, нам надо унаследовать новый класс от класса DbContext (AplicationContext)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        //По умолчанию у нас база данных отсутствуют.Поэтому в конструктор TestsContext определен вызов Database.EnsureCreated(),
        //который при отсутствии базы данных автоматически создает ее.Если база данных уже есть, то ничего не происходит.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //Конструктор
        {
            Database.EnsureCreated();
        }

    }
}