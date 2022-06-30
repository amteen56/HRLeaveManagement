using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandRequestHandler : IRequestHandler<UpdateLeaveAllocationCommandRequest, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(this._leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveAllocationDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveAllocation = await _leaveAllocationRepository.Get(request.leaveAllocationDto.Id);
            _mapper.Map(request.leaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
