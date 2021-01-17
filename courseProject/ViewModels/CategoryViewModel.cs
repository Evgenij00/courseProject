using courseProject.Models;
using System.Collections.Generic;

namespace courseProject.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<Test> Tests { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}