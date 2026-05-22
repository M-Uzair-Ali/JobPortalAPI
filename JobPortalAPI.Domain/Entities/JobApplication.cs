using JobPortalAPI.Domain.Enums;

namespace JobPortalAPI.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; set; }

    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;

    public Guid CandidateId { get; set; }
    public User Candidate { get; set; } = null!;

    public string CVFilePath { get; set; } = null!;
    public ApplicationStatus Status { get; set; }
    public DateTime AppliedAt { get; set; }
}