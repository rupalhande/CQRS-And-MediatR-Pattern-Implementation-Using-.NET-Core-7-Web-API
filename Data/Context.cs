using CQRSMediatR.Models;
using Microsoft.EntityFrameworkCore;


namespace CQRSMediatR.Data
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseInMemoryDatabase("DefaultConnection");
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(p => p.Id);
            modelBuilder.Entity<Employee>().HasData(
                new Employee(1,"Rahul","rahul1987@gmail.com","New York,USA",46)
            );
        }
    }
}
