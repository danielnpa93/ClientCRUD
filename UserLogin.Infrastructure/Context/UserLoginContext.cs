using Microsoft.EntityFrameworkCore;
using UserLogin.Domain.Entities;
using UserLogin.Infrastructure.Mappings;

namespace UserLogin.Infrastructure.Context
{
    public class UserLoginContext : DbContext
    {
        public UserLoginContext()
        {
        }

        public UserLoginContext(DbContextOptions<UserLoginContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
