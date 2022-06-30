using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveTypes;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    internal class GetLeaveTypeDetailsRequestHandler : IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailsRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var type = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(type);
        }
    }
}
