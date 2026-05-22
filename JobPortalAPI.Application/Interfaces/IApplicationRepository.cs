using JobPortalAPI.Domain.Entities;

namespace JobPortalAPI.Application.Interfaces;

public interface IApplicationRepository
{
    Task<JobApplication> CreateAsync(JobApplication application);
    Task<JobApplication?> GetByIdAsync(Guid id);
    Task<IEnumerable<JobApplication>> GetByCandidateIdAsync(Guid candidateId);
    Task<IEnumerable<JobApplication>> GetByJobIdAsync(Guid jobId);
    Task<bool> HasAppliedAsync(Guid jobId, Guid candidateId);
    Task<JobApplication?> UpdateAsync(JobApplication application);
}