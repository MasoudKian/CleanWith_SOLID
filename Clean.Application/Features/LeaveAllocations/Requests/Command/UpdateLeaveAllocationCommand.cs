using Clean.Application.DTO.LeaveAllocation;
using MediatR;

namespace Clean.Application.Features.LeaveAllocations.Requests.Command
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }
    }
}
