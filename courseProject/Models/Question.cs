using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

    }
}
