using Microsoft.EntityFrameworkCore;

namespace Guest_Book.Models
{
    public class Guest_BookContext : DbContext
    {
        public Guest_BookContext(DbContextOptions<Guest_BookContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Message> Messages { get; set; }
    }
}
