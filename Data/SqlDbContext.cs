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
    public DbSet<Certificate> Certificates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //one user has one result
        modelBuilder.Entity<User>()
        .HasOne(u => u.Result)
        .WithOne(r => r.user)
        .HasForeignKey<Result>(r => r.UserId)
        .OnDelete(DeleteBehavior.NoAction);


        //one result can have one exam
        modelBuilder.Entity<Result>()
        .HasOne(r => r.exam) 
            .WithMany() // No navigation property in Exam for Results
            .HasForeignKey(r => r.ExamId)
        .OnDelete(DeleteBehavior.NoAction);

        //one exam have many question
        modelBuilder.Entity<Exam>()
            .HasMany(e => e.Questions)
            .WithOne(q => q.Exam)
            .HasForeignKey(q => q.ExamId)
             .OnDelete(DeleteBehavior.NoAction);



                    // many question belong to one exam
                    modelBuilder.Entity<Question>()
                .HasOne(q => q.Exam)
            .WithMany(e => e.Questions)
            .HasForeignKey(e => e.ExamId)
            .OnDelete(DeleteBehavior.Cascade);


                    modelBuilder.Entity<Certificate>()
            .HasOne(c => c.Result)
            .WithOne(r => r.Certificate)
            .HasForeignKey<Certificate>(c => c.ResultId)
            .OnDelete(DeleteBehavior.NoAction);


        // One User (CreatedBy) can create many Exams
        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Creator) // Navigation property for CreatedBy
            .WithMany() // No navigation property in User for Exams
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction); // Prevent deletion of User if they created

    }


}