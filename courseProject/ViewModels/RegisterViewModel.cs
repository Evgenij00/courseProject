using System.ComponentModel.DataAnnotations;


namespace сourseProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //Если мы меняем длину пароля, то соответственно нам надо изменить определение модели регистрации,
        //если она устанавливает ограничение на длину:
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}