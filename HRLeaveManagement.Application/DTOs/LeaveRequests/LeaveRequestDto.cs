using HRLeaveManagement.Application.DTOs.LeaveRequests;
using HRLeaveManagement.Application.DTOs.LeaveTypes;
using HRLeaveManagement.Application.DTOs.Common;
using HRLeaveManagement.Application.DTOs.LeaveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs.LeaveRequests
{
    public class LeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
