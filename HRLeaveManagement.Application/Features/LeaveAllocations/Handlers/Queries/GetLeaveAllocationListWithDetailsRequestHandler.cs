using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocations;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListWithDetailsRequestHandler : IRequestHandler<GetLeaveAllocationListWithDetailsRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListWithDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var AllocationList = await _leaveAllocationRepository.GetLeaveAllocationListWithDetails();
            return _mapper.Map<List<LeaveAllocationDto>>(AllocationList);
        }
    }
}
