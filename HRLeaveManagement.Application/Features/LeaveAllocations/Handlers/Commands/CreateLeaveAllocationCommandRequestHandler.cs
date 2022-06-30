using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandRequestHandler : IRequestHandler<CreateLeaveAllocationCommandRequest, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(this._leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.createLeaveAllocationDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.createLeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
