using courseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.ViewModels
{
    public class ResultViewModel
    {
        public Test Test { get; set; }
        public Category Category { get; set; }
        public ResultTest ResultTest { get; set; }
    }
}