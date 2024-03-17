
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Model.DBMameger
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Mission> Missions { get; set; } = null!;
        public ApplicationContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=123456789;database=wpfmission;",
                new MySqlServerVersion(new Version(8, 3, 0)));
        }

    }
}
