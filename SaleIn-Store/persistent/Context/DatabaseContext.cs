using Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace persistent.Context
{
    public class DatabaseContext:DbContext,IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
       // public DbSet<User> Users { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder.UseSqlServer("name=SaleInConnection");
           base.OnConfiguring(optionsBuilder);
       }
    }
}
