using Microsoft.EntityFrameworkCore;

namespace P2PChat.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(m => m.Messages);
            modelBuilder.Entity<Message>().HasOne(u => u.User);
        }
    }
}