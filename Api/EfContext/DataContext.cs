using Microsoft.EntityFrameworkCore;

namespace Api.EfContext;


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

    }
