using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequests.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaverRquestCommandRequestHandler : IRequestHandler<CreateLeaverRquestCommandRequest, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaverRquestCommandRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveRequestRepository = leaveRequestRepository;
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaverRquestCommandRequest request, CancellationToken cancellationToken)
        {
            var resonse = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(this._leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.createLeaveRequestDto);

            if (!validationResult.IsValid)
            {
                resonse.Success = false;
                resonse.Message = "Creation Failed";
                resonse.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return resonse;
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.createLeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            resonse.Success = true;
            resonse.Message = "Creation Successful";
            resonse.Id = leaveRequest.Id;
            return resonse;
        }
    }
}
