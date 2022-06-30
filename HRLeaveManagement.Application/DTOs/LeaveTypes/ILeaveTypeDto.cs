using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs.LeaveTypes
{
    public interface ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}