using Guest_Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Guest_Book.Repository
{
    public class Guest_BookRepository : IRepository
    {
        private readonly Guest_BookContext db;

        public Guest_BookRepository(Guest_BookContext context)
        {
            db = context;
        }

        public async Task<List<Message>> MessagesToList()
        {
            return await db.Messages.ToListAsync();
        }

        public async Task AddMessage(Message message)
        {
            await db.Messages.AddAsync(message);
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public async Task<List<User>> FindUserById()
        {
            string user = HttpContext.Session.GetString("Login");
            return await db.Users.Where(a => a.Name == HttpContext.Session.GetString("Login"));
        }

        public async Task AddUser(User user)
        {
            await db.Users.AddAsync(user);
        }

        public async Task<List<User>> UsersToList()
        {
            //return await db.Users.CountAsync();
            return await db.Users.ToListAsync();
        }

        public async Task<List<User>> CheckingLogin(LoginModel login)
        {
            return await db.Users.Where(a => a.Name == login.Name);
        }
    }
}
