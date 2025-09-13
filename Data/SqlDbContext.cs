using Microsoft.EntityFrameworkCore;
using MyApiProject.Controller;
using MyApiProject.Model.Entitties;

namespace MyApiProject.Data;

public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Certificate> Certificates{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One User has many Results
        modelBuilder.Entity<User>()
            .HasMany(u => u.Results)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // One Result belongs to one Exam (one-to-one)
        modelBuilder.Entity<Result>()
            .HasOne(r => r.Exam)
            .WithOne(e => e.Result)
            .HasForeignKey<Result>(r => r.ExamId)
            .OnDelete(DeleteBehavior.NoAction);

        // One Exam has many Questions
        modelBuilder.Entity<Exam>()
            .HasMany(e => e.Questions)
            .WithOne(q => q.Exam)
            .HasForeignKey(q => q.ExamId)
            .OnDelete(DeleteBehavior.Cascade);

        // One Certificate has one Result (one-to-one)
        modelBuilder.Entity<Certificate>()
            .HasOne(c => c.Result)
            .WithOne(r => r.Certificate)
            .HasForeignKey<Certificate>(c => c.ResultId)
            .OnDelete(DeleteBehavior.NoAction);

        // One User (CreatedBy) can create many Exams
        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Creator)
            .WithMany() // Navigation property optional
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Certificate>()
      .HasOne(c => c.Result)
      .WithOne(r => r.Certificate)
      .HasForeignKey<Certificate>(c => c.ResultId)
      .OnDelete(DeleteBehavior.NoAction);
    }


}