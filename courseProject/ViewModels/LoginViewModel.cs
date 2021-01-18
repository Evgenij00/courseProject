using System.ComponentModel.DataAnnotations;

namespace сourseProject.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}