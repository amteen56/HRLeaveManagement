using AutoMapper;
using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveRequests;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListWithDetailsRequestHandler : IRequestHandler<GetLeaveRequestListWithDetailsRequest, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListWithDetailsRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._mapper = mapper;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var AllocationList = await _leaveRequestRepository.GetLeaveRequestListWithDetails();
            return _mapper.Map<List<LeaveRequestListDto>>(AllocationList);
        }
    }
}
