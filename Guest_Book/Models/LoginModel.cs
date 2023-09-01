using System.ComponentModel.DataAnnotations;

namespace Guest_Book.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
