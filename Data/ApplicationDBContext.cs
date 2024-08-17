using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Data{
    public class ApplicationDBContext: DbContext{
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions){

        }

        public DbSet<Book> Book {get;  set;}
        public DbSet<User> User {get;  set;}
        public DbSet<Borrowed> Borrowed {get;  set;}
            
    }
}