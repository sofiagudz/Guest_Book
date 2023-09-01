using System.ComponentModel.DataAnnotations;

namespace Guest_Book.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set;}
    }
}
