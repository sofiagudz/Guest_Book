using System.ComponentModel.DataAnnotations;

namespace Guest_Book.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Message_ { get; set; }

        public DateTime MessageDate { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
    }
}
