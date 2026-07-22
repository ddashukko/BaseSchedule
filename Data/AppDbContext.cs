using Microsoft.EntityFrameworkCore;
using BaseSchedule.Models;

namespace BaseSchedule.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ScheduleEvent> ScheduleEvents { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ScheduleEvent>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Lessons)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.ScheduleEvent)
                .WithMany()
                .HasForeignKey(p => p.ScheduleEventId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}