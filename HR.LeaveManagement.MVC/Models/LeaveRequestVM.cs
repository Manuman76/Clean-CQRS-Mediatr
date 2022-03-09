using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.LeaveManagement.MVC.Models;

public class LeaveRequestVM : CreateLeaveRequestVM
{
    public int Id { get; set; }

    [Display(Name = "Date Requested")]
    public DateTime DateRequested { get; set; }
        
    [Display(Name = "Date Actioned")]
    public DateTime DateActioned { get; set; }
        
    [Display(Name = "Approval State")]
    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }
    public LeaveTypeVM LeaveType { get; set; } = null!;
    public EmployeeVM Employee { get; set; } = null!;

}

public class CreateLeaveRequestVM
{

    [Display(Name = "Start Date")]
    [Required]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date")]
    [Required]
    public DateTime EndDate { get; set; }

    public SelectList LeaveTypes { get; set; } = null!;

    [Display(Name = "Leave Type")]
    [Required]
    public int LeaveTypeId { get; set; }

    [Display(Name = "Comments")]
    [MaxLength(300)]
    public string RequestComments { get; set; } = null!;
}

public class AdminLeaveRequestViewVM
{
    [Display(Name = "Total Number Of Requests")]
    public int TotalRequests { get; set; }
    [Display(Name = "Approved Requests")]
    public int ApprovedRequests { get; set; }
    [Display(Name = "Pending Requests")]
    public int PendingRequests { get; set; }
    [Display(Name = "Rejected Requests")]
    public int RejectedRequests { get; set; }
    public List<LeaveRequestVM> LeaveRequests { get; set; } = null!;
}


public class EmployeeLeaveRequestViewVM
{
    public List<LeaveAllocationVM> LeaveAllocations { get; set; } = null!;
    public List<LeaveRequestVM> LeaveRequests { get; set; } = null!;
}