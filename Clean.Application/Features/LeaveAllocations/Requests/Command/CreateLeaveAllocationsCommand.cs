using Clean.Application.DTO.LeaveAllocation;
using MediatR;

namespace Clean.Application.Features.LeaveAllocations.Requests.Command
{
    public class CreateLeaveAllocationsCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
    }
}
