using FluentValidation;

namespace Clean.Application.DTO.LeaveType.Validators
{
    public class UpdateLeaveTypeValidator : AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotNull()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
