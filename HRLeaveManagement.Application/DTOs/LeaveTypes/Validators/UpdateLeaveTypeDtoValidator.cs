using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs.LeaveTypes.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeRequestDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
