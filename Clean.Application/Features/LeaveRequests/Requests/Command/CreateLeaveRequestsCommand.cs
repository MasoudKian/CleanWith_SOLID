using Clean.Application.DTO.LeaveRequest;
using Clean.Application.Responses;
using MediatR;

namespace Clean.Application.Features.LeaveRequests.Requests.Command
{
    public class CreateLeaveRequestsCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestsDTO CreateLeaveRequestsDTO { get; set; }

    }
}
