using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveType: BaseDomainEntitiy
{
    public string Name { get; set; } = null!;
    public int DefaultDays { get; set; }
}