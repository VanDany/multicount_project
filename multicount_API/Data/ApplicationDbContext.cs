using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using multicount_API.Models;

namespace multicount_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TransactionsUsers> TransactionsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction()
                {
                    Id = 1,
                    CategoryId = 1,
                    UserId= "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0",
                    Description = "Raclette",
                    Amount = 51.12F,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.MinValue
                },
                new Transaction()
                {
                    Id = 2,
                    CategoryId = 2,
                    UserId = "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0",
                    Description = "Bananes pour tous",
                    Amount = 5.75F,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.MinValue
                },
                new Transaction()
                {
                    Id = 3,
                    CategoryId = 3,
                    UserId = "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0",
                    Description = "Chauffage",
                    Amount = 450.11F,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.MinValue
                },
                new Transaction()
                {
                    Id = 4,
                    CategoryId = 4,
                    UserId = "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0",
                    Description = "Casseroles",
                    Amount = 23.59F,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.MinValue
                },
                new Transaction()
                {
                    Id = 5,
                    CategoryId = 5,
                    UserId = "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0",
                    Description = "Isolation",
                    Amount = 684.42F,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.MinValue
                }
            );
        }
    }
}
