using Desktop_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class DataBaseContext : DbContext
    {
        private readonly string relpath = "DataNew.db";
        private readonly string path;
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithMany(u => u.Students)
                .HasForeignKey(s => s.UserName);

            // Additional configuration or mappings

            base.OnModelCreating(modelBuilder);
        }
        public DataBaseContext()
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relpath);
        }


      

    }
}
