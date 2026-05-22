namespace JobPortalAPI.Application.DTOs.Job;

public class CreateJobDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Salary { get; set; }
    public string Location { get; set; } = null!;
    public string JobType { get; set; } = null!;
    public DateTime ExpiryDate { get; set; }
}