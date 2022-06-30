using HRLeaveManagement.Application.DTOs.LeaveRequests;
using HRLeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaverRquestCommandRequest : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto createLeaveRequestDto { get; set; }
    }
}
