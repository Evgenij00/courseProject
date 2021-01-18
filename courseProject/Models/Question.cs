using System.Collections.Generic;

namespace courseProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
