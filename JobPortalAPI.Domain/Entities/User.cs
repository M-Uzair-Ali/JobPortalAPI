using JobPortalAPI.Domain.Enums;

namespace JobPortalAPI.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<RefreshToken>? RefreshTokens { get; set; }
    // Navigation Properties
    public ICollection<Job>? Jobs { get; set; }
    public ICollection<JobApplication>? JobApplications { get; set; }
}