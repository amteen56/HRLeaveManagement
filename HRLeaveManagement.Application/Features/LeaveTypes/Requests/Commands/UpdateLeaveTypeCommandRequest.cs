using HRLeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommandRequest : IRequest<Unit>
    {
        public UpdateLeaveTypeRequestDto leaveTypeRequestDto { get; set; }
    }
}
