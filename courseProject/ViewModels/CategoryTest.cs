using courseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.ViewModels
{
    public class CategoryTest
    {
        public IEnumerable<Test> Tests { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}