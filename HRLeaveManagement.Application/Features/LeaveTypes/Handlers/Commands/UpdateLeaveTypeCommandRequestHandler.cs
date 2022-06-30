using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveTypes.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandRequestHandler : IRequestHandler<UpdateLeaveTypeCommandRequest, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveTypeRequestDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveAllocation = await _leaveTypeRepository.Get(request.leaveTypeRequestDto.Id);

            _mapper.Map(request.leaveTypeRequestDto, leaveAllocation);
            await _leaveTypeRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
