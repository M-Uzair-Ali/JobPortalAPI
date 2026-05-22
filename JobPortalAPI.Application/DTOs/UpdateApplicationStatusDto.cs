namespace JobPortalAPI.Application.DTOs;

public class UpdateApplicationStatusDto
{
    /// <summary>
    /// Accepted values: "Pending", "Accepted", "Rejected" (case-insensitive)
    /// </summary>
    public string Status { get; set; } = string.Empty;
}