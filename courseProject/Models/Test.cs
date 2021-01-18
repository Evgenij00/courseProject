using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace courseProject.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Autors { get; set; }
        public int NumberOfQuestions { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<UserTest> UserTests { get; set; }
        public List<Question> Questions { get; set; }
        public List<ResultTest> ResultTests { get; set; }

        [NotMapped]
        public bool Favorite { get; set; }
    }
}