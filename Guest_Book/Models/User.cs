using System.ComponentModel.DataAnnotations;

namespace Guest_Book.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя пользователя: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пароль: ")]
        public string Password { get; set; }

        public ICollection<Message> Messages { get; set; }
        public User()
        {
            this.Messages = new HashSet<Message>();
        }
    }
}
