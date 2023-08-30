using Microsoft.EntityFrameworkCore;

namespace GrivenceCellForCollage.Models
{
    public class CollageDbContext : DbContext
    {
        public CollageDbContext(DbContextOptions<CollageDbContext> options) : base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CompaintBox> Complaints { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>()
           .HasOne(u => u.User)
           .WithOne(r => r.register)
           .HasForeignKey<Users>(r => r.Id);

            
        }

    }
}