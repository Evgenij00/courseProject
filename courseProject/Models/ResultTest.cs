
namespace courseProject.Models
{
    public class ResultTest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Scores { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}