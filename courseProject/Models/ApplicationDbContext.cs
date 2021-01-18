using Microsoft.EntityFrameworkCore; //Подключаем EntityFrameworkCore

namespace courseProject.Models
{
    //Чтобы создать контекст, нам надо унаследовать новый класс от класса DbContext
    public class ApplicationDbContext : DbContext
    {
        //Свойства наподобие public DbSet<Phone> Phones { get; set; }
        //помогают получать из БД набор данных определенного типа(например, набор объектов User). 
        //Фактически каждое свойство DbSet будет соотноситься с отдельной таблицей в базе данных.

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ResultTest> ResultTests { get; set; }
        public DbSet<UserTest> UserTests { get; set; }


        //По умолчанию у нас база данных отсутствует. Поэтому в конструктор ApplicationDbContext определен вызов Database.EnsureCreated(),
        //который при отсутствии базы данных автоматически создает ее. Если база данных уже есть, то ничего не происходит.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //Конструктор
        {
            Database.EnsureCreated();
        }
    }
}