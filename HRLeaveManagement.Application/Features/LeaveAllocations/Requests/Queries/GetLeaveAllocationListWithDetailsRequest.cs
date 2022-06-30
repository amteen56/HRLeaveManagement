using HRLeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListWithDetailsRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
