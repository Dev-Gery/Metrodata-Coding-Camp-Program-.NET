using api.Model;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class MyContext : DbContext
    {
        internal readonly object entities;

        public MyContext(DbContextOptions<MyContext> option) : base(option)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(eye => eye.Account)
                .WithOne(act => act.Employee)
                .HasForeignKey<Account>(act => act.NIK)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .HasOne(act => act.Profiling)
                .WithOne(plg => plg.Account)
                .HasForeignKey<Profiling>(plg => plg.NIK)
                .IsRequired();

            modelBuilder.Entity<Profiling>()
                .HasOne(plg => plg.Education)
                .WithMany(edu => edu.Profiling);

            modelBuilder.Entity<Education>()
                .HasOne(edu => edu.University)
                .WithMany(uni => uni.Education);
        }
    }
}
