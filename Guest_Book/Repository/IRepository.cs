using Guest_Book.Models;
namespace Guest_Book.Repository
{
    public interface IRepository
    {
        Task<List<Message>> MessagesToList();
        Task AddMessage(Message message);
        Task Save();
        Task<List<User>> FindUsersById();
        Task AddUser(User user);
        Task<List<User>> UsersToList();
        Task<List<User>> CheckingLogin(LoginModel login);
    }
}
