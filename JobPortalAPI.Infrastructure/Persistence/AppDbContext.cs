using JobPortalAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Job> Jobs { get; set; } = null!;
    public DbSet<JobApplication> JobApplications { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>()
            .Property(j => j.Salary)
            .HasPrecision(18, 2);  

        modelBuilder.Entity<Job>()
            .HasOne(j => j.Recruiter)
            .WithMany(u => u.Jobs)
            .HasForeignKey(j => j.RecruiterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<JobApplication>()
            .HasOne(a => a.Job)
            .WithMany(j => j.JobApplications)
            .HasForeignKey(a => a.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<JobApplication>()
            .HasOne(a => a.Candidate)
            .WithMany(u => u.JobApplications)
            .HasForeignKey(a => a.CandidateId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}