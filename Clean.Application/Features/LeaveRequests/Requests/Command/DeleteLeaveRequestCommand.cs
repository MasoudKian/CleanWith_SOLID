using MediatR;

namespace Clean.Application.Features.LeaveRequests.Requests.Command
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public int LeaveRequestId { get; set; }
    }
}
