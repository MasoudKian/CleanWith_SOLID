using Clean.Application.DTO.LeaveRequest;
using MediatR;

namespace Clean.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequestQueries : IRequest<LeaveRequestDTO>
    {
        public int LeaveRequestId { get; set; }
    }
}
