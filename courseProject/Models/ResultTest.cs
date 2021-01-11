using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myCourseProject.Models
{
    public class ResultTest
    {
        public int Id { get; set; }
        //TODO: Description вместо Descriptions
        public string Descriptions { get; set; }
        public int Scores { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}