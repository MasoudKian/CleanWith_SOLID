using MediatR;

namespace Clean.Application.Features.LeaveAllocations.Requests.Command
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int LeaveAllocationId { get; set; }
    }
}
