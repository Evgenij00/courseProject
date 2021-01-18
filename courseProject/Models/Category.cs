using System.Collections.Generic;


namespace courseProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public List<Test> Tests { get; set; }
    }
}
