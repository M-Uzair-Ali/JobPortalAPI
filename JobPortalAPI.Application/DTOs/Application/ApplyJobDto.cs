namespace JobPortalAPI.Application.DTOs.Application;

public class ApplyJobDto
{
    public Guid JobId { get; set; }
    public string CVFilePath { get; set; } = null!; 
}