using HRLeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationWithDetailsRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
