using library.src.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace library.src.Infrastructure.Data{
    public class ApplicationDBContext: IdentityDbContext<User>{
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions){

        }

        public DbSet<Book> Book {get;  set;}
        public DbSet<User> User {get;  set;}
        public DbSet<Borrowed> Borrowed {get;  set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            
        }

    }
}