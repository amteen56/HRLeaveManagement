using HRLeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs.LeaveTypes
{
    public class UpdateLeaveTypeRequestDto : BaseDto, ILeaveTypeDto
    {
        public int DefaultDays { get; set; }
        public string Name { get; set; }
    }
}
