using System;

namespace courseProject.Models
{
    public class UserTest
    {
        public int Id { get; set; }
        public int ResultId { get; set; }
        public Boolean Favorite { get; set; }
        public Boolean Finished { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }


        public virtual Test Test { get; set; }
        public virtual User User { get; set; }
        public virtual ResultTest ResultTest { get; set; }
    }
}