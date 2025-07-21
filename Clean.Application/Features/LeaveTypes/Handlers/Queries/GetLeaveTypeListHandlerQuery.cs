using Clean.Application.DTO.LeaveType;
using Clean.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;

namespace Clean.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListHandlerQuery
        : IRequestHandler<GetLeaveTypeListRequestQuery, List<LeaveTypeDTO>>
    {
        public Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequestQuery request
            , CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
