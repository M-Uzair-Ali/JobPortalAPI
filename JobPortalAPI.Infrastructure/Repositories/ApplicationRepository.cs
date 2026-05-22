using JobPortalAPI.Application.Interfaces;
using JobPortalAPI.Domain.Entities;
using JobPortalAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Infrastructure.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly AppDbContext _context;

    public ApplicationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<JobApplication> CreateAsync(JobApplication application)
    {
        await _context.JobApplications.AddAsync(application);
        await _context.SaveChangesAsync();
        return application;
    }

    public async Task<JobApplication?> GetByIdAsync(Guid id)
    {
        return await _context.JobApplications
            .Include(a => a.Job)
            .Include(a => a.Candidate)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<JobApplication>> GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.JobApplications
            .Include(a => a.Job)
                .ThenInclude(j => j.Recruiter)
            .Where(a => a.CandidateId == candidateId)
            .OrderByDescending(a => a.AppliedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<JobApplication>> GetByJobIdAsync(Guid jobId)
    {
        return await _context.JobApplications
            .Include(a => a.Candidate)
            .Where(a => a.JobId == jobId)
            .OrderByDescending(a => a.AppliedAt)
            .ToListAsync();
    }

    public async Task<bool> HasAppliedAsync(Guid jobId, Guid candidateId)
    {
        return await _context.JobApplications
            .AnyAsync(a => a.JobId == jobId && a.CandidateId == candidateId);
    }

    public async Task<JobApplication?> UpdateAsync(JobApplication application)
    {
        var existing = await _context.JobApplications.FindAsync(application.Id);
        if (existing is null) return null;

        existing.Status = application.Status;
        existing.CVFilePath = application.CVFilePath;

        await _context.SaveChangesAsync();
        return existing;
    }
}