using api.Model;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class MyContext : DbContext
    {
        internal readonly object entities;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public MyContext(DbContextOptions<MyContext> option) : base(option)
        {
            entities = new { Employees, Accounts, Profilings, Educations, Universities, Roles, Authorities };
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Account>(eye => eye.Account)
                .WithOne(act => act.Employee)
                .HasForeignKey<Account>(act => act.NIK)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .Property(g => g.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Account>()
                .HasOne<Profiling>(act => act.Profiling)
                .WithOne(plg => plg.Account)
                .HasForeignKey<Profiling>(plg => plg.NIK)
                .OnDelete(DeleteBehavior.Cascade);
                
 
            modelBuilder.Entity<Profiling>()
                .HasOne<Education>(plg => plg.Education)
                .WithMany(edu => edu.Profilings)
                .HasForeignKey(plg => plg.Education_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Education>()
                .HasOne<University>(edu => edu.University)
                .WithMany(uni => uni.Educations)
                .HasForeignKey(edu => edu.University_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Authority>()
                .HasOne<Account>(aty => aty.Account)
                .WithMany(act => act.Authorities)
                .HasForeignKey(aty => aty.Account_NIK)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Authority>()
                .HasOne<Role>(aty => aty.Role)
                .WithMany(rle => rle.Authorities)
                .HasForeignKey(aty => aty.Role_Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Authority>()
                .HasKey(aty => new { aty.Account_NIK, aty.Role_Id });

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .EnableSensitiveDataLogging();
        //}
    }
}
