using Guest_Book.Models;
namespace Guest_Book.Repository
{
    public interface IRepository
    {
        Task<List<Message>> MessagesToList();
        Task AddMessage(Message message);
        Task Save();
        Task<User> FindUserById(string str);
        Task AddUser(User user);
        Task<int> UsersCount();
        Task<int> CheckingLoginCount(LoginModel login);
        Task<User> CheckingLogin(LoginModel login);
    }
}
