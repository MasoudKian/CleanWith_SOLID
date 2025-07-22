using Clean.Application.DTO.LeaveType;
using MediatR;

namespace Clean.Application.Features.LeaveTypes.Requests.Command
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDTO? LeaveTypeDto { get; set; }
    }
}
