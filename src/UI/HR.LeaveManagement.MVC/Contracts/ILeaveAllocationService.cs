using HR.LeaveManagement.MVC.Services;

namespace HR.LeaveManagement.MVC.Contracts;

public interface ILeaveAllocationService
{
    Task<Response<int>> CreateLeaveAllocations(int leaveTypeId);
}