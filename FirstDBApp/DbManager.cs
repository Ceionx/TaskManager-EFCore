using FirstDBApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDBApp
{
    internal class TaskDbContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Omnis\source\repos\FirstDBApp\FirstDBApp\Database.FirstDBApp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Skillset)
                .WithMany(s => s.Users)
                .UsingEntity(j => j.ToTable("UserSkills"));

            modelBuilder.Entity<Models.Task>()
                .HasMany(t => t.RequiredSkills)
                .WithMany(s => s.Tasks)
                .UsingEntity(j => j.ToTable("TaskSkills"));
        }
    }
}
