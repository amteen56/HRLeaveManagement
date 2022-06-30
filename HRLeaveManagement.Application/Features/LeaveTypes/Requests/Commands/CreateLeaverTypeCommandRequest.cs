using HRLeaveManagement.Application.DTOs.LeaveRequests;
using HRLeaveManagement.Application.DTOs.LeaveTypes;
using HRLeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommandRequest : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto createLeaveTypeDto { get; set; }
    }
}
