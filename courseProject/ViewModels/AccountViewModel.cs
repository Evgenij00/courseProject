using courseProject.Models;
using System.Collections.Generic;


namespace courseProject.ViewModels
{
    public class AccountViewModel
    {
        public User User { get; set; }
        public List<UserTest> UserTests { get; set; }
    }
}