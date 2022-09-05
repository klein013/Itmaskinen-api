using System;
using Microsoft.EntityFrameworkCore;

namespace Itmaskinen_api.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options){ }

        public DbSet<User> _userEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasKey("Id");
        }
    }
}
