using courseProject.Models;
using System.Collections.Generic;

namespace courseProject.ViewModels
{
    public class IndexViewModel
    {
        public List<Test> Tests { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}