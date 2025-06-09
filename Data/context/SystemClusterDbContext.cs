using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.context
{
    public class SystemClusterDbContext : DbContext
    {
        public SystemClusterDbContext(DbContextOptions<SystemClusterDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClusteredNameRow> NamesData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // כאן תוכל להוסיף הגדרות מתקדמות אם יש
            modelBuilder.Entity<ValueCodeItem>().HasNoKey();
        }
    }
}
