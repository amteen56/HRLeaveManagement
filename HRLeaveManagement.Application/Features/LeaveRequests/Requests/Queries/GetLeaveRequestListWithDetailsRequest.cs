using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListWithDetailsRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}
