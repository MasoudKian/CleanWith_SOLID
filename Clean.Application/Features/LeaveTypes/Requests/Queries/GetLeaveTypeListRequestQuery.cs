using Clean.Application.DTO.LeaveType;
using MediatR;

namespace Clean.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequestQuery : IRequest<List<LeaveTypeDTO>>
    {

    }
}
