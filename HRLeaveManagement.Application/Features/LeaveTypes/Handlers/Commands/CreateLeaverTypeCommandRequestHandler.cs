using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveTypes.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandRequestHandler : IRequestHandler<CreateLeaveTypeCommandRequest, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.createLeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(request.createLeaveTypeDto);

                leaveType = await _leaveTypeRepository.Add(leaveType);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveType.Id;
            }

            return response;
        }
    }
}
