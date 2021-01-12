using courseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.ViewModels
{
    public class QuestionViewModel
    {
        public Test Test { get; set; }
        public Question Question { get; set; }
    }
}