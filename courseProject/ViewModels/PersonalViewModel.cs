using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject.ViewModels
{
    public class PersonalViewModel
    {
       
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Gender { get; set; }

        public DateTime Birthday { get; set; }
    }
}