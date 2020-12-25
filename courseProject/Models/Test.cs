using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myCourseProject.Models
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
        public Category Category { get; set; }
    }
}