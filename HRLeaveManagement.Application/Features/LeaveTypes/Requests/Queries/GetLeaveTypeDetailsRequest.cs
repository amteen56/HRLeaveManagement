using HRLeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailsRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
