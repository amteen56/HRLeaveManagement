using HRLeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommandRequest : IRequest<int>
    {
        public CreateLeaveAllocationDto createLeaveAllocationDto { get; set; }
    }
}
