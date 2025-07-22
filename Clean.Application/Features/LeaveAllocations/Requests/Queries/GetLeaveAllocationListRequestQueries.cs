using Clean.Application.DTO.LeaveAllocation;
using MediatR;

namespace Clean.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDTO>>
    {

    }
}
