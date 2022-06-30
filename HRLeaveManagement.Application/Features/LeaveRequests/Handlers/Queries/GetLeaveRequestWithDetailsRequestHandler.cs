using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequests;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestWithDetailsRequestHandler : IRequestHandler<GetLeaveRequestWithDetailsRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestWithDetailsRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._mapper = mapper;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveRequestWithDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
