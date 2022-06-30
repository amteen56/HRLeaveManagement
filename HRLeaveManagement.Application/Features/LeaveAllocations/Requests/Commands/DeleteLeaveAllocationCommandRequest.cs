using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class DeleteLeaveAllocationCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
