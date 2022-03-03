namespace HR.LeaveManagement.Application.Responses;

public class BaseCommandResponse
{
    public int Id { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = null!;
    public List<string> Errors { get; set; } = null!;
}