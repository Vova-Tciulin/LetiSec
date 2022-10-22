using LetiSec.PassHashes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LetiSec.Models.DbModel
{
    public class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public UserContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.ApplyConfiguration(new RoleConfig());
             modelBuilder.ApplyConfiguration(new UsersConfig());*/

            modelBuilder.Entity<Role>().HasData(new[]
             {
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "user" }
            });

            User admin = new User { Id = 1, Email = "admin@mail.ru", Name = "Vladimir", Password = "Admin123", RoleId = 1 };
            PasswordHash<User> passwordHash = new PasswordHash<User>();
            admin.Password = passwordHash.HashPas(admin, admin.Password);

            modelBuilder.Entity<User>().HasData(admin);

          
               
               

        }
    }


    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {


        }
    }


    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          
        }
    }
}
