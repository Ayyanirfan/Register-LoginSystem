using Microsoft.EntityFrameworkCore;
using Register_LoginSystem.Models;

namespace Register_LoginSystem.Data
{
    public class myDbContext :DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> options) : base(options) { }
      public DbSet<User> tbl_users { get; set; }
        
    }
}
