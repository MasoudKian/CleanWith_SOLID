using Clean.Application.DTO.LeaveType;
using MediatR;

namespace Clean.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequestQuery : IRequest<LeaveTypeDTO>
    {
        public int LeaveTypeId { get; set; }
    }
}
