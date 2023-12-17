using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.DAL.Entity;
using Tasks_System.DAL.Extend;

namespace Tasks_System.DAL.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserTask>()
                .Property(x => x.DueDate)
                .HasColumnType("date");
        }

        public DbSet<UserTask> UserTasks  { get; set; }
        public DbSet<UserTaskAssignment> UserTaskAssignments { get; set; }


    }
}
